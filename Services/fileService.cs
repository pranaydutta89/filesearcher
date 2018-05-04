using fileSearcher.interfaces;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using fileSearcher.Models;
using System.Linq;
using fileSearcher.constants;


namespace fileSearcher.services
{

    public class fileService : IFileService
    {

        private readonly IAppConfig _appConfig;

        private List<string> audioExtn = new List<string>(){
            "mp3",
            "wav"
        };

        private List<string> videoExtn = new List<string>(){
            "mp4",
            "mpeg",
            "mpg"
        };


        private List<string> documentExtn = new List<string>(){
            "docx",
            "pptx",
            "pdf"
        };

        private List<string> imageExtn = new List<string>(){
            "jpg",
            "png",
            "gif"
        };


        public fileService(IAppConfig appConfig)
        {
            this._appConfig = appConfig;

        }

        public int scanFiles()
        {
            List<fileType> types;
            List<searchFolder> folders;
            using (var db = new fileSearcherContext())
            {
                types = db.types.ToList();
                folders = db.searchFolders.ToList();
            }

            List<string> extn = new List<string>();

            types.ForEach((type) =>
            {
                switch (type.type)
                {
                    case fileTypeConstant.audio:
                        extn.AddRange(this.audioExtn);
                        break;

                    case fileTypeConstant.video:
                        extn.AddRange(this.videoExtn);
                        break;

                    case fileTypeConstant.images:
                        extn.AddRange(this.imageExtn);
                        break;

                    case fileTypeConstant.documents:
                        extn.AddRange(this.documentExtn);
                        break;

                    case fileTypeConstant.all:
                        extn.Concat(this.audioExtn).
                        Concat(this.videoExtn).
                        Concat(this.imageExtn).
                        Concat(this.documentExtn);
                        break;
                }
            });



            foreach (searchFolder folder in folders)
            {
                foreach (string file in Directory.EnumerateFiles(
                            folder.folderPath,
                            "*",
                            SearchOption.AllDirectories)
                            )
                {


                }
            }

            return 1;

        }


    }

}