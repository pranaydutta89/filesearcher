using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fileSearcher.Models;
using fileSearcher.interfaces;
using fileSearcher.constants;

namespace fileSearcher.Controllers
{
    public class StartController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IAppConfig _appConfig;
        public StartController(IFileService fileService, IAppConfig appConfig)
        {
            this._fileService = fileService;
            this._appConfig = appConfig;

        }

        // [Route("start/fileTypes")]
        // [HttpGet]
        // public IActionResult getfileTypes()
        // {
        //     return Json(fileTypes);
        // }

        [Route("start/fileList")]
        [HttpGet]
        public IActionResult getFileList()
        {
            return Json(_fileService.folderList);
        }

        [Route("start/fileList")]
        [HttpPut]
        public IActionResult putFileList([FromBody] IList<searchFolder> folderList)
        {
            return Json(_fileService.updateFolderListFile(folderList));
        }

        public IActionResult start()
        {

            return View(this._fileService.IsFileLocationsSet ? "Index" : "Start");
        }

    }
}
