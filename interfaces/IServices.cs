using System.Collections.Generic;
using fileSearcher.Models;

namespace fileSearcher.interfaces
{

    public interface IFileService
    {
        bool IsFolderListSet { get; }
        IList<searchFolder> folderList { get; }
        IList<searchFolder> updateFolderListFile(IList<searchFolder> folderList);
    }
}