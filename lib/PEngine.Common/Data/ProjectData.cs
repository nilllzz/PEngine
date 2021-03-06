﻿using System;

namespace PEngine.Common.Data
{
    internal sealed class ProjectData
    {
        public string name;
        public string author;
        public DateTime createdOn;
        public DateTime changedOn;
        public ProjectFileData[] files;
        public ProjectFolderData[] folders;
    }
}
