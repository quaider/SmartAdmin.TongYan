using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TongYan.Web.Models;

namespace TongYan.Web.Areas.Demo.Controllers
{
    public class SelectController : Controller
    {
        // GET: Demo/Select
        public ActionResult Index()
        {
            var model = new EmployeeQueryModel { DptName = "3,5" };
            return View(model);
        }
    }
}