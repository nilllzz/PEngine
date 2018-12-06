using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PEngine.Game.Content;
using static Core;

namespace PEngine.Game.Components.World.Entities
{
    abstract class Character : Entity
    {
        private const int WALK_CYCLE_DELAY = 9;
        private static int[] WALK_CYCLE_FRAMES = new[] { 0, 1, 0, 2 };

        protected bool _walking = false;
        protected int _walkCycleFrame = 0;
        private int _walkCycleDelay = WALK_CYCLE_DELAY;

        public CharacterFacing Facing { get; set; }

        protected Character(Map map)
            : base(map)
        { }

        protected void LoadTexture(string characterTextureFile)
        {
            _texture = Controller.ProjectContent
                .LoadDirect<Texture2D>($"textures/characters/{characterTextureFile}.png");
        }

        protected override Rectangle GetTextureRectangle()
        {
            return new Rectangle(WALK_CYCLE_FRAMES[_walkCycleFrame] * ENTITY_SIZE,
                ((int)Facing) * ENTITY_SIZE,
                ENTITY_SIZE,
                ENTITY_SIZE);
        }

        public override void Update()
        {
            if (_walking)
            {
                _walkCycleDelay--;
                if (_walkCycleDelay == 0)
                {
                    _walkCycleDelay = WALK_CYCLE_DELAY;
                    _walkCycleFrame++;
                    if (_walkCycleFrame == WALK_CYCLE_FRAMES.Length)
                    {
                        _walkCycleFrame = 0;
                    }
                }
            }
            else
            {
                _walkCycleFrame = 0;
            }
        }
    }
}
