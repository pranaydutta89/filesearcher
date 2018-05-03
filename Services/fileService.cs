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

        public void searchFiles()
        {
            // IList<searchFolder> foldersList;
            // using (var db = new fileSearcherContext())
            // {
            //     foldersList = db.searchFolders.ToList();

            // }


            // foreach (searchFolder folderPath in folderList)
            // {
            //     foreach (string file in Directory.EnumerateFiles(
            //                 folderPath.folderPath,
            //                 "*",
            //                 SearchOption.AllDirectories)
            //                 )
            //     {


            //     }
            // }

        }


    }

}