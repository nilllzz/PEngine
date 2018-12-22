using System;

namespace PEngine.Game.Components.Scripting.ApiClasses
{
    internal class ApiClassAttribute : Attribute
    {
        public string ClassName { get; }

        public ApiClassAttribute(string className)
        {
            ClassName = className;
        }
    }
}
