using PEngine.Common.Data.Maps;
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

        internal PlayerEntity()
            : base(null)
        {
            Facing = ObjectRotation.Down;
            _spriteLayer = WorldScreen.SPRITE_LAYER_PLAYER;

            Controller.StdIn.PipelineItemArrived += StdIn_PipelineItemArrived;
        }

        private void StdIn_PipelineItemArrived(PipelineMessage message)
        {
            if (message.Event == Pipeline.EVENT_PLAYER_MOVED)
            {
                var coordinates = message.Content.Split(',').Select(c => int.Parse(c)).ToArray();
                Position = new Double2D(coordinates[0] + _map.WorldOffset.X, coordinates[1] + _map.WorldOffset.Y);
                Facing = ObjectRotation.Down;
                WritePlayerPosition();
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
                        case ObjectRotation.Up:
                        case ObjectRotation.Down:
                            Position.Y = (float)Math.Round(Position.Y);
                            break;
                        case ObjectRotation.Left:
                        case ObjectRotation.Right:
                            Position.X = (float)Math.Round(Position.X);
                            break;
                    }

                    WritePlayerPosition();
                    TriggerWalkEvent();
                    _map.World.UpdateWorldmaps(true);
                }
                else
                {
                    switch (Facing)
                    {
                        case ObjectRotation.Up:
                            Position.Y -= WALK_SPEED;
                            break;
                        case ObjectRotation.Left:
                            Position.X -= WALK_SPEED;
                            break;
                        case ObjectRotation.Down:
                            Position.Y += WALK_SPEED;
                            break;
                        case ObjectRotation.Right:
                            Position.X += WALK_SPEED;
                            break;
                    }
                }
            }

            if (!_walking)
            {
                ObjectRotation? facing = null;
                if (GameboyInputs.DownDown())
                {
                    facing = ObjectRotation.Down;
                }
                else if (GameboyInputs.UpDown())
                {
                    facing = ObjectRotation.Up;
                }
                if (GameboyInputs.LeftDown())
                {
                    facing = ObjectRotation.Left;
                }
                else if (GameboyInputs.RightDown())
                {
                    facing = ObjectRotation.Right;
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
                            var checkPos = GetForwardPosition();
                            var tile = _map.World.GetSubtileInfo(checkPos);
                            if (tile.Value.Behavior == SubtileBehavior.LedgeDown ||
                                tile.Value.Behavior == SubtileBehavior.LedgeLeft ||
                                tile.Value.Behavior == SubtileBehavior.LedgeRight)
                            {
                                _walkDistance = 2f;
                            }
                            else
                            {
                                _walkDistance = 1f;
                            }
                            _walking = true;
                        }
                        else
                        {
                            _isBlocked = true;
                            _blockedTime = 1f;
                            TriggerBlockedWarp();
                        }
                    }
                }
            }

            base.Update();
        }

        internal void WritePlayerPosition()
        {
            GamePipeline.Write(Pipeline.EVENT_PLAYER_MOVED,
                (int)(Position.X - _map.WorldOffset.X) + "," + (int)(Position.Y - _map.WorldOffset.Y));
        }

        private void TriggerBlockedWarp()
        {
            // triggers warps in walls the player walked against (side/down doors)
            var checkPos = GetForwardPosition();
            var e = _map.GetMapEvent(checkPos);
            if (e != null)
            {
                _map.World.ExecuteEvent(e);
            }
        }

        private void TriggerWalkEvent()
        {
            var e = _map.GetMapEvent(Position);
            if (e != null)
            {
                _map.World.ExecuteEvent(e);
            }
        }

        internal void WalkForward()
        {
            _walkDistance = 1f;
            _walking = true;
        }

        internal void SetMap(Map map)
        {
            _map = map;
        }
    }
}
