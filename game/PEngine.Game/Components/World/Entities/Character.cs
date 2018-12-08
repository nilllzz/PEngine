using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PEngine.Common.Data.Maps;
using PEngine.Game.Content;
using static Core;

namespace PEngine.Game.Components.World.Entities
{
    internal abstract class Character : Entity
    {
        private const int WALK_CYCLE_DELAY = 9;
        private static int[] WALK_CYCLE_FRAMES = new[] { 0, 1, 0, 2 };

        protected bool _walking = false;
        protected int _walkCycleFrame = 0;
        private int _walkCycleDelay = WALK_CYCLE_DELAY;

        internal CharacterFacing Facing { get; set; }

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

        internal override void Update()
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

        protected bool CanWalk()
        {
            // TODO: check for entities
            // TODO: multiple maps
            var checkPos = Position;
            switch (Facing)
            {
                case CharacterFacing.Up:
                    checkPos += new Double2D(0, -1);
                    break;
                case CharacterFacing.Left:
                    checkPos += new Double2D(-1, 0);
                    break;
                case CharacterFacing.Down:
                    checkPos += new Double2D(0, 1);
                    break;
                case CharacterFacing.Right:
                    checkPos += new Double2D(1, 0);
                    break;
            }
            var tile = _map.GetSubtileInfo(checkPos);
            if (tile.HasValue)
            {
                if (tile.Value.Behavior == SubtileBehavior.Floor ||
                    tile.Value.Behavior == SubtileBehavior.Grass)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
