using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCControllerTest1.Controllers
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
        public string TestStr()
        {
            return "TestStr";
        }
        public void DoSome()
        {
            int i = 19;
        }

        private string Test2()
        {
            return "private Test";
        }

        [NonAction]
        public string Test3()
        {
            return "non action test ";
        }
    }
}
