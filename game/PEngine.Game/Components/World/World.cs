using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Common.Data.World;
using PEngine.Common.Interop;
using PEngine.Game.Components.Scripting;
using PEngine.Game.Components.World.Entities;
using System.Collections.Generic;
using System.Linq;
using static Core;

namespace PEngine.Game.Components.World
{
    internal class World
    {
        private readonly List<Map> _loadedMaps = new List<Map>();
        private PlayerEntity _playerEntity;
        private WorldmapData _worldmap;

        internal Map ActiveMap { get; private set; }
        internal ScriptManager ScriptManager { get; private set; }

        internal void LoadContent()
        {
            var worldmapFile = Project.ActiveProject.GetFiles(ProjectFileType.Worldmap)[0];
            _worldmap = WorldmapData.Load(worldmapFile);

            ScriptManager = new ScriptManager();

            _playerEntity = new PlayerEntity();
            _playerEntity.Position = new Double2D(37, 30);
            _playerEntity.LoadContent();
        }

        internal void ChangeMap(string mapId)
        {
            if (ActiveMap == null || ActiveMap.Id != mapId)
            {
                if (ActiveMap != null && ActiveMap.Entities.Contains(_playerEntity))
                {
                    ActiveMap.Entities.Remove(_playerEntity);
                }

                if (_loadedMaps.Any(l => l.Id == mapId))
                {
                    ActiveMap = _loadedMaps.First(l => l.Id == mapId);
                }
                else
                {
                    ActiveMap = new Map(this, mapId);
                    ActiveMap.LoadContent();
                    _loadedMaps.Add(ActiveMap);
                }

                ActiveMap.Entities.Add(_playerEntity);
                _playerEntity.SetMap(ActiveMap);
                GamePipeline.Write(Pipeline.EVENT_SET_MAP, mapId);

                UpdateWorldmaps(false);
            }
        }

        internal void Draw(SpriteBatch batch)
        {
            var offset = new Double2D(Map.TILE_SIZE * 4) - _playerEntity.Position * Map.TILE_SIZE;

            // draw all loaded maps
            foreach (var map in _loadedMaps)
            {
                map.Draw(batch, offset);
            }

            // draw the active map
            ActiveMap.Draw(batch, offset);

            // draw the map tile fill
            ActiveMap.DrawFill(batch, _playerEntity);
        }

        internal void Update()
        {
            ActiveMap.Update();
        }

        internal void UpdateWorldmaps(bool changeMaps)
        {
            if (_worldmap.entries.All(e => e.mapId != ActiveMap.Id))
            {
                // if the current map is not on the worldmap, unload all maps (except the active one)
                for (var i = 0; i < _loadedMaps.Count; i++)
                {
                    if (_loadedMaps[i].Id != ActiveMap.Id)
                    {
                        _loadedMaps[i].UnloadContent();
                        _loadedMaps.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
            {
                // if it is a worldmap, unload all non-worldmap maps
                var nonWorldmapMaps = _loadedMaps.Where(l => _worldmap.entries.All(e => e.mapId != l.Id)).ToArray();
                foreach (var nonWorldmapMap in nonWorldmapMaps)
                {
                    nonWorldmapMap.UnloadContent();
                    _loadedMaps.Remove(nonWorldmapMap);
                }

                // load new maps or dispose of unneeded ones
                var playerRect = new Rectangle((int)_playerEntity.Position.X - 6, (int)_playerEntity.Position.Y - 6, 13, 13);
                foreach (var mapEntry in _worldmap.entries)
                {
                    if (mapEntry.mapId != ActiveMap.Id)
                    {
                        var entryRect = new Rectangle(
                            mapEntry.bounds[0],
                            mapEntry.bounds[1],
                            mapEntry.bounds[2],
                            mapEntry.bounds[3]);
                        var loadedMap = _loadedMaps.FirstOrDefault(l => l.Id == mapEntry.mapId);

                        if (playerRect.Intersects(entryRect))
                        {
                            if (loadedMap == null)
                            {
                                var map = new Map(this, mapEntry.mapId);
                                map.LoadContent();
                                _loadedMaps.Add(map);
                            }

                            // move player to new map if desired
                            if (changeMaps && entryRect.Contains(new Point((int)_playerEntity.Position.X, (int)_playerEntity.Position.Y)))
                            {
                                ChangeMap(mapEntry.mapId);
                            }
                        }
                        else
                        {
                            if (loadedMap != null)
                            {
                                loadedMap.UnloadContent();
                                _loadedMaps.Remove(loadedMap);
                            }
                        }
                    }
                }
            }
        }

        internal Point GetWorldmapOffset(string mapId)
        {
            var entry = _worldmap.entries.FirstOrDefault(e => e.mapId == mapId);
            if (entry != null)
            {
                return new Point(entry.bounds[0], entry.bounds[1]);
            }
            return Point.Zero;
        }

        internal void ExecuteEvent(MapEventData eventData)
        {
            var targetFile = Project.ActiveProject.GetFile(eventData.target);

            switch (eventData.EventType)
            {
                case MapEventType.Warp:
                    if (targetFile.FileType == ProjectFileType.Map)
                    {
                        var mapData = MapData.Load(targetFile);
                        if (mapData.id != ActiveMap.Id)
                        {
                            ChangeMap(mapData.id);
                        }
                        var targetPos = eventData.WarpPositionData.IntArr;
                        _playerEntity.Position = new Double2D(targetPos[0] + ActiveMap.WorldOffset.X, targetPos[1] + ActiveMap.WorldOffset.Y);
                        var targetRot = eventData.WarpRotationData.value;
                        if (targetRot != "")
                        {
                            var rotation = DataHelper.ParseEnum<ObjectRotation>(targetRot);
                            _playerEntity.Facing = rotation;
                        }

                        if (_playerEntity.Facing == ObjectRotation.Down)
                        {
                            _playerEntity.WalkForward();
                        }
                    }

                    break;
                case MapEventType.Script:
                    break;
            }
        }

        internal SubtileInfo? GetSubtileInfo(Double2D position)
        {
            var info = ActiveMap.GetSubtileInfo(position);
            if (!info.HasValue)
            {
                foreach (var loadedMap in _loadedMaps)
                {
                    if (loadedMap.Id != ActiveMap.Id)
                    {
                        var loadedInfo = loadedMap.GetSubtileInfo(position);
                        if (loadedInfo.HasValue)
                        {
                            return loadedInfo;
                        }
                    }
                }
            }
            return info;
        }
    }
}
