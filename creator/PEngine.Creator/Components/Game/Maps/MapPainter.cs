using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Projects;
using PEngine.Creator.Properties;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game.Maps
{
    internal partial class MapPainter : PictureBox, IEventBusComponent
    {
        private const int TILE_SIZE = 32;
        private const int EVENT_SIZE = 16;

        private readonly ProjectEventBus _eventBus;
        private readonly MapData _data;

        private Bitmap _tileLayer;
        private Bitmap _finalComposite;
        private TileData _selectedTile;
        private Point? _lastTilePainted = null;
        private bool _isMapExpanded = false;
        private bool _isOutdated = false;
        private bool _gridEnabled = false;
        private MapEditorLayer _activeLayer;
        private MapEventData _movingEvent;
        private MapEventType _activeEventType = MapEventType.Warp;

        internal Size MapSize { get; private set; }
        internal Point MapOrigin { get; private set; }
        internal MapPainterMode Mode { get; set; } = MapPainterMode.Create;
        internal MapEditorLayer ActiveLayer
        {
            get => _activeLayer;
            set
            {
                _activeLayer = value;
                RedrawComposite();
            }
        }
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
            _eventBus.EventTypeChanged += _eventBus_EventTypeChanged;
        }

        private void _eventBus_EventTypeChanged(MapData map, MapEventType eventType)
        {
            if (map.id == _data.id)
            {
                _activeEventType = eventType;
            }
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
            switch (ActiveLayer)
            {
                case MapEditorLayer.Tiles:
                    if (e.Button == MouseButtons.Left)
                    {
                        ExecutePrimaryTileAction(e.Location);
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        ExecuteSecondaryTileAction(e.Location);
                    }
                    break;
                case MapEditorLayer.Objects:
                    break;
                case MapEditorLayer.Events:
                    if (e.Button == MouseButtons.Left)
                    {
                        _movingEvent = TryPlaceEvent(e.Location);
                        if (_movingEvent != null)
                        {
                            _eventBus.SelectEvent(_data, _movingEvent);
                        }
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        TryClearEvent(e.Location);
                    }
                    break;
            }
        }

        private void MapPainter_MouseMove(object sender, MouseEventArgs e)
        {
            switch (ActiveLayer)
            {
                case MapEditorLayer.Tiles:
                    if (e.Button == MouseButtons.Left)
                    {
                        ExecutePrimaryTileAction(e.Location);
                    }
                    break;
                case MapEditorLayer.Objects:
                    break;
                case MapEditorLayer.Events:
                    if (e.Button == MouseButtons.Left && _movingEvent != null)
                    {
                        TryMoveEvent(e.Location);
                    }
                    break;
            }
        }

        private void MapPainter_MouseUp(object sender, MouseEventArgs e)
        {
            _movingEvent = null;
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

                // draw tiles
                g.DrawImage(_tileLayer, scaledOrigin);
                // draw events
                if (ActiveLayer == MapEditorLayer.Events)
                {
                    foreach (var mapEvent in _data.events)
                    {
                        var eventTex = MapService.GetEventTexture(mapEvent.EventType);
                        g.DrawImage(eventTex, new Rectangle(
                            mapEvent.pos[0] * EVENT_SIZE + scaledOrigin.X,
                            mapEvent.pos[1] * EVENT_SIZE + scaledOrigin.Y,
                            EVENT_SIZE,
                            EVENT_SIZE));
                    }
                }

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

        private Point ScreenToMapCoordinates(Point location, bool includeBounds, double scale)
        {
            const int originMultiplier = 32;
            var originNormal = originMultiplier / scale;

            var coordinates = new Point(
                (int)(Math.Floor(location.X / scale) - MapOrigin.X * originNormal),
                (int)(Math.Floor(location.Y / scale) - MapOrigin.Y * originNormal)
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
            var coordinates = ScreenToMapCoordinates(location, false, TILE_SIZE);
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
                var coordinates = ScreenToMapCoordinates(location, true, TILE_SIZE);

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

            var coordinates = ScreenToMapCoordinates(location, true, TILE_SIZE);
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

        private MapEventData TryPlaceEvent(Point location)
        {
            var mapLocation = ScreenToMapCoordinates(location, true, EVENT_SIZE);
            var existingEvent = _data.events.FirstOrDefault(e => e.pos[0] == mapLocation.X && e.pos[1] == mapLocation.Y);

            // if there is no event at the targeted place, create a new one
            if (existingEvent == null)
            {
                var newEvent = new MapEventData
                {
                    name = $"{_activeEventType.ToString()} Event " +
                        _data.events.Count(e => e.EventType == _activeEventType),
                    pos = new[] { mapLocation.X, mapLocation.Y },
                    target = null,
                    type = DataHelper.UnparseEnum(_activeEventType),
                };
                MapService.PlaceEvent(_data, newEvent);

                _eventBus.AddedEvent(_data, newEvent);
                _eventBus.SelectEvent(_data, newEvent);
                _eventBus.UpdatedMap(_data);

                RedrawComposite();
            }

            return existingEvent;
        }

        private void TryMoveEvent(Point location)
        {
            var mapLocation = ScreenToMapCoordinates(location, true, EVENT_SIZE);
            if (mapLocation.X != _movingEvent.pos[0] || mapLocation.Y != _movingEvent.pos[1])
            {
                _movingEvent.pos = new[] { mapLocation.X, mapLocation.Y };
                _eventBus.UpdatedMap(_data);

                RedrawComposite();
            }
        }

        private void TryClearEvent(Point location)
        {
            var mapLocation = ScreenToMapCoordinates(location, true, EVENT_SIZE);
            var existingEvent = _data.events.FirstOrDefault(e => e.pos[0] == mapLocation.X && e.pos[1] == mapLocation.Y);

            if (existingEvent != null)
            {
                MapService.ClearEvent(_data, existingEvent);

                _eventBus.RemovedEvent(_data, existingEvent);
                _eventBus.UpdatedMap(_data);

                RedrawComposite();
            }
        }
    }
}
