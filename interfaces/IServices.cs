using System.Collections.Generic;
using fileSearcher.Models;

namespace fileSearcher.interfaces
{

    public interface ISettingsService
    {

        IList<fileTypeModel> updateFileType(IList<fileTypeModel> fileTypes);
        IList<fileTypeModel> fileTypeList { get; }
        bool isFileTypeSet { get; }
        bool isFolderListSet { get; }
        IList<searchFolderModel> folderList { get; }
        IList<searchFolderModel> updateFolderListFile(IList<searchFolderModel> folderList);
    }
    public interface IFileService
    {
        int scanFiles();
    }
}