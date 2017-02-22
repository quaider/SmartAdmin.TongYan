using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using TongYan.Web.Areas.Demo.Models;
using TongYan.Web.Models;
using TongYan.Web.SmartSearch;

namespace TongYan.Web.Areas.Demo.Controllers
{
    public class DataGridController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData(EmployeeQueryModel query, SearchModel sm)
        {
            System.Threading.Thread.Sleep(600);

            var data = new List<EmployeeDemo>
            {
                new EmployeeDemo("admin", "Jeffery Li", "Windows Presentation Foundation", "15900000000", "Male"),
                new EmployeeDemo("tester", "Jenny Chen", "Windows Communication Foundation", "18899999999", "Female"),
                new EmployeeDemo("zkwin", "Quaider Zh", "TongYan Digital Dev Department", "18812345678", "Male")
            };

            for (var i = 1; i < 50; i++)
            {
                data.Add(new EmployeeDemo("admin", "Jeffery Li", "Windows Presentation Foundation", "15900000000", "Male", i.ToString()));
                data.Add(new EmployeeDemo("tester", "Jenny Chen", "Windows Communication Foundation", "18899999999", "Female", i.ToString()));
                data.Add(new EmployeeDemo("zkwin", "Quaider Zh", "TongYan Digital Dev Department", "18812345678", "Male", i.ToString()));
            }

            Func<EmployeeDemo, object> d = f => f.UserName;

            if (query.Order == "DptName")
                d = f => f.DptName;
            if (query.Order == "Gender")
                d = f => f.Gender;
            if (query.Order == "Tel")
                d = f => f.Tel;

            var result = data.Select(f => new
            {
                UserName = f.UserName,
                DptName = f.DptName,
                FullName = f.FullName,
                Gender = f.Gender,
                Tel = f.Tel
            }).AsQueryable().Where(sm);

            var r = new
            {
                recordsTotal = result.Count(),
                recordsFiltered = result.Count(),
                data = result.Skip(query.Page).OrderBy(f => f.UserName).Take(query.PageSize)
        };

            return Json(r, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TreeTable()
        {
            return View();
        }
    }
}