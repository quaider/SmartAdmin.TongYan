using System;
using System.Collections.Generic;

namespace TongYan.Web.Controls.DataGrid.Options
{
    public class GridControlOptions : DefaultWebControlOptions<object>
    {
        private readonly GridColumnBuilder _columnBuilder;

        public GridControlOptions()
        {
            _columnBuilder = new GridColumnBuilder();
            Render = new GridControlRender();
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
