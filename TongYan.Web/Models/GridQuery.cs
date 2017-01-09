using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TongYan.Web.Models
{
    public class GridQuery
    {
        public GridQuery()
        {
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
        /// 含2个键, 分别是value(搜索条件) 和 regex(如果为 true代表全局搜索的值是作为正则表达式处理，为 false则不是)
        /// </summary>
        //public IDictionary<string, string> Search { get; set; }
        public GridSearch Search { get; set; }


    }

    public class GridSearch
    {
        public string Value { get; set; }

        public string Regex { get; set; }
    }
}