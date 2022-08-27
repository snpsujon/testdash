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
        
        [Route("Create")]
        public IActionResult Create()
        {
            if (Request.Cookies["SesseonTime"] == "Expired" || Request.Cookies["SesseonTime"] == null)
            {
                return RedirectToAction("LockScreen", "Home");
            }


            return View();
        }
        [Route("File")]
        public IActionResult FileUpload()
        {
            if (Request.Cookies["SesseonTime"] == "Expired" || Request.Cookies["SesseonTime"] == null)
            {
                return RedirectToAction("LockScreen", "Home");
            }
            return View();
        }
        [Route("Repeater")]
        public IActionResult Repeater()
        {
            if (Request.Cookies["SesseonTime"] == "Expired" || Request.Cookies["SesseonTime"] == null)
            {
                return RedirectToAction("LockScreen", "Home");
            }
            return View();
        }
        [Route("Wizard")]
        public IActionResult Wizard()
        {
            if (Request.Cookies["SesseonTime"] == "Expired" || Request.Cookies["SesseonTime"] == null)
            {
                return RedirectToAction("LockScreen", "Home");
            }
            return View();
        }


    }
}
