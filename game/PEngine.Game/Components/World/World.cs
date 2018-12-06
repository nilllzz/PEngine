using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PEngine.Game.Components.World.Entities;

namespace PEngine.Game.Components.World
{
    class World
    {
        public Map ActiveMap { get; private set; }

        private PlayerEntity _playerEntity;

        public void LoadMap(string mapId)
        {
            ActiveMap = new Map(mapId);
            _playerEntity = new PlayerEntity(ActiveMap);
            _playerEntity.Position = new Vector2(4, 5);
            ActiveMap.Entities.Add(_playerEntity);

            var npc = new NPC(ActiveMap);
            npc.Position = new Vector2(0, 6);
            ActiveMap.Entities.Add(npc);

            ActiveMap.LoadContent();
        }

        public void Draw(SpriteBatch batch)
        {
            // need double precision here
            var offset = new Double2D
            {
                X = Map.TILE_SIZE * 4 - (double)_playerEntity.Position.X * Map.TILE_SIZE,
                Y = Map.TILE_SIZE * 4 - (double)_playerEntity.Position.Y * Map.TILE_SIZE,
            };
            ActiveMap.Draw(batch, offset);
        }

        public void Update()
        {
            ActiveMap.Update();
        }
    }
}
