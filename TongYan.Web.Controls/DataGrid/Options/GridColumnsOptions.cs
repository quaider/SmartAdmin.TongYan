namespace TongYan.Web.Controls.DataGrid.Options
{
    /// <summary>
    /// 列定义
    /// </summary>
    public class GridColumnsOptions
    {
        public GridColumnsOptions()
        {

        }

        /// <summary>
        /// 列宽
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// 列可见性
        /// </summary>
        public bool Visible { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        /// <summary>
        /// 是否可搜索
        /// </summary>
        public bool Searchable { get; set; }

        /// <summary>
        /// 列呈现器(格式化较常用)
        /// </summary>
        public string Render { get; set; }

        /// <summary>
        /// js array
        /// https://datatables.net/reference/option/columns.orderSequence
        /// </summary>
        public string OrderSequence { get; set; }

        /// <summary>
        /// 可否排序
        /// </summary>
        public bool Orderable { get; set; }

        /// <summary>
        /// 列名称标识
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 列的默认内容
        /// https://datatables.net/reference/option/columns.defaultContent
        /// </summary>
        public string DefaultContent { get; set; }

        /// <summary>
        /// 列数据源，一般就用简单的字符串就好了；其他的取值较复杂，请参考以下链接，
        /// https://datatables.net/reference/option/columns.data
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Cell created callback to allow DOM manipulation.
        /// </summary>
        public string CreatedCell { get; set; }

        private string _className;
        /// <summary>
        /// Class to assign to each cell in the column.
        /// </summary>
        public string ClassName
        {
            get { return _className; }
            set { _className = value; }
        }

        private string _align;
        /// <summary>
        /// center left right
        /// </summary>
        public string Align
        {
            get { return _align; }
            set { _align = value; }
        }

        /// <summary>
        /// 列类型(默认td)
        /// </summary>
        protected string CellType { get; set; }
    }
}