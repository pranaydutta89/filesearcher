using fileSearcher.interfaces;
using System.IO;

namespace fileSearcher.constants
{


    public class appConfig : IAppConfig
    {


        private void createFolders()
        {
            if (!Directory.Exists(this.rootFolder))
            {
                Directory.CreateDirectory(this.rootFolder);
            }

        }

        public appConfig()
        {
            this.createFolders();
        }
        private string rootFolder
        {
            get
            {
                return "./applicationData/";
            }
        }

        public string folderSearchListFile
        {
            get
            {
                return this.rootFolder + "folderSearchListFile.json";
            }
        }
    }
}