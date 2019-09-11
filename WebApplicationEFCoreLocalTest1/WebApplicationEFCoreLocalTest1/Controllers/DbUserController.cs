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

        public IActionResult Delete(int id)
        {
            var msg = Repository.Delete(id) > 0 ? "Success" : "Fail";
            return Json(new { Message = msg, Data = id });
        }

        public IActionResult Update(UserEntity newUser)
        {
            var msg = Repository.Update(newUser) > 0 ? "Success" : "Fail";
            return Json(new { Message = msg, Data = newUser });
        }

        public IActionResult QueryById(int id)
        {
            var user = Repository.QueryById(id);
            return Json(new { Data = user });
        }

        public IActionResult QueryAll()
        {
            var users = Repository.QueryAll();
            return Json(new { Data = users });
        }

        public IActionResult QueryByAge(short age)
        {
            var users = Repository.QueryByAge(age);
            return Json(new { Data = users });
        }
        public IActionResult QueryNamesByAge(short age)
        {
            var userNames = Repository.QueryNamesByAge(age);
            return Json(new { Data = userNames });
        }

        public IActionResult QueryPaging(int pageSize, int pageIndex)
        {
            var users = Repository.QueryUserPaging(pageSize, pageIndex);
            return Json(new { Data = users });
        }

        public IActionResult FixAge()
        {
            var count = Repository.FixAgeByTrans();
            List<UserEntity> users = null;
            if (count > 0)
            {
                users = Repository.QueryAll();
            }
            return Json(new { Count = count, Data = users });
        }
        #region 自动生成的代码
        //// GET: DbUser
        //public ActionResult Index()
        //{
        //    return Content("测试EF Core访问数据库");
        //    //return View();
        //}

        //// GET: DbUser/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: DbUser/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: DbUser/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DbUser/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: DbUser/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DbUser/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: DbUser/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        #endregion
    }

}
