using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TongYan.Web.Areas.Demo.Controllers
{
    public class TreeController : Controller
    {
        // GET: Demo/Tree
        public ActionResult Index()
        {
            return View();
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
    }
}