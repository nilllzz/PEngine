using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Projects;
using PEngine.Creator.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game
{
    internal partial class SubtileEditComponent : UserControl, IEventBusComponent
    {
        private readonly ProjectEventBus _eventBus;
        private readonly TilesetData _parent;
        private readonly SubtileData _data;

        private bool _stopEvents = false;

        internal SubtileEditComponent(ProjectEventBus eventBus, TilesetData parent, SubtileData data)
        {
            InitializeComponent();

            _parent = parent;
            _data = data;

            _eventBus = eventBus;
            RegisterEvents();

            LoadBehaviors();
            InitData();
        }

        #region events

        private void RegisterEvents()
        {
            _eventBus.SubtileUpdated += _eventBus_SubtileUpdated;
        }

        public void UnregisterEvents()
        {
            _eventBus.SubtileUpdated -= _eventBus_SubtileUpdated;
        }

        private void _eventBus_SubtileUpdated(TilesetData tileset, SubtileData subtile)
        {
            if (tileset.id == _parent.id)
            {
                InitData();
            }
        }

        #endregion

        #region ui

        private void combo_behavior_SelectedIndexChanged(object sender, EventArgs e)
        {
            var behavior = DataHelper.ParseEnum<SubtileBehavior>(combo_behavior.SelectedItem.ToString());
            _data.behavior = DataHelper.UnparseEnum(behavior);

            if (!_stopEvents)
            {
                _eventBus.UpdatedSubtile(_parent, _data);
            }
        }

        private void pic_pick_texture_Click(object sender, EventArgs e)
        {
            var textureFile = Project.ActiveProject.GetFile(_parent.texture, ProjectFileType.TextureTileset);
            var texturePicker = new TexturePickerForm
            {
                TexturePath = ResourceManager.GetFilePath(textureFile),
                SelectedTextureRectangle = new Rectangle(_data.texture[0] * 16, _data.texture[1] * 16, 16, 16),
            };

            var result = texturePicker.ShowDialog(MainForm.Instance);
            if (result == DialogResult.OK)
            {
                var textureRect = texturePicker.SelectedTextureRectangle;
                _data.texture = new[] { textureRect.X / 16, textureRect.Y / 16 };
                _eventBus.UpdatedSubtile(_parent, _data);
            }
        }

        #endregion

        private void InitData()
        {
            _stopEvents = true;
            pic_texture.Image = ResourceManager.GetSubtileTexture(_parent, _data);
            var comboValue = DataHelper.ParseEnum<SubtileBehavior>(_data.behavior).ToString();
            if (combo_behavior.SelectedItem == null ||
                comboValue != combo_behavior.SelectedItem.ToString())
            {
                combo_behavior.SelectedItem = comboValue;
            }
            _stopEvents = false;
        }

        private void LoadBehaviors()
        {
            var behaviors = Enum.GetNames(typeof(SubtileBehavior));
            combo_behavior.Items.AddRange(behaviors);
        }
    }
}
