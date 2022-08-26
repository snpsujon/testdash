using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testdash.Controllers
{
    public class FormsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("F/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [Route("F/File")]
        public IActionResult FileUpload()
        {
            return View();
        }
        [Route("F/Repeater")]
        public IActionResult Repeater()
        {
            return View();
        }

    }
}
