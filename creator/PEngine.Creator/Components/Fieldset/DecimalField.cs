using System;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Fieldset
{
    internal class DecimalField : NumericUpDown
    {
        private FieldSource<decimal> _source;
        private bool _raiseChanged = true;

        public FieldSource<decimal> FieldSource
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
                    Value = _source.GetValue();
                    _raiseChanged = true;
                    _source.FieldChanged += _source_FieldChanged;
                }
            }
        }

        public DecimalField()
        {
            ValueChanged += NumberField_ValueChanged;
        }

        private void NumberField_ValueChanged(object sender, EventArgs e)
        {
            if (_raiseChanged)
            {
                FieldSource?.SetValue(Value);
            }
        }

        private void _source_FieldChanged(decimal number)
        {
            if (number != Value)
            {
                _raiseChanged = false;
                Value = number;
                _raiseChanged = true;
            }
        }
    }
}
