using fileSearcher.interfaces;
using System.IO;

namespace fileSearcher.services
{

    public class fileService : IFileService
    {

        private readonly IAppConfig _appConfig;


        public fileService(IAppConfig appConfig)
        {
            this._appConfig = appConfig;
            this.createFileListFile();
        }

        // public void LoadJson<T>(string fileName)
        // {
        //     using (StreamReader r = new StreamReader(fileName))
        //     {
        //         string json = r.ReadToEnd();
        //         T items = JsonConvert.DeserializeObject<T>(json);
        //     }
        // }



        private void createFileListFile()
        {
            if (!File.Exists(_appConfig.folderSearchListFile))
            {
                File.Create(_appConfig.folderSearchListFile);
            }
        }


        public bool IsFileLocationsSet
        {
            get
            {
                return File.Exists("./" + this._appConfig.folderSearchListFile);
            }
        }

        public void searchFiles()
        {
            foreach (string file in Directory.EnumerateFiles(
                        "/",
                        "*",
                        SearchOption.AllDirectories)
                        )
            {


            }

        }


    }

}