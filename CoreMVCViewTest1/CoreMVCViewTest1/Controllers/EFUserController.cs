using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMVCViewTest1.Models;
using CoreMVCViewTest1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCViewTest1.Controllers
{
    //用户数据db
    public class EFUserController : Controller
    {
        //数据访问类
        private UserRepository repository { get; }
        public EFUserController(UserRepository ur)
        {
            this.repository = ur;
        }
        public IActionResult Index()
        {
            return Content("用户数据DB相关控制器！ By FWQ！");
        }

        public IActionResult Add(UserEntity user)
        {
            string msg = repository.Add(user) > 0 ? "添加成功" : "添加失败";
            return Json(new { Message = msg, User = user });
        }

    }
}