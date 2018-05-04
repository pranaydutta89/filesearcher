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
            ".mp3",
            ".wav"
        };

        private List<string> videoExtn = new List<string>(){
            ".mp4",
            ".mpeg",
            ".mpg"
        };


        private List<string> documentExtn = new List<string>(){
            ".docx",
            ".pptx",
            ".pdf"
        };

        private List<string> imageExtn = new List<string>(){
            ".jpg",
            ".png",
            ".gif"
        };


        public fileService(IAppConfig appConfig)
        {
            this._appConfig = appConfig;

        }

        public IList<fileModel> getFileList(int start, int take)
        {


            using (var db = new fileSearcherContext())
            {
                return db.files.Skip(start).Take(take).ToList();
            }

        }

        public fileTypeConstant getFileType(string name)
        {
            if (audioExtn.Contains(new FileInfo(name).Extension))
            {
                return fileTypeConstant.audio;
            }
            else if (videoExtn.Contains(new FileInfo(name).Extension))
            {
                return fileTypeConstant.video;
            }
            else if (imageExtn.Contains(new FileInfo(name).Extension))
            {
                return fileTypeConstant.images;
            }
            else if (documentExtn.Contains(new FileInfo(name).Extension))
            {
                return fileTypeConstant.documents;
            }
            else
            {
                return fileTypeConstant.unknown;
            }
        }

        public bool isThereAnyFiles
        {
            get
            {
                using (var db = new fileSearcherContext())
                {
                    return db.files.ToList().Count != 0;
                }
            }
        }

        public Task<int> scanFiles()
        {
            return Task.Factory.StartNew(() =>
            {
                List<fileTypeModel> types;
                List<searchFolderModel> folders;
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

                List<fileModel> files = new List<fileModel>();
                using (var db = new fileSearcherContext())
                {

                    foreach (searchFolderModel folder in folders)
                    {
                        foreach (string filePath in Directory.EnumerateFiles(
                                    folder.folderPath,
                                    "*",
                                    SearchOption.AllDirectories)
                                    )
                        {

                            FileInfo info = new FileInfo(filePath);

                            if ((!extn.Contains(info.Extension.ToLower())) &&
                             types.Find(r => r.type == fileTypeConstant.all) == null)
                            {
                                continue;
                            }

                            fileModel file = new fileModel()
                            {
                                name = info.Name,
                                path = filePath,
                                type = this.getFileType(filePath),
                                createdDateTime = info.CreationTime,
                                modifiedDateTime = info.LastWriteTime
                            };


                            if (db.files.Where(a => a.name == file.name && a.path == file.path).SingleOrDefault() == null)
                            {
                                files.Add(file);
                            }
                        }

                    }

                    if (files.Count != 0)
                    {
                        db.files.AddRange(files);
                        db.SaveChanges();
                    }
                }

                return files.Count;
            });

        }


    }

}