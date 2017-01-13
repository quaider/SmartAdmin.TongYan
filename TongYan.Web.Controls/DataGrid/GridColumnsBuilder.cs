using System;
using System.Collections.Generic;
using TongYan.Web.Controls.DataGrid.Options;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.DataGrid
{
    public class GridColumnsBuilder : List<GridColumn>, IGridColumnBuilderApi
    {
        IGridColumn IGridColumnBuilderApi.Column(string name)
        {
            var column = new GridColumn(name);
            if (!Exists(f => f.ColumnOptions.Name == name))
            {
                Add(column);
            }

            return column;
        }

        public IGridColumn Column(GridColumn column)
        {
            if (!Exists(f => f.ColumnOptions.Name == column.GetColumnName()))
            {
                Add(column);
            }

            return column;
        }
    }
}