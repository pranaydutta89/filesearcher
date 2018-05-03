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

        public IList<fileType> updateFileType(IList<fileType> fileTypes)
        {

            using (var db = new fileSearcherContext())
            {
                db.types.RemoveRange(db.types);
                db.types.AddRange(fileTypes);
                db.SaveChanges();
                return fileTypes;
            }
        }

        public IList<searchFolder> updateFolderListFile(IList<searchFolder> folderList)
        {

            using (var db = new fileSearcherContext())
            {
                List<searchFolder> folders = db.searchFolders.ToList();

                folderList.ToList().ForEach((searchFolder s) =>
                {
                    searchFolder Temp = folders.Find((searchFolder u) =>
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

        public IList<fileType> fileTypeList
        {
            get
            {
                using (var db = new fileSearcherContext())
                {
                    return db.types.ToList();
                }
            }
        }

        public IList<searchFolder> folderList
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