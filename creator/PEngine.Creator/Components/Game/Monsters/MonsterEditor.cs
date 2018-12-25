using PEngine.Common.Data;
using PEngine.Common.Data.Monsters;
using PEngine.Creator.Components.Fieldset;
using PEngine.Creator.Components.Projects;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game.Monsters
{
    internal partial class MonsterEditor : ProjectTabComponent, IEventBusComponent, IFieldSet
    {
        private readonly MonsterData _data;
        private DexData _dex;
        private DexEntryData _dexEntry;
        private bool _isFrontView = true;
        private bool _triggerChanged = false;

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
            _dex = MonsterService.GetDex();
            _dexEntry = MonsterService.GetOrCreateDexEntry(_dex, _data, out var created);
            if (created)
            {
                HasChanges = true;
            }

            _triggerChanged = false;

            // --- header ---
            lbl_name.Text = _data.name;
            lbl_number.Text = "# " + _data.number.ToString().PadLeft(3, '0');

            // --- info page ---
            txt_name.FieldSource = new FieldSource<string>(this, _data, "name", false);
            num_number.FieldSource = new FieldSource<int>(this, _data, "number", false);
            enum_gender.EnumType = typeof(MonsterGenderNominalRatio);
            enum_gender.FieldSource = new FieldSource<string>(this, _data, "gender", false);

            enum_type1.EnumType = typeof(MonsterType);
            enum_type1.FieldSource = new FieldSource<string>(this, _data, "type1", false);
            enum_type2.EnumType = typeof(MonsterType);
            enum_type2.FieldSource = new FieldSource<string>(this, _data, "type2", false);

            enum_exp_type.EnumType = typeof(ExperienceType);
            enum_exp_type.FieldSource = new FieldSource<string>(this, _data, "experienceType", false);
            num_exp_yield.FieldSource = new FieldSource<int>(this, _data, "experienceYield", false);

            num_catchrate.FieldSource = new FieldSource<int>(this, _data, "catchRate", false);
            num_fleerate.FieldSource = new FieldSource<decimal>(this, _data, "wildFleeRate", false);

            // --- dex page ---
            num_regional_number.FieldSource = new FieldSource<int>(this, _dexEntry, "regionalNumber", false);
            txt_species.FieldSource = new FieldSource<string>(this, _dexEntry, "species", false);
            num_height.FieldSource = new FieldSource<decimal>(this, _dexEntry, "height", false);
            num_weight.FieldSource = new FieldSource<decimal>(this, _dexEntry, "weight", false);

            // dex text
            var dexTextLines = _dexEntry.text
                .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            while (dexTextLines.Count < 6)
            {
                dexTextLines.Add("PUT TEXT HERE");
            }
            txt_dextext_page1_line1.Text = dexTextLines[0];
            txt_dextext_page1_line2.Text = dexTextLines[1];
            txt_dextext_page1_line3.Text = dexTextLines[2];
            txt_dextext_page2_line1.Text = dexTextLines[3];
            txt_dextext_page2_line2.Text = dexTextLines[4];
            txt_dextext_page2_line3.Text = dexTextLines[5];

            _triggerChanged = true;
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
            _dex.Save();
            HasChanges = false;
            InitData();
        }

        private void dextext_changed(object sender, EventArgs e)
        {
            var compiledText = txt_dextext_page1_line1.Text + "\n" +
                txt_dextext_page1_line2.Text + "\n" +
                txt_dextext_page1_line3.Text + "\n\n" +
                txt_dextext_page2_line1.Text + "\n" +
                txt_dextext_page2_line2.Text + "\n" +
                txt_dextext_page2_line3.Text;

            if (_dexEntry.text != compiledText && _triggerChanged)
            {
                _dexEntry.text = compiledText;
                HasChanges = true;
            }
        }
    }
}
