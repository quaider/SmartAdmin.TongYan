using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TongYan.Web.Areas.Demo.Models;
using TongYan.Web.Models;

namespace TongYan.Web.Areas.Demo.Controllers
{
    public class DataGridController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData(GridQuery query)
        {
            System.Threading.Thread.Sleep(500);

            var data = new List<EmployeeDemo>
            {
                new EmployeeDemo("admin", "Jeffery Li", "Windows Presentation Foundation", "15900000000", "Male"),
                new EmployeeDemo("tester", "Jenny Chen", "Windows Communication Foundation", "18899999999", "Female"),
                new EmployeeDemo("zkwin", "Quaider Zh", "TongYan Digital Dev Department", "18812345678", "Male")
            };

            for (var i = 1; i < 100; i++)
            {
                data.Add(new EmployeeDemo("admin", "Jeffery Li", "Windows Presentation Foundation", "15900000000", "Male", i.ToString()));
                data.Add(new EmployeeDemo("tester", "Jenny Chen", "Windows Communication Foundation", "18899999999", "Female", i.ToString()));
                data.Add(new EmployeeDemo("zkwin", "Quaider Zh", "TongYan Digital Dev Department", "18812345678", "Male", i.ToString()));
            }

            var result = data
                .OrderBy(f => f.UserName).Skip(query.Start).Take(query.Length);

            var r = new
            {
                recordsTotal = data.Count,
                recordsFiltered = data.Count,
                data = result
            };

            return Json(r, JsonRequestBehavior.AllowGet);
        }
    }
}