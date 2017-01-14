using System;
using System.Collections.Generic;
using TongYan.Web.Controls.DataGrid.Options;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.DataGrid
{
    /// <summary>
    /// thead中单个行tr的列组装
    /// </summary>
    public class GridColumnsBuilder : List<GridColumn>, IGridColumnBuilderApi
    {
        /// <summary>
        /// 列配置总是以一个标题作为起点
        /// </summary>
        /// <param name="title">列标题</param>
        /// <returns>IGridColumn</returns>
        IGridColumn IGridColumnBuilderApi.Title(string title)
        {
            var column = new GridColumn(title);
            Add(column);
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