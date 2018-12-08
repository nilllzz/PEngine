using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using System;

namespace PEngine.Creator.Components.Projects
{
    public class ProjectEventBus
    {
        #region Files

        public event Action<ProjectItem> ItemOpenRequested;
        public event Action<ProjectFileData> FileUpdated;

        public void RequestItemOpen(ProjectItem item)
        {
            ItemOpenRequested?.Invoke(item);
        }

        public void UpdatedFile(ProjectFileData file)
        {
            FileUpdated?.Invoke(file);
        }

        #endregion

        #region Tiles

        public event Action<TilesetData, TileData> TileSelected;
        public event Action<TilesetData, TileData> TileUpdated;
        public event Action<TilesetData, TileData> TileAdded;
        public event Action<TilesetData, TileData> TileRemoved;

        public event Action<TilesetData, SubtileData> SubtileSelected;
        public event Action<TilesetData, SubtileData> SubtileUpdated;
        public event Action<TilesetData, SubtileData> SubtileAdded;
        public event Action<TilesetData, SubtileData> SubtileRemoved;

        public void SelectedTile(TilesetData parent, TileData data)
        {
            TileSelected?.Invoke(parent, data);
        }

        public void UpdatedTile(TilesetData parent, TileData data)
        {
            TileUpdated?.Invoke(parent, data);
        }

        public void AddedTile(TilesetData parent, TileData data)
        {
            TileAdded?.Invoke(parent, data);
        }

        public void RemovedTile(TilesetData parent, TileData data)
        {
            TileRemoved?.Invoke(parent, data);
        }

        public void SelectedSubtile(TilesetData parent, SubtileData data)
        {
            SubtileSelected?.Invoke(parent, data);
        }

        public void UpdatedSubtile(TilesetData parent, SubtileData data)
        {
            SubtileUpdated?.Invoke(parent, data);
        }

        public void AddedSubtile(TilesetData parent, SubtileData data)
        {
            SubtileAdded?.Invoke(parent, data);
        }

        public void RemovedSubtile(TilesetData parent, SubtileData data)
        {
            SubtileRemoved?.Invoke(parent, data);
        }

        #endregion
    }
}
