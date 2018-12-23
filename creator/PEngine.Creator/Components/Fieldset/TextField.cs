using System;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Fieldset
{
    internal class TextField : TextBox
    {
        private FieldSource<string> _source;
        private bool _raiseChanged = true;

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
                    Text = _source.GetValue();
                    _raiseChanged = true;
                    _source.FieldChanged += _source_FieldChanged;
                }
            }
        }

        public TextField()
        {
            TextChanged += TextField_TextChanged;
        }

        private void TextField_TextChanged(object sender, EventArgs e)
        {
            if (_raiseChanged)
            {
                FieldSource?.SetValue(Text);
            }
        }

        private void _source_FieldChanged(string text)
        {
            if (text != Text)
            {
                _raiseChanged = false;
                Text = text;
                _raiseChanged = true;
            }
        }
    }
}
