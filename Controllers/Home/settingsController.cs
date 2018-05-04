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
    public partial class HomeController : Controller
    {


        [Route("settings/folderList")]
        [HttpGet]
        public IActionResult getFolderList()
        {
            return Json(_settingsService.folderList);
        }

        [Route("settings/folderList")]
        [HttpPut]
        public IActionResult putFolderList([FromBody] IList<searchFolderModel> folderList)
        {
            return Json(_settingsService.updateFolderListFile(folderList));
        }

        [Route("settings/fileTypes")]
        [HttpPut]
        public IActionResult putFileType([FromBody] IList<fileTypeModel> fileType)
        {
            return Json(_settingsService.updateFileType(fileType));
        }



        [Route("settings/fileTypes")]
        [HttpGet]
        public IActionResult getFileTypes()
        {
            return Json(_settingsService.fileTypeList);
        }





        public IActionResult Settings()
        {
            return View();
        }
        public IActionResult start()
        {

            if (this._settingsService.isFolderListSet && this._settingsService.isFileTypeSet)
            {
                return Redirect("Home/Me");
            }
            else
            {
                return Redirect("Home/Settings");
            }
        }

    }
}
