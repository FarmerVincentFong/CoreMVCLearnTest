using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCViewTest1.Controllers
{
    //测试分部视图
    public class PartialTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}