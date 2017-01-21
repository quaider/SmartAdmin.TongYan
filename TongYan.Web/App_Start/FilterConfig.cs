using System.Web;
using System.Web.Mvc;
using TongYan.Web.Extensions;
using TongYan.Web.SmartSearch;

namespace TongYan.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //通用查询模型绑定
            ModelBinders.Binders.Add(typeof(SearchModel), new SearchModelBinder());
        }
    }
}
