using PEngine.Common;
using PEngine.Common.Data.Monsters;
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
    }
}
