using PEngine.Common.Data;
using System;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Fieldset
{
    internal class EnumField : ComboBox
    {
        private FieldSource<string> _source;
        private bool _raiseChanged = true;
        private Type _enumType;

        public FieldSource<string> FieldSource
        {
            get => _source;
            set
            {
                if (_source != null)
                {
                    _source.FieldChanged -= _source_FieldChanged;
                }
                _source = value;
                if (_source != null)
                {
                    _raiseChanged = false;
                    SetSelected(_source.GetValue());
                    _raiseChanged = true;
                    _source.FieldChanged += _source_FieldChanged;
                }
            }
        }

        public Type EnumType
        {
            get => _enumType;
            set
            {
                _enumType = value;

                Items.Clear();
                if (_enumType != null)
                {
                    var values = Enum.GetValues(_enumType);
                    foreach (var v in values)
                    {
                        Items.Add(v.ToString());
                    }
                }
            }
        }

        public EnumField()
        {
            DropDownStyle = ComboBoxStyle.DropDownList;
            SelectedIndexChanged += EnumField_SelectedIndexChanged;
        }

        private void EnumField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_raiseChanged)
            {
                var value = DataHelper.UnparseEnum(SelectedItem.ToString());
                FieldSource?.SetValue(value);
            }
        }

        private void _source_FieldChanged(string value)
        {
            if (value != DataHelper.UnparseEnum(SelectedItem.ToString()))
            {
                _raiseChanged = false;
                SetSelected(value);
                _raiseChanged = true;
            }
        }

        private void SetSelected(string value)
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (DataHelper.UnparseEnum(Items[i]) == value)
                {
                    SelectedIndex = i;
                    return;
                }
            }
        }
    }
}
