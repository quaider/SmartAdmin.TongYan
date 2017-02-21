using System.Web;
using System.Web.Optimization;

namespace TongYan.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //jquery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/wwwroot/lib/jquery/jquery-{version}.js"));

            //jquery validations
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/wwwroot/lib/jquery-validation/jquery.validate*",
                        "~/wwwroot/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive*"));

            //bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/wwwroot/lib/bootstrap/js/bootstrap.js"));

            //datatable
            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                      "~/wwwroot/lib/jquery-datatable/js/jquery.dataTables.js",
                      "~/wwwroot/lib/jquery-datatable/js/dataTables.bootstrap.js",
                      "~/wwwroot/lib/jquery-datatable/js/dataTables.buttons.js",
                      "~/wwwroot/lib/jquery-datatable/js/dataTables.responsive.js",

                      "~/wwwroot/lib/jquery-datatable/js/buttons.bootstrap.js",
                      "~/wwwroot/lib/jquery-datatable/js/buttons.bootstrap.js",
                      "~/wwwroot/lib/jquery-datatable/js/buttons.colVis.js"
                      //"~/wwwroot/lib/jquery-datatable.pagination.input.js"
                      ));

            //other components
            bundles.Add(new ScriptBundle("~/bundles/components").Include(
                      "~/wwwroot/lib/jquery-slimscroll/jquery.slimscroll.js",
                      "~/wwwroot/lib/jquery-select2/select2.js",
                      "~/wwwroot/lib/jquery-select2/i18n/zh-CN.js",
                      "~/wwwroot/lib/layer/layer.js",

                      "~/wwwroot/lib/star-rating/js/star-rating.js",
                      "~/wwwroot/lib/star-rating/themes/krajee-fa/theme.js",

                      "~/wwwroot/lib/zTree/js/jquery.ztree.core.js",
                      "~/wwwroot/lib/zTree/js/jquery.ztree.excheck.js",
                      "~/wwwroot/lib/zTree/js/jquery.ztree.exedit.js",

                      "~/wwwroot/lib/highchart/highcharts.js"));

            //程序启动初始化js(仅iframe外层引用)
            bundles.Add(new ScriptBundle("~/bundles/appStarter").Include(
                      "~/wwwroot/js/core/ty.menu.js",
                      "~/wwwroot/js/core/ty.app.js"));

            //all css
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/wwwroot/lib/bootstrap/css/bootstrap.css",
                      "~/wwwroot/css/fontawesome/css/font-awesome.css",
                      "~/wwwroot/lib/jquery-select2/css/select2.css",

                      "~/wwwroot/lib/jquery-datatable/css/dataTables.bootstrap.css",
                      "~/wwwroot/lib/jquery-datatable/css/buttons.bootstrap.css",
                      "~/wwwroot/lib/jquery-datatable/css/responsive.bootstrap.css",

                      "~/wwwroot/lib/zTree/css/awesomeStyle/awesome.css",
                      "~/wwwroot/lib/zTree/css/awesomeStyle/awesome.fixed.css",

                      "~/wwwroot/css/site.css"));

            bundles.Add(new StyleBundle("~/Content/iframeAdapter").Include(
                      "~/wwwroot/css/iframe.css"));
        }
    }
}
