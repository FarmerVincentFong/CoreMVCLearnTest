using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCViewTest1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content($"Hello World Core By FWQ!");
        }
        //取系统当前时间
        [Route("[controller]/[action]")]
        [Route("/t/t")]
        public IActionResult Time()
        {
            ViewBag.ServerTime = DateTime.Now;
            return View();
        }
    }
}