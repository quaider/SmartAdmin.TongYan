namespace TongYan.Web.Controls.DataGrid.Options
{
    /// <summary>
    /// DataTables Options
    /// </summary>
    public class GridOptions
    {
        public GridOptions()
        {
            OrderClasses = true;
        }

        /// <summary>
        /// int or array 第二次绘制时才从服务端加载数据(如果你第一页数据已存在)
        /// Delay the loading of server-side data until second draw.
        /// </summary>
        public string DeferLoading { get; set; }

        public string Destroy { get; set; }

        /// <summary>
        /// 开始显示的记录的位置
        /// </summary>
        public int DisplayStart { get; set; }

        /// <summary>
        /// 请勿设置
        /// </summary>
        protected string Dom { get; set; }

        /// <summary>
        /// js array, Change the options in the page length select list
        /// </summary>
        public string LengthMenu { get; set; }

        /// <summary>
        /// js array, 设置默认排序.
        /// eg: [[0, 'asc']], [[ 0, 'asc' ], [ 1, 'asc' ]]
        /// </summary>
        public string Order { get; set; }

        /// <summary>
        /// 复杂表头中，指定排序是应用到顶部还是底部的表头(false:底部， true:顶部)
        /// </summary>
        public bool OrderCellsTop { get; set; }

        /// <summary>
        /// 是否启用排序高亮
        /// </summary>
        public bool OrderClasses { get; set; }

        /// <summary>
        /// 固定(锁定)排序
        /// https://datatables.net/reference/option/orderFixed
        /// </summary>
        public object OrderFixed { get; set; }

        /// <summary>
        /// 是否启用多列排序
        /// </summary>
        public bool OrderMulti { get; set; }

        /// <summary>
        /// Number of rows to display on a single page when using pagination.
        /// </summary>
        public int PageLength { get; set; }

        /// <summary>
        /// 分页方式
        /// https://datatables.net/reference/option/pagingType
        /// </summary>
        public string PagingType { get; set; }

        /// <summary>
        /// https://datatables.net/reference/option/retrieve
        /// </summary>
        public bool Retrieve { get; set; }

        /// <summary>
        /// 行数据id数据源名称，用来给tr设定id,
        /// </summary>
        public string RowId { get; set; }

        /// <summary>
        /// Allow the table to reduce in height when a limited number of rows are shown
        /// https://datatables.net/reference/option/scrollCollapse
        /// </summary>
        public bool ScrollCollapse { get; set; }

        public GridSearchOptions Search { get; set; }

        /// <summary>
        /// 查询延时
        /// </summary>
        public int SearchDelay { get; set; }

        public int StateDuration { get; set; }
    }

    public class GridSearchOptions
    {
        /// <summary>
        /// 查询条件
        /// </summary>
        public string Search { get; set; }

        /// <summary>
        /// 应用正则
        /// </summary>
        public bool Regex { get; set; }

        /// <summary>
        /// 大小写敏感
        /// </summary>
        public bool CaseInsensitive { get; set; }
    }
}