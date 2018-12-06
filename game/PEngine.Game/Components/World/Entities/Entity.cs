using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PEngine.Game.Screens.World;

namespace PEngine.Game.Components.World.Entities
{
    abstract class Entity
    {
        // app lifetime counter
        private static int _idCounter = 0;
        public const int ENTITY_SIZE = 24;

        protected Map _map;
        protected Texture2D _texture;
        protected float _spriteLayer = WorldScreen.SPRITE_LAYER_ENTITY;

        public Vector2 Position;

        public int Id { get; }
        public bool CanBeRemoved { get; protected set; }

        protected Entity(Map map)
        {
            _map = map;

            Id = _idCounter;
            _idCounter++;
        }

        public abstract void LoadContent();

        protected virtual Rectangle GetTextureRectangle()
        {
            return new Rectangle(0, 0, _texture.Width, _texture.Height);
        }

        private Rectangle GetBoundingRectangle(Double2D offset)
        {
            var sizeDiff = Map.TILE_SIZE - ENTITY_SIZE;
            var sizeOffset = sizeDiff / 2f;

            return new Rectangle((int)(offset.X + Position.X * Map.TILE_SIZE + sizeOffset),
                (int)(offset.Y + Position.Y * Map.TILE_SIZE + sizeOffset),
                ENTITY_SIZE,
                ENTITY_SIZE);
        }

        public void Draw(SpriteBatch batch, Double2D offset)
        {
            var bounds = GetBoundingRectangle(offset);
            var textureRectangle = GetTextureRectangle();
            batch.Draw(_texture, bounds, textureRectangle, Color.White,
                0f, Vector2.Zero, SpriteEffects.None, _spriteLayer);
        }

        public abstract void Update();
    }
}
