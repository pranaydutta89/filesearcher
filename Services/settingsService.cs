using fileSearcher.interfaces;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using fileSearcher.Models;
using System.Linq;


namespace fileSearcher.services{


    public class settingsService:ISettingsService{



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
        public bool IsFolderListSet
        {
            get
            {
                using (var db = new fileSearcherContext())
                {
                    List<searchFolder> folderPath = db.searchFolders.ToList();
                    return folderPath.Count != 0;
                }
            }
        }

    }
}