using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using System;

namespace PEngine.Creator.Components.Projects
{
    internal class ProjectEventBus
    {
        #region Files

        internal event Action<ProjectFileData> FileOpenRequested;
        internal event Action<ProjectFileData> FileUpdated;
        internal event Action<ProjectFileData> FileDeleted;

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

        internal void UpdatedMap(MapData data)
        {
            MapUpdated?.Invoke(data);
        }

        #endregion
    }
}
