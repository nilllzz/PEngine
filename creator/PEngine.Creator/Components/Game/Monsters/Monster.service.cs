using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Monsters;
using PEngine.Creator.Components.Projects;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PEngine.Creator.Components.Game.Monsters
{
    internal static class MonsterService
    {
        internal static Bitmap GetTexture(MonsterData data, bool front)
        {
            var textureFile = Project.ActiveProject.GetFile(data.texture);
            var baseTexture = ResourceManager.BitmapFromFile(textureFile);

            Rectangle textureRect;
            if (front)
            {
                textureRect = new Rectangle(0, 0, 56, 56);
            }
            else
            {
                textureRect = new Rectangle(56, 0, 56, 56);
            }

            var cropped = baseTexture.Clone(textureRect, baseTexture.PixelFormat);
            return cropped;
        }

        internal static Color[] GetPlaceholderColors(Bitmap texture)
        {
            var pixels = ResourceManager.GetPixels(texture);
            var colors = new List<Color>();

            for (var i = 0; i < pixels.Length; i++)
            {
                var pixel = pixels[i];
                var hueCombined = pixel.R + pixel.G + pixel.B;
                if (pixel.A == 255 &&
                    (hueCombined == 255 || hueCombined == 0) &&
                    !colors.Any(c => c.R == pixel.R && c.G == pixel.G && c.B == pixel.B))
                {
                    colors.Add(pixel);
                }
            }

            return colors.OrderBy(c => c.R + c.G * 255 + c.B * 255 * 255).ToArray();
        }

        private static DexData CreateNewDex(string id)
        {
            var data = DexData.Create(id);
            data.entries = new DexEntryData[0];
            return data;
        }

        internal static DexData GetDex()
        {
            var dexFiles = Project.ActiveProject.GetFiles(ProjectFileType.Dex);
            if (dexFiles.Length == 0)
            {
                // if there are no dex files in the project, create a new one in the root of the project
                var id = ProjectService.GenerateFileId(Project.ActiveProject, "main-dex");
                var dexData = CreateNewDex(id);
                dexData.Save();
                ProjectService.IncludeResource(Project.ActiveProject, dexData, "Dex", ProjectFileType.Dex, null);
                Project.ActiveProject.Save();
                return dexData;
            }
            else
            {
                // always just use the first file
                // there should never be more than one dex in a project
                var file = dexFiles[0];
                var dexData = DexData.Load(file);
                return dexData;
            }
        }

        internal static DexEntryData GetOrCreateDexEntry(DexData dex, MonsterData monster, out bool created)
        {
            var existingEntry = dex.entries.FirstOrDefault(e => e.monsterId == monster.id);
            if (existingEntry != null)
            {
                created = false;
                return existingEntry;
            }
            else
            {
                var newEntry = new DexEntryData
                {
                    monsterId = monster.id,
                    height = 1,
                    weight = 1,
                    regionalNumber = monster.number,
                    species = "Unknown",
                    text = "Fill\ntext\nhere.\n\nSecond\npage\nalso.",
                    areas = new string[0],
                };

                var entries = dex.entries.ToList();
                entries.Add(newEntry);
                dex.entries = entries.ToArray();

                created = true;
                return newEntry;
            }
        }
    }
}
