using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Monsters;
using PEngine.Creator.Components.Projects;
using PEngine.Creator.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game.Monsters
{
    internal struct NamedMonsterSpritePalette
    {
        public NamedMonsterSpritePalette(string name, MonsterSpritePalette palette)
        {
            Name = name;
            Palette = palette;
        }
        public string Name;
        public MonsterSpritePalette Palette;
    }

    internal static class MonsterSpriteService
    {
        internal static ProjectFileData ImportMonsterTexture(MonsterData data)
        {
            var msgResult = MessageBox.Show("To import a monster texture, you need to select 4 files:\n" +
                "Front Sprite, Back Sprite, Shiny Front Sprite, Shiny Back Sprite\n\n" +
                "Each sprite has to be a png image and 56x56 pixels in size.\n" +
                "It also has to be made up of exactly 4 different colors.\n" +
                "All pixels that are completely transparent will be ignored and are not counted.\n\n" +
                "Do you want to proceed?", "Import monster sprite", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgResult == DialogResult.No)
            {
                return null;
            }

            var spriteFiles = new List<string>();

            var initialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            while (spriteFiles.Count < 4)
            {
                var dialog = new OpenFileDialog
                {
                    CheckFileExists = true,
                    CheckPathExists = true,
                    InitialDirectory = initialDirectory,
                    Filter = "Png Image File (*.png)|*.png",
                    Multiselect = false,
                };
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    spriteFiles.Add(dialog.FileName);
                    initialDirectory = Path.GetDirectoryName(dialog.FileName);
                }
                else
                {
                    // cancel entire selection
                    return null;
                }
            }

            var bmps = spriteFiles.Select(f =>
            {
                var bytes = File.ReadAllBytes(f);
                using (var ms = new MemoryStream(bytes))
                {
                    return new Bitmap(ms);
                }
            }).ToArray();

            // store result in file and return
            var output = MonsterSpriteService.Generate(bmps, data);
            var filename = ProjectService.GenerateFileName(Project.ActiveProject, $"content/{data.id}-sprite.png");
            output.Save(filename, ImageFormat.Png);
            var file = ProjectService.IncludeExternalFile(Project.ActiveProject, filename,
                ProjectFileType.TextureMonster, null);
            // use monster's name as file display name
            file.name = data.name;
            Project.ActiveProject.Save();

            return file;
        }

        internal static Bitmap Generate(Bitmap[] input, MonsterData data)
        {
            var inFront = input[0];
            var inBack = input[1];
            var inFrontS = input[2];
            var inBackS = input[3];

            var normalColors = new List<Color>();
            var shinyColors = new List<Color>();

            // find and order colors
            for (var y = 0; y < inFront.Height; y++)
            {
                for (var x = 0; x < inFront.Width; x++)
                {
                    void addColor(Bitmap img, List<Color> colors)
                    {
                        var pixel = img.GetPixel(x, y);
                        if (pixel.A == 255)
                        {
                            if (!colors.Contains(pixel))
                            {
                                colors.Add(pixel);
                                // order colors by combined channel brightness
                                if (colors == normalColors)
                                {
                                    normalColors = colors.OrderBy(c => c.R + c.G + c.B).ToList();
                                    colors = normalColors;
                                }
                                else
                                {
                                    shinyColors = colors.OrderBy(c => c.R + c.G + c.B).ToList();
                                    colors = shinyColors;
                                }
                            }
                        }
                    }

                    addColor(inFront, normalColors);
                    addColor(inFrontS, shinyColors);
                }
            }
            // set front colors
            for (var y = 0; y < inFront.Height; y++)
            {
                for (var x = 0; x < inFront.Width; x++)
                {
                    void setColor(Bitmap img, List<Color> colors)
                    {
                        var pixel = img.GetPixel(x, y);
                        if (pixel.A == 255)
                        {
                            img.SetPixel(x, y, GetIndexColor(colors.IndexOf(pixel)));
                        }
                    }

                    setColor(inFront, normalColors);
                    setColor(inFrontS, shinyColors);
                }
            }

            // set back colors
            for (var y = 0; y < inFront.Height; y++)
            {
                for (var x = 0; x < inFront.Width; x++)
                {
                    void setPixel(Bitmap img, List<Color> colors)
                    {
                        var pixel = img.GetPixel(x, y);
                        if (pixel.A == 255)
                        {
                            var index = -1;
                            var maxDiff = 0;
                            do
                            {
                                for (var i = 0; i < colors.Count; i++)
                                {
                                    var c = colors[i];
                                    var diffR = Math.Abs(pixel.R - c.R);
                                    var diffG = Math.Abs(pixel.G - c.G);
                                    var diffB = Math.Abs(pixel.B - c.B);

                                    if (diffR <= maxDiff && diffG <= maxDiff && diffB <= maxDiff)
                                    {
                                        index = i;
                                        break;
                                    }
                                }
                                maxDiff++;
                            } while (index == -1);
                            img.SetPixel(x, y, GetIndexColor(index));
                        }
                    }

                    setPixel(inBack, normalColors);
                    setPixel(inBackS, shinyColors);
                }
            }

            // write front and back to the same bmp
            var outBmp = new Bitmap(56 * 2, 56);
            var g = Graphics.FromImage(outBmp);
            g.Clear(Color.Transparent);
            g.DrawImage(inFront, new Rectangle(0, 0, 56, 56));
            g.DrawImage(inBack, new Rectangle(56, 0, 56, 56));

            // set the result palette on the monster data
            data.palette = new MonsterSpritePalette
            {
                normal = normalColors.Select(c => new int[] { c.R, c.G, c.B }).ToArray(),
                shiny = shinyColors.Select(c => new int[] { c.R, c.G, c.B }).ToArray(),
            };

            return outBmp;
        }

        private static Color GetIndexColor(int index)
        {
            switch (index)
            {
                case 0:
                    return Color.FromArgb(0, 0, 0);
                case 1:
                    return Color.FromArgb(255, 0, 0);
                case 2:
                    return Color.FromArgb(0, 255, 0);
                case 3:
                    return Color.FromArgb(0, 0, 255);
            }
            return default(Color);
        }

        internal static void RecordUsedPalette(string name, MonsterSpritePalette palette)
        {
            name = name.Replace("|", "_");
            var json = palette.ToString();
            var data = name + "|" + json;
            foreach (var item in Settings.Default.UsedPalettes)
            {
                if (item.StartsWith(name + "|"))
                {
                    Settings.Default.UsedPalettes.Remove(item);
                }
            }
            Settings.Default.UsedPalettes.Add(data);
            Settings.Default.Save();
        }

        internal static NamedMonsterSpritePalette[] GetUsedPalettes()
        {
            var palettes = new List<NamedMonsterSpritePalette>();
            foreach (var item in Settings.Default.UsedPalettes)
            {
                var sepIndex = item.IndexOf("|");
                var name = item.Substring(0, sepIndex);
                var json = item.Substring(sepIndex + 1);
                palettes.Add(new NamedMonsterSpritePalette(name, MonsterSpritePalette.FromString(json)));
            }
            return palettes.ToArray();
        }
    }
}
