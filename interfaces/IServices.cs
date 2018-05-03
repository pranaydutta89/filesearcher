using System.Collections.Generic;
using fileSearcher.Models;

namespace fileSearcher.interfaces
{

    public interface IFileService
    {
        bool IsFileLocationsSet { get; }
        IList<searchFolder> folderList { get; }
        IList<searchFolder> updateFolderListFile(IList<searchFolder> folderList);
    }
}