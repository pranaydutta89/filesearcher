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
    public class StartController : Controller
    {
        private readonly IFileService _fileService;
        public StartController(IFileService fileService)
        {
            this._fileService = fileService;

        }

        [HttpGet]
        public IActionResult fileList()
        {
            return Json(new { a = "dasd" });
        }

        public IActionResult start()
        {

            return View(this._fileService.IsFileLocationsSet ? "Index" : "Start");
        }

    }
}
