using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TongYan.Web.Controls.Select;
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

        public ActionResult GetFirst()
        {
            return Json(First(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSecond(string first)
        {
            return Json(Second(first), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetThird(string second)
        {
            return Json(Third(second), JsonRequestBehavior.AllowGet);
        }

        #region 测试代码

        private List<SelectModel> First()
        {
            return new List<SelectModel>
            {
                new SelectModel("1_bj", "北京"),
                new SelectModel("1_sh", "上海"),
                new SelectModel("1_hb", "湖北"),
                new SelectModel("1_hn", "湖南"),
            };
        }

        private List<SelectModel> Second(string value)
        {
            var list = new List<SelectModel>();
            switch (value)
            {
                case "1_bj":
                    list.AddRange(new List<SelectModel>
                    {
                        new SelectModel("2_bj", "北京"),
                    });
                    break;
                case "1_sh":
                    list.AddRange(new List<SelectModel>
                    {
                        new SelectModel("2_sh", "上海"),
                    });
                    break;
                case "1_hb":
                    list.AddRange(new List<SelectModel>
                    {
                        new SelectModel("2_wh", "武汉"),
                        new SelectModel("2_xf", "襄樊"),
                        new SelectModel("2_jz", "荆州"),
                        new SelectModel("2_hs", "黄石")
                    });
                    break;
                case "1_hn":
                    list.AddRange(new List<SelectModel>
                    {
                        new SelectModel("2_cs", "长沙"),
                        new SelectModel("2_hy", "衡阳")
                    });
                    break;
            }
            return list;
        }

        private List<SelectModel> Third(string second)
        {
            var list = new List<SelectModel>();
            switch (second)
            {
                case "2_bj":
                    list.AddRange(new List<SelectModel>
                    {
                        new SelectModel("3_dcq", "东城区"),
                        new SelectModel("3_mtgq", "门头沟区"),
                        new SelectModel("3_hdq", "海定区")
                    });
                    break;
                case "2_sh":
                    list.AddRange(new List<SelectModel>
                    {
                        new SelectModel("3_hpq", "黄浦区"),
                        new SelectModel("3_xhq", "徐汇区"),
                        new SelectModel("3_ypq", "杨浦区"),
                        new SelectModel("3_bsq", "宝山区")
                    });
                    break;
                case "2_wh":
                    list.AddRange(new List<SelectModel>
                    {
                        new SelectModel("3_jaq", "江岸区"),
                        new SelectModel("3_wcq", "武昌区"),
                        new SelectModel("3_dxhq", "东西湖区"),
                        new SelectModel("3_qsq", "青山区")
                    });
                    break;
                case "2_xf":
                    list.AddRange(new List<SelectModel>
                    {
                        new SelectModel("3_xzq", "襄州区"),
                        new SelectModel("3_xcq", "襄城区")
                    });
                    break;
                case "2_jz":
                    list.AddRange(new List<SelectModel>
                    {
                        new SelectModel("3_ga", "公安"),
                        new SelectModel("3_ss", "沙市")
                    });
                    break;
                case "2_hs":
                    list.AddRange(new List<SelectModel>
                    {
                        new SelectModel("3_xssq", "西塞山区"),
                        new SelectModel("3_tcsq", "团成山区")
                    });
                    break;
                case "2_cs":
                    list.AddRange(new List<SelectModel>
                    {
                        new SelectModel("3_frq", "芙蓉区"),
                        new SelectModel("3_ylq", "岳麓区")
                    });
                    break;
                case "2_hy":
                    list.AddRange(new List<SelectModel>
                    {
                        new SelectModel("3_zhq", "珠晖区"),
                        new SelectModel("3_nyq", "南岳区")
                    });
                    break;
            }

            return list;
        }

        #endregion
    }
}