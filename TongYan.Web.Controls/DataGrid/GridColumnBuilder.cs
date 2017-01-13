using System;
using System.Collections.Generic;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.DataGrid
{
    public class GridColumnBuilder : List<GridColumn>, IGridColumnBuilderApi
    {
        IGridColumn IGridColumnBuilderApi.Column(string name)
        {
            var column = new GridColumn(name);
            if (!Exists(f => f.ColumnOptions.Name == name))
                Add(column);
            return column;
        }
    }
}