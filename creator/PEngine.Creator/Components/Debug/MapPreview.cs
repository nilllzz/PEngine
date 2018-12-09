using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Common.Interop;
using PEngine.Creator.Components.Game;
using PEngine.Creator.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Debug
{
    internal partial class MapPreview : BaseDebugComponent
    {
        private string _id;
        private ProjectFileData _file;
        private TransparentControl _playerControl;
        private PictureBox _mapControl;
        private bool _isPlayerPositionMode = false;

        internal MapPreview()
        {
            InitializeComponent();
        }

        internal override void HandlePipelineEvent(PipelineMessage message)
        {
            switch (message.Event)
            {
                case Pipeline.EVENT_SET_MAP:
                    LoadMap(message.Content);
                    break;
                case Pipeline.EVENT_PLAYER_MOVED:
                    var coordinates = message.Content.Split(',').Select(c => int.Parse(c)).ToArray();
                    SetPlayerPosition(new Point(coordinates[0], coordinates[1]));
                    break;
            }
        }

        internal override void DebuggingStopped()
        {
            tool_map_pick_player_pos.Enabled = false;
        }

        private void LoadMap(string id)
        {
            _id = id;
            _file = Project.ActiveProject.GetFile(id, ProjectFileType.Map);

            panel_container.Controls.Clear();
            _playerControl = null;
            var map = GenerateMapBitmap();
            _mapControl = new PictureBox
            {
                Image = map,
                Width = map.Width,
                Height = map.Height,
                Location = new Point(0, 0)
            };
            _mapControl.MouseClick += Map_MouseClick;
            panel_container.Controls.Add(_mapControl);
        }

        private void SetPlayerPosition(Point p)
        {
            if (_playerControl == null)
            {
                _playerControl = new TransparentControl
                {
                    Image = Resources.player,
                    Size = new Size(16, 16),
                    Location = new Point(0, 0),
                };
                panel_container.Controls.Add(_playerControl);
            }
            _playerControl.Location = new Point(p.X * 16 + panel_container.AutoScrollPosition.X,
                p.Y * 16 + panel_container.AutoScrollPosition.Y);
            _playerControl.BringToFront();
            tool_map_player_pos.Text = "{" + p.X.ToString() + ", " + p.Y.ToString() + "}";
        }

        private Bitmap GenerateMapBitmap()
        {
            // load resources
            var data = MapData.Load(_file.path);
            var tilesetFile = Project.ActiveProject.GetFile(data.tileset, ProjectFileType.Tileset);
            var tileset = TilesetData.Load(tilesetFile.path);
            var texture = ResourceManager.GetTilesetTexture(tileset);

            // generate map
            var maxX = data.tiles.Max(t => t.pos[0] + t.size[0] - 1);
            var maxY = data.tiles.Max(t => t.pos[1] + t.size[1] - 1);

            var map = new Bitmap(maxX * 32, maxY * 32);
            var g = Graphics.FromImage(map);

            foreach (var tile in data.tiles)
            {
                var tileData = tileset.tiles.First(t => t.id == tile.tileId);
                for (var y = 0; y < tile.size[1]; y++)
                {
                    for (var x = 0; x < tile.size[0]; x++)
                    {
                        var tilePosX = (tile.pos[0] + x) * 32;
                        var tilePosY = (tile.pos[1] + y) * 32;

                        for (var i = 0; i < tileData.subtiles.Length; i++)
                        {
                            var subtileId = tileData.subtiles[i];
                            var subtileData = tileset.subtiles.First(t => t.id == subtileId);

                            var subtileOffsetX = i % 2 * 16;
                            var subtileOffsetY = i > 1 ? 16 : 0;

                            g.DrawImage(texture, new Rectangle(
                                tilePosX + subtileOffsetX,
                                tilePosY + subtileOffsetY,
                                16, 16), new Rectangle(
                                subtileData.texture[0] * 16,
                                subtileData.texture[1] * 16,
                                16, 16), GraphicsUnit.Pixel);
                        }
                    }
                }
            }

            return map;
        }

        private void Map_MouseClick(object sender, MouseEventArgs e)
        {
            if (_isPlayerPositionMode)
            {
                _isPlayerPositionMode = false;
                tool_map_pick_player_pos.Checked = false;
                _mapControl.Cursor = Cursors.Default;

                var x = e.Location.X - panel_container.AutoScrollPosition.X;
                var y = e.Location.Y - panel_container.AutoScrollPosition.Y;

                var posX = (int)Math.Floor(e.Location.X / 16d);
                var posY = (int)Math.Floor(e.Location.Y / 16d);

                _process.Pipeline.Write(Pipeline.EVENT_PLAYER_MOVED, posX + "," + posY);
            }
        }

        private void tool_map_pick_player_pos_Click(object sender, EventArgs e)
        {
            _isPlayerPositionMode = true;
            _mapControl.Cursor = Cursors.Hand;
            tool_map_pick_player_pos.Checked = true;
        }
    }
}
