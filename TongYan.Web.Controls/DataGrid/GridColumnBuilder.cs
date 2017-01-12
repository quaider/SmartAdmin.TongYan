using System.Collections.Generic;

namespace TongYan.Web.Controls.DataGrid
{
    public class GridColumnBuilder : List<GridColumn>
    {
        /// <summary>
        /// 设置列的数据源及列名称标识(他们会被同时设置)
        /// </summary>
        /// <param name="fileName">列名称标识和数据源名称</param>
        /// <returns></returns>
        IGridColumn Name(string fileName)
        {
            var gridColumn = new GridColumn(fileName);
            Add(gridColumn);

            return gridColumn;
        }
    }
}