using System;
using System.Collections.Generic;
using System.Linq;

namespace TongYan.Web.Controls.DataGrid.Options
{
    /// <summary>
    /// DataTable最外层配置封装
    /// </summary>
    public class GridControlOptions : DefaultWebControlMultipleOptions<object>
    {
        public GridControlOptions()
        {
            ColumnBuilders = new List<GridColumnsBuilder>();
            Render = new GridControlRender();
            ItemOptions = new List<IOptionKey>();
        }

        /// <summary>
        /// DataTable列定义
        /// </summary>
        public IList<GridColumnsBuilder> ColumnBuilders { get; }
    }
}
