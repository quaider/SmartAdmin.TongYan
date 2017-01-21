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
            Page = 0;
            PageSize = 10;
        }

        /// <summary>
        /// datatable绘制序列中的序列标识(datatable自动传入)
        /// </summary>
        public int Draw { get; set; }

        /// <summary>
        /// 记录(Record)的起始数目
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 每页显示的记录数目
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 排序列名
        /// </summary>
        public string Order { get; set; }

        /// <summary>
        /// 排序方向
        /// </summary>
        public string OrderDir { get; set; }

    }
}