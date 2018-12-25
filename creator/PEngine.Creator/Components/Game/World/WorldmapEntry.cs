using PEngine.Common;
using PEngine.Common.Data.Maps;
using PEngine.Common.Data.World;
using PEngine.Creator.Components.Game.Maps;
using PEngine.Creator.Components.Projects;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game.World
{
    internal class WorldmapEntry : CrispPictureBox, IEventBusComponent
    {
        private static int _colorCounter = 0;

        private readonly WorldmapData _parent;
        private readonly MapData _map;
        private readonly ProjectEventBus _eventBus;
        private double _zoom;
        private ContextMenuStrip context_main;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem tool_main_view;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tool_main_remove;
        private Point _startMove;

        internal double Zoom
        {
            get => _zoom;
            set
            {
                _zoom = value;
                ResetPositioning();
            }
        }

        internal WorldmapEntryData Entry { get; }

        internal WorldmapEntry(ProjectEventBus eventBus, WorldmapData parent, WorldmapEntryData entry, double zoom)
        {
            InitializeComponent();

            _parent = parent;
            Entry = entry;
            _zoom = zoom;

            _eventBus = eventBus;
            RegisterEvents();

            var mapFile = Project.ActiveProject.GetFile(Entry.mapId);
            _map = MapData.Load(mapFile);

            Image = GenerateTexture();

            ResetPositioning();
            UpdateEntryBounds();

            _colorCounter++;
        }

        #region events

        private void RegisterEvents()
        {
            MouseDown += WorldmapEntry_MouseDown;
            MouseMove += WorldmapEntry_MouseMove;
            MouseUp += WorldmapEntry_MouseUp;
        }

        public void UnregisterEvents()
        {

        }

        private void WorldmapEntry_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _startMove = e.Location;
                _eventBus.SelectedMap(_parent, _map);
            }
        }

        private void WorldmapEntry_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var diff = new Point(e.Location.X - _startMove.X, e.Location.Y - _startMove.Y);
                var unit = 16 * Zoom;
                if (Math.Abs(diff.X) >= unit || Math.Abs(diff.Y) >= unit)
                {
                    var p = (Panel)Parent;
                    var test = p.AutoScrollPosition;

                    // x
                    {
                        var movedX = (int)(diff.X / unit);
                        var prevX = Entry.bounds[0];
                        Entry.bounds[0] = Entry.bounds[0] + movedX;
                        if (!WorldmapService.IsValidPosition(_parent, Entry))
                        {
                            Entry.bounds[0] = prevX;
                        }
                    }
                    // y
                    {
                        var movedY = (int)(diff.Y / unit);
                        var prevY = Entry.bounds[1];
                        Entry.bounds[1] = Entry.bounds[1] + movedY;
                        if (!WorldmapService.IsValidPosition(_parent, Entry))
                        {
                            Entry.bounds[1] = prevY;
                        }
                    }

                    ResetPositioning();
                }
            }
        }

        private void WorldmapEntry_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _eventBus.MovedMap(_parent, _map);
            }
        }

        #endregion

        #region ui

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.context_main = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tool_main_view = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tool_main_remove = new System.Windows.Forms.ToolStripMenuItem();
            this.context_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // context_main
            // 
            this.context_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_main_view,
            this.toolStripSeparator1,
            this.tool_main_remove});
            this.context_main.Name = "contextMenuStrip1";
            this.context_main.Size = new System.Drawing.Size(127, 54);
            // 
            // tool_main_view
            // 
            this.tool_main_view.Name = "tool_main_view";
            this.tool_main_view.Size = new System.Drawing.Size(126, 22);
            this.tool_main_view.Text = "View Map";
            this.tool_main_view.Click += Tool_main_view_Click;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(123, 6);
            // 
            // tool_main_remove
            // 
            this.tool_main_remove.Image = global::PEngine.Creator.Properties.Resources.Clearallrequests_8816;
            this.tool_main_remove.Name = "tool_main_remove";
            this.tool_main_remove.Size = new System.Drawing.Size(126, 22);
            this.tool_main_remove.Text = "Remove";
            this.tool_main_remove.Click += Tool_main_remove_Click;
            // 
            // WorldmapEntry
            // 
            this.ContextMenuStrip = this.context_main;
            this.context_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void Tool_main_remove_Click(object sender, EventArgs e)
        {
            WorldmapService.RemoveEntry(_parent, Entry);
            _eventBus.RemovedWorldmapEntry(_parent, Entry);
        }

        private void Tool_main_view_Click(object sender, EventArgs e)
        {
            var file = Project.ActiveProject.GetFile(_map.id);
            _eventBus.RequestFileOpen(file);
        }

        #endregion

        internal void ResetPositioning()
        {
            Size = new Size((int)(Image.Width * Zoom), (int)(Image.Height * Zoom));

            var offset = Point.Empty;
            if (Parent is Panel container)
            {
                offset = container.AutoScrollPosition;
            }
            Location = new Point((int)(Entry.bounds[0] * Zoom * 16 + offset.X),
                (int)(Entry.bounds[1] * Zoom * 16 + offset.Y));
        }

        internal void UpdateEntryBounds()
        {
            Entry.bounds[2] = Image.Width / 16;
            Entry.bounds[3] = Image.Height / 16;
        }

        private Bitmap GenerateTexture()
        {
            var baseTexture = MapService.GenerateTexture(_map);
            using (var g = Graphics.FromImage(baseTexture))
            {
                var p = new Pen(GetColoredPen().Brush, 10);
                g.DrawRectangle(p,
                    new Rectangle(0, 0,
                        baseTexture.Width - 1,
                        baseTexture.Height - 1));
            }
            return baseTexture;
        }

        private static Pen GetColoredPen()
        {
            switch (_colorCounter % 16)
            {
                case 0:
                case 8:
                    return Pens.Yellow;
                case 1:
                case 9:
                    return Pens.Red;
                case 2:
                case 10:
                    return Pens.Green;
                case 3:
                case 11:
                    return Pens.Blue;
                case 4:
                case 12:
                    return Pens.Purple;
                case 5:
                case 13:
                    return Pens.LimeGreen;
                case 6:
                case 14:
                    return Pens.Silver;
                case 7:
                case 15:
                    return Pens.Brown;
            }
            // fallback
            return Pens.Black;
        }
    }
}
