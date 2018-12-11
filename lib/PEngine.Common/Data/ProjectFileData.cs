using Newtonsoft.Json;
using System.IO;

namespace PEngine.Common.Data
{
    public sealed class ProjectFileData
    {
        public string id;
        public string type;

        // path the file on disk
        public string path;

        // id of the project folder
        public string folderId;

        [JsonIgnore]
        public ProjectFileType FileType
        {
            get => DataHelper.ParseEnum<ProjectFileType>(type);
            set => type = DataHelper.UnparseEnum(value);
        }

        [JsonIgnore]
        public string Identifier => type.ToString() + "|" + id.ToString();

        [JsonIgnore]
        public string FilePath => Path.Combine(Project.ActiveProject.BaseDirectory, path);
    }
}
