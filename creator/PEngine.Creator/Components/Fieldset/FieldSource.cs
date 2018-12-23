using System;
using System.Reflection;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Fieldset
{
    internal class FieldSource<T>
    {
        private string _field;
        private IFieldSet _fieldset;
        private FieldInfo _backingField;
        private Timer _timer;
        private T _currentValue;
        private T _originalValue;

        internal object Source { get; }
        internal string Field
        {
            get => _field;
            set
            {
                _field = value;
                Initialize();
            }
        }
        internal bool HasChanges => !(_currentValue?.Equals(_originalValue) ?? true);

        internal event Action<T> FieldChanged;

        internal FieldSource(IFieldSet fieldset, object source, string field, bool watch)
        {
            Source = source;
            _fieldset = fieldset;
            _field = field;

            if (watch)
            {
                _timer = new Timer();
                _timer.Interval = 1000;
                _timer.Tick += _timer_Tick;
            }

            Initialize();
        }

        private void Initialize()
        {
            _backingField = Source.GetType().GetField(Field, BindingFlags.Public | BindingFlags.Instance);
            _originalValue = GetValue();
            _currentValue = _originalValue;
        }

        internal void SetValue(T value)
        {
            _timer?.Stop();
            _backingField.SetValue(Source, value);
            _currentValue = value;
            if (HasChanges)
            {
                _fieldset.SetHasChanges(true);
            }
            FieldChanged?.Invoke(value);
            _timer?.Start();
        }

        internal T GetValue()
        {
            return (T)_backingField.GetValue(Source);
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            var currentValue = (T)_backingField.GetValue(Source);
            if (!currentValue.Equals(_currentValue))
            {
                SetValue(currentValue);
            }
        }
    }
}
