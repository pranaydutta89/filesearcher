using System.Collections.Generic;
using fileSearcher.Models;
using System.Threading.Tasks;

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
        IList<fileModel> getFileList(int start, int take);
        bool isThereAnyFiles { get; }
        Task<int> scanFiles();
    }
}