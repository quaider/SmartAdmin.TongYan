using System.Collections.Generic;

namespace TongYan.Web.Controls.DataGrid.Options
{
    /// <summary>
    /// DataTables Data
    /// </summary>
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
        /// 3、function:Custom data get function, 一些用法请参考以下文档
        /// https://datatables.net/reference/option/ajax
        /// </summary>
        public GridDataAjaxOptions Ajax { get; set; }
    }

    /// <summary>
    /// GridDataOptions for ajax options
    /// </summary>
    public class GridDataAjaxOptions
    {
        /// <summary>
        /// 提供数据的Url地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 提供DataTable所需的数据，如果给其设定值，将忽略其他ajax设置(互斥)
        /// </summary>
        public string AjaxFunction { get; set; }

        /// <summary>
        /// 发送到服务器的参数 data:{user_id:451} or data: function(d){ d.some_name = $('#element').val(); }
        /// or data: function(d) { return $.extend({}, d, {some_name: $('#element').val()}); }
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// 主体数据的根定义(默认是data)
        /// </summary>
        public string DataSrc { get; set; }
    }
}