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
        /// DataTable绘制回调(如给新创建的元素添加事件、新数据的额外控制)
        /// https://datatables.net/reference/option/drawCallback
        /// </summary>
        public string DrawCallback { get; set; }

        public string FooterCallback { get; set; }

        public string FormatNumber { get; set; }
    }
}
