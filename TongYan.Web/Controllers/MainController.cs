using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TongYan.Web.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Test()
        {
            System.Threading.Thread.Sleep(1500);

            return Content("a test!");
        }

        public ActionResult GetTreeData(string id, string name, int? lv)
        {
            lv = lv ?? 0;
            if (lv > 0)
            {
                System.Threading.Thread.Sleep(1500);
            }

            var obj = new List<object>();

            for (var i = 0; i < 5; i++)
            {
                obj.Add(new
                {
                    id = id + i,
                    isParent = lv < 2 && i % 2 != 0,
                    name = (string.IsNullOrEmpty(name) ? "n" : (name + ".")) + i
                });
            }

            return Json(obj);
        }
    }
}