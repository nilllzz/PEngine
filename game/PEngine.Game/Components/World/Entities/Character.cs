using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PEngine.Common;
using PEngine.Common.Data;
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

        internal ObjectRotation Facing { get; set; }

        protected Character(Map map)
            : base(map)
        { }

        protected void LoadTexture(string characterTextureFileId)
        {
            var textureFile = Project.ActiveProject.GetFile(characterTextureFileId);
            _texture = Controller.ProjectContent.LoadDirect<Texture2D>(textureFile.path);
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

        protected Double2D GetForwardPosition()
        {
            var checkPos = Position;
            switch (Facing)
            {
                case ObjectRotation.Up:
                    checkPos += new Double2D(0, -1);
                    break;
                case ObjectRotation.Left:
                    checkPos += new Double2D(-1, 0);
                    break;
                case ObjectRotation.Down:
                    checkPos += new Double2D(0, 1);
                    break;
                case ObjectRotation.Right:
                    checkPos += new Double2D(1, 0);
                    break;
            }
            return checkPos;
        }

        protected bool CanWalk()
        {
            // TODO: check for entities
            var checkPos = GetForwardPosition();
            var tile = _map.World.GetSubtileInfo(checkPos);
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
