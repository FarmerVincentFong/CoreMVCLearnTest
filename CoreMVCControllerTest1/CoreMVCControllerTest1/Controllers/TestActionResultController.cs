using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCControllerTest1.Controllers
{
    /// <summary>
    /// 用来测试操作结果(ActionResult)
    /// </summary>
    public class TestActionResultController : Controller
    {
        public IActionResult Index()
        {
            return Content("TestActionResultController");
        }
        public IActionResult CRTest()
        {
            return Content("Content Result Test! By FWQ!");
        }

        public IActionResult JsonTest()
        {
            return Json(new { Message = "Json Result Test!", Author = "FWQ" });
        }

        public IActionResult FileTest()
        {
            byte[] tempFileData = Encoding.Default.GetBytes("FileResult Test By FWQ! 返回文件结果测试！");
            return File(tempFileData, "application/text", "fileresult.txt");
        }

        public IActionResult RedirectTest()
        {
            return Redirect("https://www.baidu.com");
        }

        public IActionResult RedirectToActionTest()
        {
            return RedirectToAction("JsonTest");
        }
        public IActionResult RedirectToRouteTest()
        {
            return RedirectToRoute("Default", new { controller = "Home", Action = "Time" });
        }
    }
}