using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fileSearcher.Models;
using fileSearcher.interfaces;

namespace fileSearcher.Controllers
{
    public class HomeController : Controller
    {

        private readonly IFileService _fileService;
        private readonly IAppConfig _appConfig;
        public HomeController(IFileService fileService, IAppConfig appConfig)
        {
            this._fileService = fileService;
            this._appConfig = appConfig;

        }

        public IActionResult Index()
        {
            return View();
        }




        [Route("settings/folderList")]
        [HttpGet]
        public IActionResult getFolderList()
        {
            return Json(_fileService.folderList);
        }

        [Route("settings/folderList")]
        [HttpPut]
        public IActionResult putFolderList([FromBody] IList<searchFolder> folderList)
        {
            return Json(_fileService.updateFolderListFile(folderList));
        }

         [Route("settings/fileTypes")]
        [HttpPut]
        public IActionResult putFileType([FromBody] IList<fileType> fileType)
        {
            return Json(_fileService.updateFolderListFile(folderList));
        }





        public IActionResult Settings()
        {
            return View();
        }
        public IActionResult start()
        {

            if (this._fileService.IsFolderListSet)
            {
                return Redirect("Index");
            }
            else
            {
                return Redirect("Home/Settings");
            }
        }

    }
}
