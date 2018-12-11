using PEngine.Common.Data;

namespace PEngine.Creator.Components.Projects
{
    internal class ProjectFileTreeNode : ProjectTreeNode
    {
        public ProjectFileData File { get; }

        public ProjectFileTreeNode(ProjectFileData file)
            : base(file.id)
        {
            File = file;

            switch (File.FileType)
            {
                case ProjectFileType.Map:
                    _collapsedIconIndex = ICON_MAP;
                    break;
                case ProjectFileType.Tileset:
                    _collapsedIconIndex = ICON_TILESET;
                    break;
                case ProjectFileType.TextureTileset:
                case ProjectFileType.TextureCharacter:
                    _collapsedIconIndex = ICON_IMAGE;
                    break;
            }

            _expandedIconIndex = _collapsedIconIndex;
            ImageIndex = _collapsedIconIndex;
            SelectedImageIndex = ImageIndex;
        }

        public void UpdateText()
        {
            Text = File.id;
        }
    }
}
