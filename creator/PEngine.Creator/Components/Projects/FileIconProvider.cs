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
        public const string ICON_TILESET = "tileset";
        public const string ICON_WORLDMAP = "worldmap";

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
                case ProjectFileType.TextureCharacter:
                    return ICON_TEXTURE;
                case ProjectFileType.Worldmap:
                    return ICON_WORLDMAP;
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
