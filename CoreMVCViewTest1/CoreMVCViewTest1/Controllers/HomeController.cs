using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMVCViewTest1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCViewTest1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Home/Index";
            ViewBag.Message = "Hello World Core By FWQ!";
            return View();
            //return Content($"Hello World Core By FWQ!");
        }
        //取系统当前时间
        [Route("[controller]/[action]")]
        [Route("/t/t")]
        public IActionResult Time()
        {
            ViewBag.ServerTime = DateTime.Now;
            return View();
        }

        //测试section视图
        public IActionResult SectionDemo()
        {
            return View(new Person { Name = "FangVincent", Age = 18 });
        }
    }
}