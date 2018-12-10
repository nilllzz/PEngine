using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Projects;
using PEngine.Creator.Properties;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game
{
    internal partial class MapPainter : PictureBox, IEventBusComponent
    {
        private readonly ProjectEventBus _eventBus;
        private readonly MapData _data;

        private Bitmap _tileLayer;
        private Bitmap _finalComposite;
        private TileData _selectedTile;
        private Point? _lastTilePainted = null;
        private bool _isMapExpanded = false;
        private bool _isOutdated = false;
        private bool _gridEnabled = false;

        internal Size MapSize { get; private set; }
        internal Point MapOrigin { get; private set; }
        internal MapPainterMode Mode { get; set; } = MapPainterMode.Create;
        internal bool GridEnabled
        {
            get => _gridEnabled;
            set
            {
                _gridEnabled = value;
                RedrawComposite();
            }
        }

        internal MapPainter(ProjectEventBus eventBus, MapData data)
        {
            InitializeComponent();
            SizeMode = PictureBoxSizeMode.CenterImage;
            Location = new Point(0, 0);

            // default data
            MapSize = new Size(2, 2);
            MapOrigin = new Point(2, 2);

            _data = data;

            _eventBus = eventBus;
            RegisterEvents();

            InitData();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            base.OnPaint(pe);
        }

        #region events

        private void RegisterEvents()
        {
            _eventBus.TileSelected += _eventBus_TileSelected;
            _eventBus.TileUpdated += _eventBus_TileUpdated;
            _eventBus.TileRemoved += _eventBus_TileRemoved;
            _eventBus.SubtileUpdated += _eventBus_SubtileUpdated;
            _eventBus.SubtileRemoved += _eventBus_SubtileRemoved;
        }

        public void UnregisterEvents()
        {
            _eventBus.TileSelected -= _eventBus_TileSelected;
            _eventBus.TileUpdated -= _eventBus_TileUpdated;
            _eventBus.TileRemoved -= _eventBus_TileRemoved;
            _eventBus.SubtileUpdated -= _eventBus_SubtileUpdated;
            _eventBus.SubtileRemoved -= _eventBus_SubtileRemoved;
        }

        private void _eventBus_TileSelected(TilesetData tileset, TileData tile)
        {
            if (tileset.id == _data.tileset)
            {
                _selectedTile = tile;
                if (_selectedTile == null)
                {
                    Cursor = Cursors.Default;
                }
                else
                {
                    Cursor = Cursors.Hand;
                }
            }
        }

        private void _eventBus_SubtileRemoved(TilesetData tileset, SubtileData subtile)
        {
            if (tileset.id == _data.tileset)
            {
                _isOutdated = true;
                RedrawComposite();
            }
        }

        private void _eventBus_SubtileUpdated(TilesetData tileset, SubtileData subtile)
        {
            if (tileset.id == _data.tileset)
            {
                _isOutdated = true;
                RedrawComposite();
            }
        }

        private void _eventBus_TileRemoved(TilesetData tileset, TileData tile)
        {
            if (tileset.id == _data.tileset && _data.tiles.Any(t => t.tileId == tile.id))
            {
                _isOutdated = true;
                RedrawComposite();
            }
        }

        private void _eventBus_TileUpdated(TilesetData tileset, TileData tile)
        {
            if (tileset.id == _data.tileset && _data.tiles.Any(t => t.tileId == tile.id))
            {
                _isOutdated = true;
                RedrawComposite();
            }
        }

        #endregion

        #region ui

        private void MapPainter_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ExecutePrimaryTileAction(e.Location);
            }
            else if (e.Button == MouseButtons.Right)
            {
                ExecuteSecondaryTileAction(e.Location);
            }
        }

        private void MapPainter_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ExecutePrimaryTileAction(e.Location);
            }
        }

        private void MapPainter_MouseUp(object sender, MouseEventArgs e)
        {
            _lastTilePainted = null;
        }

        #endregion

        private void InitData()
        {
            _tileLayer = MapService.GenerateTexture(_data);
            SetMapEditorData(MapOrigin, MapSize);
        }

        internal void SetMapEditorData(Point origin, Size size)
        {
            MapOrigin = origin;
            MapSize = size;

            RedrawComposite();
        }

        private void RedrawComposite()
        {
            if (_finalComposite != null)
            {
                _finalComposite.Dispose();
            }
            _finalComposite = CreateComposite();
            Image = _finalComposite;
            Size = _finalComposite.Size;
        }

        private Bitmap CreateComposite()
        {
            var textureSize = new Size(_tileLayer.Width / 32, _tileLayer.Height / 32)
                + MapSize + new Size(MapOrigin.X, MapOrigin.Y);
            var composite = new Bitmap(textureSize.Width * 32, textureSize.Height * 32);
            var scaledOrigin = new Point(MapOrigin.X * 32, MapOrigin.Y * 32);

            using (var g = Graphics.FromImage(composite))
            {
                g.Clear(Color.Transparent);

                // draw layers
                g.DrawImage(_tileLayer, scaledOrigin);

                // draw grid
                if (_gridEnabled)
                {
                    var b = new TextureBrush(Resources.mapGrid, WrapMode.Tile);
                    g.FillRectangle(b, new Rectangle(scaledOrigin.X, scaledOrigin.Y, _tileLayer.Width, _tileLayer.Height));
                }

                // draw red rectangle around map bounds
                g.DrawRectangle(Pens.Red, new Rectangle(scaledOrigin.X, scaledOrigin.Y,
                    _tileLayer.Width - 1, _tileLayer.Height - 1));

                // draw green rectangle around entire image
                g.DrawRectangle(Pens.Green, new Rectangle(0, 0, composite.Width - 1, composite.Height - 1));

                // if the map is outdated because a tile/subtile got updated/removed, draw overlay
                if (_isOutdated)
                {
                    var b = new TextureBrush(Resources.outdatedOverlay, WrapMode.Tile);
                    g.FillRectangle(b, new Rectangle(0, 0, composite.Width, composite.Height));

                    g.DrawString("Outdated! Click to reload.", new Font("Consolas", 10f), Brushes.Red, new Point(4, 4));
                }
            }

            return composite;
        }

        private Point ScreenToMapCoordinates(Point location, bool includeBounds)
        {
            var coordinates = new Point(
                (int)Math.Floor(location.X / 32d) - MapOrigin.X,
                (int)Math.Floor(location.Y / 32d) - MapOrigin.Y
            );

            if (includeBounds)
            {
                var bounds = MapService.GetMapBounds(_data);
                if (bounds.X < 0)
                {
                    coordinates.X += bounds.X;
                }
                if (bounds.Y < 0)
                {
                    coordinates.Y += bounds.Y;
                }
            }

            return coordinates;
        }

        // returns whether or not an operation on the tile should be performed
        private bool PrepareTile(Point location)
        {
            if (!_isMapExpanded)
            {
                Optimizer.ExpandMap(_data);
            }

            // check first to not keep placing tiles on the same location
            // do not factor in the bounds of the map
            var coordinates = ScreenToMapCoordinates(location, false);
            if (_lastTilePainted.HasValue && _lastTilePainted.Value == coordinates)
            {
                return false;
            }
            _lastTilePainted = coordinates;
            return true;
        }

        private void PaintTile(Point location)
        {
            if (_selectedTile != null)
            {
                var result = PrepareTile(location);
                if (!result)
                {
                    return;
                }
                var coordinates = ScreenToMapCoordinates(location, true);

                MapService.PlaceTile(_data, new MapTileData
                {
                    pos = new[] { coordinates.X, coordinates.Y },
                    size = new[] { 1, 1 },
                    tileId = _selectedTile.id,
                });

                UpdateTile(coordinates);
                RedrawComposite();
            }
        }

        private void ClearTile(Point location)
        {
            var result = PrepareTile(location);
            if (!result)
            {
                return;
            }

            var coordinates = ScreenToMapCoordinates(location, true);
            MapService.ClearTile(_data, coordinates);

            UpdateTile(coordinates);
            RedrawComposite();
        }

        private void UpdateTile(Point location)
        {
            _tileLayer.Dispose();
            _tileLayer = MapService.GenerateTexture(_data);
            _eventBus.UpdatedMap(_data);
        }

        private void ExecutePrimaryTileAction(Point location)
        {
            switch (Mode)
            {
                case MapPainterMode.Create:
                    PaintTile(location);
                    break;
                case MapPainterMode.Erase:
                    ClearTile(location);
                    break;
                case MapPainterMode.Pick:
                    break;
                case MapPainterMode.Fill:
                    break;
            }
        }

        private void ExecuteSecondaryTileAction(Point location)
        {
            switch (Mode)
            {
                case MapPainterMode.Create:
                    ClearTile(location);
                    break;
                case MapPainterMode.Erase:
                    ClearTile(location);
                    break;
                case MapPainterMode.Pick:
                    break;
                case MapPainterMode.Fill:
                    break;
            }
        }
    }
}
