namespace PEngine.Common.Data
{
    public sealed class ProjectFileData
    {
        public string path;
        public string type;
        public string id;

        public ProjectFileType GetFileType()
        {
            return DataHelper.ParseEnum<ProjectFileType>(type);
        }
    }
}
