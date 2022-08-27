using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using testdash.Models;

namespace testdash.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            var cookie = Request.Cookies["SesseonTime"];
            if(cookie == "Expired" || cookie == null)
            {
                return RedirectToAction("LockScreen");
            }
            
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult Check()
        {
            return View();
        }
        [Route("LockScreen")]
        public IActionResult LockScreen()
        {
            string chk = Request.Cookies["LoginCookie"];
            if (chk == null)
            {
                return RedirectToAction("Login");
            }
            var final = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(chk));
            string[] uu = final.Split("&&split&&");
            ViewBag.user = uu[0];
            return View();
        }
        [HttpPost]
        [Route("LockScreen")]
        public IActionResult LockScreen(string Pass)
        {
            string chk = Request.Cookies["LoginCookie"];
            var final = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(chk));
            string[] uu = final.Split("&&split&&");

            if (Pass == uu[1])
            {
                string key = "SesseonTime";
                string value = (DateTime.UtcNow.AddHours(6.5)).ToString();
                CookieOptions co = new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddHours(6.5)
                };
                Response.Cookies.Append(key, value, co);
            }
            return RedirectToAction("Index");
        }
        
        [Route("Auth")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("Auth")]
        public IActionResult Login(string username, string password)
        {
            if(username == "snp" && password == "123")
            {
                string key = "SesseonTime";
                string keyl = "LoginCookie";
                string value = (DateTime.UtcNow.AddHours(6.5)).ToString();
                string valuel = username + "&&split&&"+ password;
                string final = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(valuel));
                CookieOptions co = new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddHours(6.5)
                };
                Response.Cookies.Append(key, value, co);
                CookieOptions lo = new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddHours(30)
                };
                Response.Cookies.Append(keyl, final, lo);

            }
            return RedirectToAction("Index");
        }







        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
