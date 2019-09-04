using CoreMVCViewTest1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCViewTest1.Controllers
{
    /// <summary>
    /// 测试视图传值
    /// </summary>
    public class RenderDataController : Controller
    {
        //测试ViewData传值
        public IActionResult ViewDataDemo()
        {
            ViewData["name"] = "FWQ";
            ViewData["bitrhday"] = new DateTime(2019, 1, 1);
            ViewData["hobby"] = new string[] { "跑步", "游戏", "阅读" };
            return View();
        }

        public IActionResult ViewBagDemo()
        {
            ViewBag.Title = "ViewBag传值示例";
            ViewBag.Name = "FWQ";
            ViewBag.Birthday = new DateTime(2019, 1, 1);
            ViewBag.Hobby = new string[] { "跑步", "游戏", "阅读" };
            return View();
        }

        public IActionResult ViewModelDemo()
        {
            ViewBag.Title = "ViewModel传值测试";
            Person p = new Person { Id = 1001, Name = "FWQ", Age = 23, Birthday = new DateTime(2019, 1, 1), Hobby = new string[] { "Run", "Jump", "Code" } };
            return View(p);
        }

        public IActionResult SharedViewDemo()
        {
            List<Person> pList = new List<Person>();
            pList.Add(new Person { Id = 1001, Age = 18, Name = "www", Birthday = new DateTime(1995, 1, 1), Hobby = new string[] { "Run", "Jump", "Code" } });
            pList.Add(new Person { Id = 2002, Age = 28, Name = "fff", Birthday = new DateTime(2000, 1, 1), Hobby = new string[] { "Run2", "Jump2", "Code2" } });
            return View("Shared1View", pList); ;
        }
    }
}
