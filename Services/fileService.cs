using fileSearcher.interfaces;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using fileSearcher.Models;
using System.Linq;


namespace fileSearcher.services
{

    public class fileService : IFileService
    {

        private readonly IAppConfig _appConfig;


        public fileService(IAppConfig appConfig)
        {
            this._appConfig = appConfig;

        }


        public IList<searchFolder> updateFolderListFile(IList<searchFolder> folderList)
        {

            using (var db = new fileSearcherContext())
            {
                db.searchFolders.AddRange(folderList);
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
        public bool IsFileLocationsSet
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

        public void searchFiles()
        {
            IList<searchFolder> foldersList;
            using (var db = new fileSearcherContext())
            {
                foldersList = db.searchFolders.ToList();

            }


            foreach (searchFolder folderPath in folderList)
            {
                foreach (string file in Directory.EnumerateFiles(
                            folderPath.folderPath,
                            "*",
                            SearchOption.AllDirectories)
                            )
                {


                }
            }

        }


    }

}