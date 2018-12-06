using PEngine.Game.Screens.World;
using System;

namespace PEngine.Game.Components.World.Entities
{
    class PlayerEntity : Character
    {
        private const float WALK_SPEED = 0.05f;
        private float _walkDistance = 0f;

        public PlayerEntity(Map map)
            : base(map)
        {
            Facing = CharacterFacing.Down;
            _spriteLayer = WorldScreen.SPRITE_LAYER_PLAYER;
        }

        public override void LoadContent()
        {
            LoadTexture("player");
        }

        public override void Update()
        {
            if (_walking)
            {
                _walkDistance -= WALK_SPEED;
                if (_walkDistance <= 0f)
                {
                    _walkDistance = 0f;
                    _walking = false;
                    switch (Facing)
                    {
                        case CharacterFacing.Up:
                        case CharacterFacing.Down:
                            Position.Y = (float)Math.Round(Position.Y);
                            break;
                        case CharacterFacing.Left:
                        case CharacterFacing.Right:
                            Position.X = (float)Math.Round(Position.X);
                            break;
                    }
                }
                else
                {
                    switch (Facing)
                    {
                        case CharacterFacing.Up:
                            Position.Y -= WALK_SPEED;
                            break;
                        case CharacterFacing.Left:
                            Position.X -= WALK_SPEED;
                            break;
                        case CharacterFacing.Down:
                            Position.Y += WALK_SPEED;
                            break;
                        case CharacterFacing.Right:
                            Position.X += WALK_SPEED;
                            break;
                    }
                }
            }

            if (!_walking)
            {
                CharacterFacing? facing = null;
                if (GameboyInputs.DownDown())
                {
                    facing = CharacterFacing.Down;
                }
                else if (GameboyInputs.UpDown())
                {
                    facing = CharacterFacing.Up;
                }
                if (GameboyInputs.LeftDown())
                {
                    facing = CharacterFacing.Left;
                }
                else if (GameboyInputs.RightDown())
                {
                    facing = CharacterFacing.Right;
                }
                if (facing.HasValue)
                {
                    if (facing.Value != Facing)
                    {
                        Facing = facing.Value;
                    }
                    else
                    {
                        _walking = true;
                        _walkDistance = 1f;
                    }
                }
            }

            base.Update();
        }
    }
}
