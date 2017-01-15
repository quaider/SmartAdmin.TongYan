using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TongYan.Web.Controls.DataGrid
{
    public class GridColumn4Provider
    {
        /// <summary>
        /// 列组键值
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 列标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 列名称和数据源
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 能否排序(默认可以)
        /// </summary>
        public bool? Orderable { get; set; }

        /// <summary>
        /// 能否搜索(默认可以)
        /// </summary>
        public bool? Searchable { get; set; }

        /// <summary>
        /// 行号, 单行时可不指定
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// 某行中各列的显示顺序
        /// </summary>
        public int ShowOrder { get; set; }

        /// <summary>
        /// 多行复杂表头时，数据列的解析顺序， 此属性在多行表头中非常重要，单行表头请忽略
        /// </summary>
        public int? CrossRowDataColumnsOrder { get; set; }

        /// <summary>
        /// 列显示器
        /// </summary>
        public string Render { get; set; }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool? Hidden { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// 要合并的行数
        /// </summary>
        public int? Rowspan { get; set; }

        /// <summary>
        /// 要合并的列数
        /// </summary>
        public int? Colspan { get; set; }

        /// <summary>
        /// 设置列样式
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 对齐方式(center, left, right)
        /// </summary>
        public string Align { get; set; }

        /// <summary>
        /// 列创建回调(js function name)
        /// </summary>
        public string CreatedCellCallback { get; set; }
    }
}
