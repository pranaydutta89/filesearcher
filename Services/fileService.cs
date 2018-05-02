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


        public IList<string> updateFolderListFile(IList<string> folderList)
        {

            using (StreamWriter file = new StreamWriter(_appConfig.settingsFile))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, folderList);
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

            IList<string> fileList = LoadJson<List<string>>(_appConfig.settingsFile);

            foreach (string filePath in fileList)
            {
                foreach (string file in Directory.EnumerateFiles(
                            filePath,
                            "*",
                            SearchOption.AllDirectories)
                            )
                {


                }
            }

        }


    }

}