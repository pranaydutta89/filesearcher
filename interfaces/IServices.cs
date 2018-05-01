using System.Collections.Generic;

namespace fileSearcher.interfaces
{

    public interface IFileService
    {
        bool IsFileLocationsSet { get; }
        IList<string> folderList { get; }
        IList<string> updateFolderListFile(IList<string> folderList);
    }
}