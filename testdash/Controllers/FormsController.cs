using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testdash.StaticClasses;

namespace testdash.Controllers
{
    public class FormsController : Controller
    {
        public static string id = RandomGenarator.RandomString(5);
        public static class GlobalValues
        {
            public static string data = RandomGenarator.RandomString(5);
        }
        public IActionResult Index()
        {
            
            return View();
        }
        [Route("F/Create/{id?}")]
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
