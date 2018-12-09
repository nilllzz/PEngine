using System;

namespace PEngine.Common.Data
{
    public class DataLoadException : Exception
    {
        public DataLoadException(string id, ProjectFileType fileType)
            : base($"Failed to load data from requested file. (Id: {id}, Type: {fileType.ToString()})")
        { }
    }
}
