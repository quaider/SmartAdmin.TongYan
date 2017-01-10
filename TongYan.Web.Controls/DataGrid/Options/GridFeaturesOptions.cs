namespace TongYan.Web.Controls.DataGrid.Options
{
    /// <summary>
    /// DataTables Features
    /// </summary>
    public class GridFeaturesOptions
    {
        public GridFeaturesOptions()
        {
            Paging = true;
            Processing = true;
            Searching = true;
            ServerSide = true;
        }

        /// <summary>
        /// 启用或禁用 列宽自动计算
        /// Enable or disable automatic column width calculation
        /// </summary>
        public bool AutoWidth { get; set; }

        /// <summary>
        /// 是否启用 管道加载
        /// 一般不会用到，原文档 https://datatables.net/reference/option/deferRender
        /// </summary>
        public bool DeferRender { get; set; }

        /// <summary>
        /// 是否启用 信息显示(是分页等信息么?)
        /// https://datatables.net/reference/option/info
        /// </summary>
        public bool Info { get; set; }

        /// <summary>
        /// 启用或禁用 分页长度变更
        /// Enable or disable user ability to change number of records per page:
        /// </summary>
        public bool LengthChange { get; set; }

        /// <summary>
        /// 启用会禁用表格排序
        /// </summary>
        public bool Ordering { get; set; }

        /// <summary>
        /// 启用会禁用表格分页
        /// </summary>
        public bool Paging { get; set; }

        /// <summary>
        /// 启用加载过渡(loading or 处理中...)
        /// </summary>
        public bool Processing { get; set; }

        /// <summary>
        /// 启用或禁用横向滚动
        /// </summary>
        public bool ScrollX { get; set; }

        /// <summary>
        /// 启用或禁用垂直滚动(高度字符，CSS unit, or a number，如200px,超出改长度即滚动)
        /// https://datatables.net/reference/option/scrollY
        /// </summary>
        public string ScrollY { get; set; }

        /// <summary>
        /// 启用或禁用搜索功能
        /// </summary>
        public bool Searching { get; set; }

        /// <summary>
        /// 启用或禁用服务端数据处理
        /// https://datatables.net/reference/option/serverSide
        /// </summary>
        public bool ServerSide { get; set; }
    }
}