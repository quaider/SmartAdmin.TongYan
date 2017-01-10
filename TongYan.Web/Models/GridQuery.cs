using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TongYan.Web.Models
{
    /// <summary>
    /// Datatable查询参数(后续改为abstract)
    /// </summary>
    public class GridQuery
    {
        public GridQuery()
        {
            //设置默认值
            Draw = 1;
            Start = 0;
            Length = 10;
        }

        /// <summary>
        /// datatable绘制序列中的序列标识(datatable自动传入)
        /// </summary>
        public int Draw { get; set; }

        /// <summary>
        /// 记录(Record)的起始数目
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// 每页显示的记录数目
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 全局搜索条件， 针对于每一列(匹配标识了Searchable=true的列)
        /// </summary>
        public GridSearch Search { get; set; }

        /// <summary>
        /// 排序(or 多列排序)
        /// </summary>
        public List<GridSort> Order { get; set; }

        /// <summary>
        /// 数据列
        /// </summary>
        public List<GridColumn> Columns { get; set; }

        /// <summary>
        /// 返回指定索引的列信息
        /// </summary>
        /// <param name="index">列索引</param>
        /// <returns>前台传递的数据列信息</returns>
        public GridColumn this[int index]
        {
            get { return Columns == null || !Columns.Any() ? null : Columns[index]; }
        }
    }

    /// <summary>
    /// 封装搜索条件
    /// </summary>
    public class GridSearch
    {
        /// <summary>
        /// 搜索条件的值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 搜索条件的值是否作为正则表达式处理
        /// </summary>
        public bool Regex { get; set; }
    }

    /// <summary>
    /// 封装datatable排序
    /// </summary>
    public class GridSort
    {
        /// <summary>
        /// 排序列的索引
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// 排序方向
        /// </summary>
        public GridSortDirection Dir { get; set; }
    }

    public enum GridSortDirection
    {
        Asc,
        Desc
    }

    /// <summary>
    /// grid查询列信息
    /// </summary>
    public class GridColumn
    {
        /// <summary>
        /// 列数据源名称
        /// Set the data source for the column from the rows data object / array.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// 列名称标识(column API提供两种方式访问列, 列索引及列名称)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否可查询
        /// </summary>
        public bool Searchable { get; set; }

        /// <summary>
        /// 是否可排序
        /// </summary>
        public bool Orderable { get; set; }

        /// <summary>
        /// 当前列的搜索条件
        /// </summary>
        public GridSearch Search { get; set; }
    }
}