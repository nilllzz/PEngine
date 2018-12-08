using Microsoft.Xna.Framework.Graphics;
using PEngine.Common.Interop;
using PEngine.Game.Components.World.Entities;
using static Core;

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
            _playerEntity.Position = new Double2D(4, 5);
            ActiveMap.Entities.Add(_playerEntity);

            var npc = new NPC(ActiveMap)
            {
                Position = new Double2D(3, 6)
            };
            ActiveMap.Entities.Add(npc);

            ActiveMap.LoadContent();

            Controller.Pipeline.Write(Pipeline.EVENT_SET_MAP, mapId);
        }

        public void Draw(SpriteBatch batch)
        {
            var offset = new Double2D(Map.TILE_SIZE * 4) - _playerEntity.Position * Map.TILE_SIZE;
            ActiveMap.Draw(batch, offset);
        }

        public void Update()
        {
            ActiveMap.Update();
        }
    }
}
