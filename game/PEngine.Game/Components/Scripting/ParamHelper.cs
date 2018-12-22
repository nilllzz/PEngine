using Microsoft.Xna.Framework;

namespace PEngine.Game.Components.Scripting
{
    internal class ParamHelper
    {
        private object[] _parameters;
        private int _index = 0;

        public ParamHelper(object[] parameters)
        {
            _parameters = parameters;
        }

        public T Pop<T>(T defaultValue = default(T))
        {
            if (HasEnded())
            {
                return defaultValue;
            }

            var result = defaultValue;
            if (_parameters[_index] != null)
            {
                result = (T)_parameters[_index];
            }

            _index++;
            return result;
        }

        public void Skip(int steps = 1)
        {
            _index = MathHelper.Clamp(_index + steps, 0, _parameters.Length);
        }

        private bool HasEnded()
        {
            return _index == _parameters.Length;
        }

        public int GetStackSize()
        {
            return _parameters.Length - _index;
        }
    }
}
