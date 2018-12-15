using PEngine.Common.Data.Maps;

namespace PEngine.Game.Components.World.Entities
{
    internal class NPC : Character
    {
        internal NPC(Map map)
            : base(map)
        {
            Facing = ObjectRotation.Down;
        }

        internal override void LoadContent()
        {
            LoadTexture("npc01");
        }
    }
}
