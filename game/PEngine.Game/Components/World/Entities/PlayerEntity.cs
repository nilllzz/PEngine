using PEngine.Common.Interop;
using PEngine.Game.Screens.World;
using System;
using System.Linq;
using static Core;

namespace PEngine.Game.Components.World.Entities
{
    internal class PlayerEntity : Character
    {
        private const float WALK_SPEED = 0.05f;
        private const float BLOCKED_SPEED = 0.1f;

        private float _walkDistance = 0f;
        private bool _isBlocked = false;
        private float _blockedTime = 0f;

        internal PlayerEntity(Map map)
            : base(map)
        {
            Facing = CharacterFacing.Down;
            _spriteLayer = WorldScreen.SPRITE_LAYER_PLAYER;

            Controller.StdIn.PipelineItemArrived += StdIn_PipelineItemArrived;
        }

        private void StdIn_PipelineItemArrived(PipelineMessage message)
        {
            if (message.Event == Pipeline.EVENT_PLAYER_MOVED)
            {
                var coordinates = message.Content.Split(',').Select(c => int.Parse(c)).ToArray();
                Position = new Double2D(coordinates[0], coordinates[1]);
                Facing = CharacterFacing.Down;
                Controller.Pipeline.Write(Pipeline.EVENT_PLAYER_MOVED, (int)Position.X + "," + (int)Position.Y);
            }
        }

        internal override void LoadContent()
        {
            LoadTexture("player");
        }

        internal override void Update()
        {
            if (_isBlocked)
            {
                _blockedTime -= BLOCKED_SPEED;
                if (_blockedTime <= 0f)
                {
                    _blockedTime = 0f;
                    _isBlocked = false;
                }
                else
                {
                    return;
                }
            }

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

                    Controller.Pipeline.Write(Pipeline.EVENT_PLAYER_MOVED, (int)Position.X + "," + (int)Position.Y);
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
                        if (CanWalk())
                        {
                            _walking = true;
                            _walkDistance = 1f;
                        }
                        else
                        {
                            _isBlocked = true;
                            _blockedTime = 1f;
                        }
                    }
                }
            }

            base.Update();
        }
    }
}
