using PEngine.Common.Data.World;
using System.Drawing;
using System.Linq;

namespace PEngine.Creator.Components.Game.World
{
    internal static class WorldmapService
    {
        internal static WorldmapData CreateNew(string id)
        {
            var data = WorldmapData.Create(id);
            data.entries = new WorldmapEntryData[0];
            return data;
        }

        internal static void AddEntry(WorldmapData worldmap, WorldmapEntryData entry)
        {
            var entries = worldmap.entries.ToList();
            entries.Add(entry);
            worldmap.entries = entries.ToArray();
        }

        internal static void RemoveEntry(WorldmapData worldmap, WorldmapEntryData entry)
        {
            worldmap.entries = worldmap.entries.Where(e => e.mapId != entry.mapId).ToArray();
        }

        internal static bool IsValidPosition(WorldmapData worldmap, WorldmapEntryData entry)
        {
            // checks if the single entry has a valid position on the world
            // valid is not overlapping with any other entry

            var entryRect = new Rectangle(entry.bounds[0], entry.bounds[1], entry.bounds[2], entry.bounds[3]);
            foreach (var e in worldmap.entries)
            {
                if (e.mapId != entry.mapId)
                {
                    var eRect = new Rectangle(e.bounds[0], e.bounds[1], e.bounds[2], e.bounds[3]);
                    if (eRect.IntersectsWith(entryRect))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
