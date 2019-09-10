using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationEFCoreLocalTest1.Models;
using WebApplicationEFCoreLocalTest1.Repositories;


namespace WebApplicationEFCoreLocalTest1.Controllers
{
    public class DbUserController : Controller
    {
        private UserRepository Repository { get; }
        public DbUserController(UserRepository repos)
        {
            //注入UserRepository
            this.Repository = repos;
        }

        [HttpPost]
        public IActionResult AddUser(UserEntity newUser)
        {
            var msg = Repository.Add(newUser) > 0 ? "Success" : "Fail";
            return Json(new { Message = msg, Data = newUser });
        }

        #region 自动生成的代码
        // GET: DbUser
        public ActionResult Index()
        {
            return Content("测试EF Core访问数据库");
            //return View();
        }

        // GET: DbUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DbUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DbUser/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DbUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DbUser/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DbUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DbUser/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }

}
