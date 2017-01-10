using System.Collections.Generic;

namespace TongYan.Web.Controls.DataGrid.Options
{
    public class GridDataOptions
    {
        /// <summary>
        /// grid显示的数据(2D数据不列入支持计划)
        ///  if data is specified, the data given in the array will replace any information that was found in the table's DOM when initialised.
        /// </summary>
        public IEnumerable<object> Data { get; set; }

        /// <summary>
        /// 三种模式
        /// 1、一个url链接字符串
        /// 2、和$.ajax一样的参数对象
        /// 3、function Custom data get function
        /// </summary>
        public GridAjax Ajax { get; set; }
    }

    public class GridAjax
    {
        public string UrlMode { get; set; }

        public object AjaxMode { get; set; }

        public string FnMode { get; set; }
    }
}