using System.Collections.Generic;
using fileSearcher.Models;

namespace fileSearcher.interfaces
{

    public interface ISettingsService
    {
        IList<fileType> updateFileType(IList<fileType> fileTypes);
        IList<fileType> fileTypeList { get; }
        bool isFileTypeSet { get; }
        bool isFolderListSet { get; }
        IList<searchFolder> folderList { get; }
        IList<searchFolder> updateFolderListFile(IList<searchFolder> folderList);
    }
    public interface IFileService
    {

    }
}