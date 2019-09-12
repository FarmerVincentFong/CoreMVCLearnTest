using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationEFCoreLocalTest1.Models;
using WebApplicationEFCoreLocalTest1.Repositories;

namespace WebApplicationEFCoreLocalTest1.Controllers
{
    //EF Core使用Sql访问用户表
    public class DbSqlUserController : Controller
    {
        private UserWithSqlRepository Repository { get; }
        public DbSqlUserController(UserWithSqlRepository r)
        {
            //依赖注入
            this.Repository = r;
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UserEntity newUser)
        {
            bool bbb = await TryUpdateModelAsync<UserEntity>(newUser);
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
            var count = Repository.FixAgeByTrans1();
            List<UserEntity> users = null;
            if (count > 0)
            {
                users = Repository.QueryAll();
            }
            return Json(new { Count = count, Data = users });
        }
    }
}