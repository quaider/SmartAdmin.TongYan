using System;
using System.Collections.Generic;

namespace TongYan.Web.Controls.DataGrid.Options
{
    /// <summary>
    /// DataTable最外层配置封装
    /// </summary>
    public class GridControlOptions : DefaultWebControlMultipleOptions<object>
    {
        public GridControlOptions()
        {
            ColumnBuilder = new GridColumnBuilder();
            Render = new GridControlRender();
            ItemOptions = new List<IOptionKey>();
        }

        /// <summary>
        /// DataTable列定义
        /// </summary>
        public GridColumnBuilder ColumnBuilder { get; }
    }
}
