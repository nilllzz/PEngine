using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Common.Data.World;
using System;

namespace PEngine.Creator.Components.Projects
{
    internal class ProjectEventBus
    {
        #region Files

        internal event Action<ProjectFileData> FileOpenRequested;
        internal event Action<ProjectFileData> FileUpdated;
        internal event Action<ProjectFileData> FileDeleted;
        internal event Action<ProjectFileData> TextureUpdated;

        internal void RequestFileOpen(ProjectFileData file)
        {
            FileOpenRequested?.Invoke(file);
        }

        internal void UpdatedFile(ProjectFileData file)
        {
            FileUpdated?.Invoke(file);
        }

        internal void DeletedFile(ProjectFileData file)
        {
            FileDeleted?.Invoke(file);
        }

        internal void UpdatedTexture(ProjectFileData file)
        {

        }

        #endregion

        #region Tiles

        internal event Action<TilesetData, TileData> TileSelected;
        internal event Action<TilesetData, TileData> TileUpdated;
        internal event Action<TilesetData, TileData> TileAdded;
        internal event Action<TilesetData, TileData> TileRemoved;

        internal event Action<TilesetData, SubtileData> SubtileSelected;
        internal event Action<TilesetData, SubtileData> SubtileUpdated;
        internal event Action<TilesetData, SubtileData> SubtileAdded;
        internal event Action<TilesetData, SubtileData> SubtileRemoved;

        internal void SelectedTile(TilesetData parent, TileData data)
        {
            TileSelected?.Invoke(parent, data);
        }

        internal void UpdatedTile(TilesetData parent, TileData data)
        {
            TileUpdated?.Invoke(parent, data);
        }

        internal void AddedTile(TilesetData parent, TileData data)
        {
            TileAdded?.Invoke(parent, data);
        }

        internal void RemovedTile(TilesetData parent, TileData data)
        {
            TileRemoved?.Invoke(parent, data);
        }

        internal void SelectedSubtile(TilesetData parent, SubtileData data)
        {
            SubtileSelected?.Invoke(parent, data);
        }

        internal void UpdatedSubtile(TilesetData parent, SubtileData data)
        {
            SubtileUpdated?.Invoke(parent, data);
        }

        internal void AddedSubtile(TilesetData parent, SubtileData data)
        {
            SubtileAdded?.Invoke(parent, data);
        }

        internal void RemovedSubtile(TilesetData parent, SubtileData data)
        {
            SubtileRemoved?.Invoke(parent, data);
        }

        #endregion

        #region Maps

        internal event Action<MapData> MapUpdated;
        internal event Action<MapData, MapEventData> EventAdded;
        internal event Action<MapData, MapEventData> EventRemoved;
        internal event Action<MapData, MapEventData> EventSelected;
        internal event Action<MapData, MapEventType> EventTypeChanged;

        internal void UpdatedMap(MapData data)
        {
            MapUpdated?.Invoke(data);
        }

        internal void AddedEvent(MapData parent, MapEventData eventData)
        {
            EventAdded?.Invoke(parent, eventData);
        }

        internal void RemovedEvent(MapData parent, MapEventData eventData)
        {
            EventRemoved?.Invoke(parent, eventData);
        }

        internal void SelectEvent(MapData parent, MapEventData eventData)
        {
            EventSelected?.Invoke(parent, eventData);
        }

        internal void ChangedEventType(MapData parent, MapEventType type)
        {
            EventTypeChanged?.Invoke(parent, type);
        }

        #endregion

        #region Worldmap

        internal event Action<WorldmapData, MapData> MapSelected;
        internal event Action<WorldmapData, MapData> MapMoved;
        internal event Action<WorldmapData, WorldmapEntryData> WorldmapEntryRemoved;

        internal void SelectedMap(WorldmapData worldmap, MapData map)
        {
            MapSelected?.Invoke(worldmap, map);
        }

        internal void MovedMap(WorldmapData worldmap, MapData map)
        {
            MapMoved?.Invoke(worldmap, map);
        }

        internal void RemovedWorldmapEntry(WorldmapData worldmap, WorldmapEntryData entry)
        {
            WorldmapEntryRemoved?.Invoke(worldmap, entry);
        }

        #endregion
    }
}
