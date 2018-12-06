namespace PEngine.Game.Components.World.Entities
{
    class NPC : Character
    {
        public NPC(Map map)
            : base(map)
        {
            Facing = CharacterFacing.Down;
        }

        public override void LoadContent()
        {
            LoadTexture("npc01");
        }
    }
}
