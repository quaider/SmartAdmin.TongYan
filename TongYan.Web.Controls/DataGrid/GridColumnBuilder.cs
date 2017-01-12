using System;
using System.Collections.Generic;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.DataGrid
{
    public class GridColumnBuilder : List<GridColumn>
    {
        IGridColumn Name(string fileName)
        {
            var gridColumn = new GridColumn(fileName);
            Add(gridColumn);

            return gridColumn;
        }
    }
}