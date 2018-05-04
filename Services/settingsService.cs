using fileSearcher.interfaces;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using fileSearcher.Models;
using System.Linq;


namespace fileSearcher.services
{


    public class settingsService : ISettingsService
    {

        public IList<fileTypeModel> updateFileType(IList<fileTypeModel> fileTypes)
        {

            using (var db = new fileSearcherContext())
            {
                db.types.RemoveRange(db.types);
                db.types.AddRange(fileTypes);
                db.SaveChanges();
                return fileTypes;
            }
        }

        public IList<searchFolderModel> updateFolderListFile(IList<searchFolderModel> folderList)
        {

            using (var db = new fileSearcherContext())
            {
                List<searchFolderModel> folders = db.searchFolders.ToList();

                folderList.ToList().ForEach((searchFolderModel s) =>
                {
                    searchFolderModel Temp = folders.Find((searchFolderModel u) =>
                    {
                        return u.folderPath == s.folderPath;
                    });

                    if (Temp != null)
                    {
                        folderList.Remove(s);
                    }
                });

                db.searchFolders.AddRange(folderList);
                db.SaveChanges();
                return folderList;
            }

        }

        public IList<fileTypeModel> fileTypeList
        {
            get
            {
                using (var db = new fileSearcherContext())
                {
                    return db.types.ToList();
                }
            }
        }

        public IList<searchFolderModel> folderList
        {
            get
            {
                using (var db = new fileSearcherContext())
                {
                    return db.searchFolders.ToList();
                }
            }
        }



        public bool isFileTypeSet
        {
            get
            {
                using (var db = new fileSearcherContext())
                {
                    return db.types.ToList().Count != 0;
                }
            }
        }

        public bool isFolderListSet
        {
            get
            {
                using (var db = new fileSearcherContext())
                {
                    return db.searchFolders.ToList().Count != 0;
                }
            }
        }

    }
}