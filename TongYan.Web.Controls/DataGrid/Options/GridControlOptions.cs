using System;
using System.Collections.Generic;

namespace TongYan.Web.Controls.DataGrid.Options
{
    /// <summary>
    /// DataTable最外层配置封装
    /// </summary>
    public class GridControlOptions : DefaultWebControlMultipleOptions<object>
    {
        /// <summary>
        /// 列组装
        /// </summary>
        private readonly GridColumnBuilder _columnBuilder;

        public GridControlOptions()
        {
            _columnBuilder = new GridColumnBuilder();
            Render = new GridControlRender();
            ItemOptions = new List<IOptionKey>();
        }

        /// <summary>
        /// DataTable列定义
        /// </summary>
        public IList<GridColumn> Columns
        {
            get { return _columnBuilder; }
        }
    }
}
