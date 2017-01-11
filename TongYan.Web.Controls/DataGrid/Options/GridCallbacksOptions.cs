using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TongYan.Web.Controls.DataGrid.Options
{
    /// <summary>
    /// DataTable Callbacks
    /// </summary>
    public class GridCallbacksOptions
    {
        /// <summary>
        /// 行创建回调(可以自定义行样式、行事件等) function(row, data, dataIndex)
        /// https://datatables.net/reference/option/createdRow
        /// </summary>
        public string CreatedRow { get; set; }

        /// <summary>
        /// DataTable开始绘制前的回调
        /// </summary>
        public string PreDrawCallback { get; set; }

        /// <summary>
        /// DataTable绘制回调(如给新创建的元素添加事件、新数据的额外控制)
        /// https://datatables.net/reference/option/drawCallback
        /// </summary>
        public string DrawCallback { get; set; }

        /// <summary>
        /// Table Foot创建事件
        /// </summary>
        public string FooterCallback { get; set; }

        /// <summary>
        /// Number formatting callback function.
        /// https://datatables.net/reference/option/formatNumber
        /// </summary>
        public string FormatNumber { get; set; }

        /// <summary>
        /// This function is called on every 'draw' event 
        /// when a filter, sort or page event is initiated by the end user or the API
        /// https://datatables.net/reference/option/headerCallback
        /// </summary>
        public string HeaderCallback { get; set; }

        /// <summary>
        /// Table summary information display callback.
        /// https://datatables.net/reference/option/infoCallback
        /// </summary>
        public string InfoCallback { get; set; }

        /// <summary>
        /// 初始化完成回调, 包含ajax数据请求完成
        /// https://datatables.net/reference/option/initComplete
        /// </summary>
        public string InitComplete { get; set; }

        /// <summary>
        /// Row draw callback(行绘制 但是没有添加到dom中)
        /// </summary>
        public string RowCallback { get; set; }

        /// <summary>
        /// Callback that defines where and how a saved state should be loaded.
        /// https://datatables.net/reference/option/stateLoadCallback
        /// </summary>
        public string StateLoadCallback { get; set; }

        /// <summary>
        /// State loaded callback.
        /// https://datatables.net/reference/option/stateLoaded
        /// </summary>
        public string StateLoaded { get; set; }

        /// <summary>
        /// State loaded - data manipulation callback.
        /// this function is used to manipulate the data once it has been retrieved from storage
        /// https://datatables.net/reference/option/stateLoadParams
        /// </summary>
        public string StateLoadParams { get; set; }

        /// <summary>
        /// Callback that defines how and where the table state is stored.
        /// https://datatables.net/reference/option/stateSaveCallback
        /// </summary>
        public string StateSaveCallback { get; set; }

        /// <summary>
        /// State save - data manipulation callback.
        /// https://datatables.net/reference/option/stateSaveParams
        /// </summary>
        public string StateSaveParams { get; set; }
    }
}
