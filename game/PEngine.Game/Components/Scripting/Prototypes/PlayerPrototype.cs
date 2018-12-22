using Kolben.Adapters;

namespace PEngine.Game.Components.Scripting.Prototypes
{
    [ScriptPrototype(VariableName = "Player")]
    internal sealed class PlayerPrototype
    {
        [ScriptFunction(ScriptFunctionType.Getter, VariableName = "walk", IsStatic = true)]
        public static object Walk(object This, ScriptObjectLink objLink, object[] parameters)
        {
            return 1;
        }
    }
}
