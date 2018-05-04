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
    public partial class HomeController : Controller
    {

        private readonly IFileService _fileService;
        private readonly ISettingsService _settingsService;
        private readonly IAppConfig _appConfig;
        public HomeController(IFileService fileService, IAppConfig appConfig,ISettingsService settingsService)
        {
            this._fileService = fileService;
            this._appConfig = appConfig;
            this._settingsService = settingsService;

        }


        [Route("home/scan")]
        [HttpGet]
        public IActionResult scanFiles()
        {
            return Json(_fileService.scanFiles());
        }

        public IActionResult Me()
        {
            return View();
        }

    }
}
