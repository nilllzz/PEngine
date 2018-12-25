using PEngine.Common.Data;
using PEngine.Creator.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Projects
{
    internal static class FileIconProvider
    {
        public const string ICON_GENERIC = "generic";
        public const string ICON_MAP = "map";
        public const string ICON_TEXTURE = "texture";
        public const string ICON_TEXTURE_TILESET = "texture-tileset";
        public const string ICON_TEXTURE_CHARACTER = "texture-character";
        public const string ICON_TEXTURE_MONSTER = "texture-monster";
        public const string ICON_TILESET = "tileset";
        public const string ICON_WORLDMAP = "worldmap";
        public const string ICON_SCRIPT = "script";
        public const string ICON_MONSTER = "monster";
        public const string ICON_DEX = "dex";

        public const string ICON_FOLDER_OPEN = "folder-open";
        public const string ICON_FOLDER_CLOSED = "folder-closed";
        public const string ICON_PROJECT_OPEN = "project-open";
        public const string ICON_PROJECT_CLOSED = "project-closed";

        private static ImageList _list;

        private static void CreateImageList()
        {
            _list = new ImageList();
            _list.ColorDepth = ColorDepth.Depth32Bit;

            // files
            _list.Images.Add(ICON_GENERIC, FileIcons.file_generic);
            _list.Images.Add(ICON_MAP, FileIcons.file_map);
            _list.Images.Add(ICON_TEXTURE, FileIcons.file_texture);
            _list.Images.Add(ICON_WORLDMAP, FileIcons.file_world);
            _list.Images.Add(ICON_TILESET, FileIcons.file_tileset);
            _list.Images.Add(ICON_SCRIPT, FileIcons.file_script);
            _list.Images.Add(ICON_MONSTER, FileIcons.file_monster);
            _list.Images.Add(ICON_DEX, FileIcons.file_dex);
            _list.Images.Add(ICON_TEXTURE_TILESET, FileIcons.file_texture_tileset);
            _list.Images.Add(ICON_TEXTURE_MONSTER, FileIcons.file_texture_monster);
            _list.Images.Add(ICON_TEXTURE_CHARACTER, FileIcons.file_texture_character);
            // folders
            _list.Images.Add(ICON_FOLDER_OPEN, FileIcons.folder_open);
            _list.Images.Add(ICON_FOLDER_CLOSED, FileIcons.folder_closed);
            _list.Images.Add(ICON_PROJECT_OPEN, FileIcons.project_open);
            _list.Images.Add(ICON_PROJECT_CLOSED, FileIcons.project_closed);
        }

        internal static string GetIconKey(ProjectFileType fileType)
        {
            switch (fileType)
            {
                case ProjectFileType.Map:
                    return ICON_MAP;
                case ProjectFileType.Tileset:
                    return ICON_TILESET;
                case ProjectFileType.TextureTileset:
                    return ICON_TEXTURE_TILESET;
                case ProjectFileType.TextureCharacter:
                    return ICON_TEXTURE_CHARACTER;
                case ProjectFileType.TextureMonster:
                    return ICON_TEXTURE_MONSTER;
                case ProjectFileType.Worldmap:
                    return ICON_WORLDMAP;
                case ProjectFileType.Script:
                    return ICON_SCRIPT;
                case ProjectFileType.Monster:
                    return ICON_MONSTER;
                case ProjectFileType.Dex:
                    return ICON_DEX;
            }
            return ICON_GENERIC;
        }

        internal static ImageList GetImageList()
        {
            if (_list == null)
            {
                CreateImageList();
            }
            return _list;
        }

        internal static Image GetIcon(string key)
        {
            if (_list == null)
            {
                CreateImageList();
            }
            return _list.Images[key];
        }

        internal static Image GetIcon(ProjectFileType fileType)
        {
            return GetIcon(GetIconKey(fileType));
        }
    }
}
