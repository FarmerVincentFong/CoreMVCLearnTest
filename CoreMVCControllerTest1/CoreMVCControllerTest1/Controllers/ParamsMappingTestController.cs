using CoreMVCControllerTest1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCControllerTest1.Controllers
{
    public class ParamsMappingTestController : Controller
    {
        public IActionResult GetId(int id)
        {
            return Content($"Action params mapping test by FWQ! id:{id}");
        }

        //数组参数
        public IActionResult GetIdArr(string[] id)
        {
            var msg = "Action params mapping test by FWQ! id:";
            if (id != null)
            {
                msg += string.Join('>', id);
            }
            return Content(msg);
        }

        public IActionResult GetPerson(Person p)
        {
            return Json(new { Msg = "Action params mapping test by FWQ!", Data = p });
        }
        public IActionResult GetPersons(List<Person> ps)
        {
            return Json(new { Msg = "Action params mapping test by FWQ!", Data = ps });
        }
        public IActionResult GetPersonJson([FromBody]Person p)
        {
            return Json(new { Msg = "Action params mapping test by FWQ!", Data = p });
        }

        public IActionResult GetByHand()
        {
            return Json(new
            {
                Msg = "Action params mapping test by FWQ!"
                ,
                Data = new { id = RouteData.Values["id"], name = Request.Query["name"], age = Request.Form["age"] }
            });
        }
    }
}
