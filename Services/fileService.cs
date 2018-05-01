using fileSearcher.interfaces;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace fileSearcher.services
{

    public class fileService : IFileService
    {

        private readonly IAppConfig _appConfig;


        public fileService(IAppConfig appConfig)
        {
            this._appConfig = appConfig;
            this.createFolderListFile();
        }

        private T LoadJson<T>(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                T items = JsonConvert.DeserializeObject<T>(json);
                return items;
            }
        }



        private void createSettings()
        {
            if (!File.Exists(_appConfig.settingsFile))
            {
                File.Create(_appConfig.settingsFile);
            }
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
        public IList<string> folderList
        {
            get
            {
                List<string> list = this.LoadJson<List<string>>(_appConfig.settingsFile);
                return list != null ? list : new List<string>();
            }
        }
        public bool IsFileLocationsSet
        {
            get
            {
                return File.Exists("./" + this._appConfig.settingsFile) &&
                this.LoadJson<List<string>>(_appConfig.settingsFile) != null &&
                   !(this.LoadJson<List<string>>(_appConfig.folderSearchListFile).Count == 0);
            }
        }

        public void searchFiles()
        {

            IList<string> fileList = LoadJson<List<string>>(_appConfig.folderSearchListFile);

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