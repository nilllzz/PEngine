using PEngine.Common.Data;
using PEngine.Common.Data.Monsters;
using PEngine.Creator.Components.Fieldset;
using PEngine.Creator.Components.Projects;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game.Monsters
{
    internal partial class MonsterEditor : ProjectTabComponent, IEventBusComponent, IFieldSet
    {
        private readonly MonsterData _data;
        private bool _isFrontView = true;

        internal MonsterEditor(ProjectEventBus eventBus, ProjectFileData file, MonsterData data)
            : base(eventBus, file)
        {
            InitializeComponent();

            _data = data;

            RegisterEvents();

            InitData();
        }

        #region events

        private void RegisterEvents()
        {

        }

        public void UnregisterEvents()
        {

        }

        #endregion

        #region ui

        private void btn_switch_view_Click(object sender, System.EventArgs e)
        {
            _isFrontView = !_isFrontView;
            UpdateImage();
        }

        private void enum_gender_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var male = 0m;

            switch (_data.GenderRatio)
            {
                case MonsterGenderNominalRatio.Male:
                    male = 1;
                    break;
                case MonsterGenderNominalRatio.MostlyMale:
                    male = 0.875m;
                    break;
                case MonsterGenderNominalRatio.OftenMale:
                    male = 0.75m;
                    break;
                case MonsterGenderNominalRatio.Equal:
                    male = 0.5m;
                    break;
                case MonsterGenderNominalRatio.OftenFemale:
                    male = 0.25m;
                    break;
                case MonsterGenderNominalRatio.Female:
                    male = 0.125m;
                    break;
            }

            var female = 1 - male;
            if (_data.GenderRatio == MonsterGenderNominalRatio.Genderless)
            {
                female = 0;
            }

            lbl_gender_expl.Text = $"M: {(male * 100).ToString("0.0")}% F: {(female * 100).ToString("0.0")}%";
        }

        #endregion

        private void InitData()
        {
            lbl_name.Text = _data.name;
            lbl_number.Text = "# " + _data.number.ToString().PadLeft(3, '0');

            txt_name.FieldSource = new FieldSource<string>(this, _data, "name", false);
            num_number.FieldSource = new FieldSource<int>(this, _data, "number", false);

            enum_gender.EnumType = typeof(MonsterGenderNominalRatio);
            enum_gender.FieldSource = new FieldSource<string>(this, _data, "gender", false);

            enum_type1.EnumType = typeof(MonsterType);
            enum_type1.FieldSource = new FieldSource<string>(this, _data, "type1", false);

            enum_type2.EnumType = typeof(MonsterType);
            enum_type2.FieldSource = new FieldSource<string>(this, _data, "type2", false);
        }

        private void UpdateImage()
        {
            pic_monster.Invalidate();
        }

        private void pic_monster_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            using (var texture = MonsterService.GetTexture(_data, _isFrontView))
            {
                var maps = new ColorMap[4];
                var placeholderColors = MonsterService.GetPlaceholderColors(texture);
                var paletteColors = _data.palette.normal.Select(n => Color.FromArgb(n[0], n[1], n[2])).ToArray();
                for (var i = 0; i < maps.Length; i++)
                {
                    maps[i] = new ColorMap
                    {
                        OldColor = placeholderColors[i],
                        NewColor = paletteColors[i]
                    };
                }

                var attr = new ImageAttributes();
                attr.SetRemapTable(maps);
                var rect = new Rectangle(0, 0, pic_monster.Width, pic_monster.Height);
                g.DrawImage(texture, rect, 0, 0, texture.Width, texture.Height, GraphicsUnit.Pixel, attr);
            }
        }

        public void SetHasChanges(bool state)
        {
            HasChanges = state;
        }

        internal override void Save()
        {
            _data.Save();
            HasChanges = false;
            InitData();
        }
    }
}
