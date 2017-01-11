using System;
using System.Collections.Generic;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.DataGrid.Options
{
    /// <summary>
    /// DataTables Options
    /// </summary>
    public class GridOptions : IOptionKey
    {
        private readonly IDictionary<string, object> _hasSetOptionsProperties;

        internal GridOptions()
        {
            _hasSetOptionsProperties = new Dictionary<string, object>();
            OrderClasses = true;
        }

        private string _deferLoading;
        /// <summary>
        /// int or array 第二次绘制时才从服务端加载数据(如果你第一页数据已存在)
        /// Delay the loading of server-side data until second draw.
        /// </summary>
        public string DeferLoading
        {
            get { return _deferLoading; }
            set
            {
                _deferLoading = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(DeferLoading).ToCamelCaseString(), value);
            }
        }

        private string _destroy;
        public string Destroy { get; set; }

        private int _displayStart;
        /// <summary>
        /// 开始显示的记录的位置
        /// </summary>
        public int DisplayStart
        {
            get { return _displayStart; }
            set
            {
                _displayStart = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(DisplayStart).ToCamelCaseString(), value);
            }
        }

        private string _dom;
        /// <summary>
        /// 请勿设置
        /// </summary>
        protected string Dom
        {
            get { return _dom; }
            set
            {
                _dom = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(Dom).ToCamelCaseString(), value);
            }
        }

        private string _lengthMenu;
        /// <summary>
        /// js array, Change the options in the page length select list
        /// </summary>
        public string LengthMenu
        {
            get { return _lengthMenu; }
            set
            {
                _lengthMenu = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(LengthMenu).ToCamelCaseString(), value);
            }
        }

        private string _order;
        /// <summary>
        /// js array, 设置默认排序.
        /// eg: [[0, 'asc']], [[ 0, 'asc' ], [ 1, 'asc' ]]
        /// </summary>
        public string Order
        {
            get { return _order; }
            set
            {
                _order = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(Order).ToCamelCaseString(), value);
            }
        }

        private bool _orderCellsTop;
        /// <summary>
        /// 复杂表头中，指定排序是应用到顶部还是底部的表头(false:底部， true:顶部)
        /// </summary>
        public bool OrderCellsTop
        {
            get { return _orderCellsTop; }
            set
            {
                _orderCellsTop = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(OrderCellsTop).ToCamelCaseString(), value);
            }
        }

        private bool _orderClasses;
        /// <summary>
        /// 是否启用排序高亮
        /// </summary>
        public bool OrderClasses
        {
            get { return _orderClasses; }
            set
            {
                _orderClasses = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(OrderClasses).ToCamelCaseString(), value);
            }
        }

        private object _orderFixed;
        /// <summary>
        /// 固定(锁定)排序
        /// https://datatables.net/reference/option/orderFixed
        /// </summary>
        public object OrderFixed
        {
            get { return _orderFixed; }
            set
            {
                _orderFixed = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(OrderFixed).ToCamelCaseString(), value);
            }
        }

        private bool _orderMulti;
        /// <summary>
        /// 是否启用多列排序
        /// </summary>
        public bool OrderMulti
        {
            get { return _orderMulti; }
            set
            {
                _orderMulti = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(OrderMulti).ToCamelCaseString(), value);
            }
        }

        private int _pageLength;
        /// <summary>
        /// Number of rows to display on a single page when using pagination.
        /// </summary>
        public int PageLength
        {
            get { return _pageLength; }
            set
            {
                _pageLength = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(PageLength).ToCamelCaseString(), value);
            }
        }

        private string _pagingType;
        /// <summary>
        /// 分页方式
        /// https://datatables.net/reference/option/pagingType
        /// </summary>
        public string PagingType
        {
            get { return _pagingType; }
            set
            {
                _pagingType = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(PagingType).ToCamelCaseString(), value);
            }
        }

        private bool _retrieve;
        /// <summary>
        /// https://datatables.net/reference/option/retrieve
        /// </summary>
        public bool Retrieve
        {
            get { return _retrieve; }
            set
            {
                _retrieve = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(Retrieve).ToCamelCaseString(), value);
            }
        }

        private string _rowId;
        /// <summary>
        /// 行数据id数据源名称，用来给tr设定id,
        /// </summary>
        public string RowId
        {
            get { return _rowId; }
            set
            {
                _rowId = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(RowId).ToCamelCaseString(), value);
            }
        }

        private bool _scrollCollapse;
        /// <summary>
        /// Allow the table to reduce in height when a limited number of rows are shown
        /// https://datatables.net/reference/option/scrollCollapse
        /// </summary>
        public bool ScrollCollapse
        {
            get { return _scrollCollapse; }
            set
            {
                _scrollCollapse = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(ScrollCollapse).ToCamelCaseString(), value);
            }
        }

        private GridSearchOptions _search;
        public GridSearchOptions Search
        {
            get { return _search; }
        }

        private int _searchDelay;
        /// <summary>
        /// 查询延时
        /// </summary>
        public int SearchDelay
        {
            get { return _searchDelay; }
            set
            {
                _searchDelay = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(SearchDelay).ToCamelCaseString(), value);
            }
        }

        private int _stateDuration;
        public int StateDuration
        {
            get { return _stateDuration; }
            set
            {
                _stateDuration = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(StateDuration).ToCamelCaseString(), value);
            }
        }

        public string OptionKey
        {
            get { return "data-grid-option"; }
        }

        IDictionary<string, object> IOptionKey.ConvertToDic()
        {
            _hasSetOptionsProperties.SetKeyValue(nameof(Search).ToCamelCaseString(), Search.ConvertToDic());

            return _hasSetOptionsProperties;
        }
    }

    public class GridSearchOptions
    {
        private readonly IDictionary<string, object> _hasSetOptionsProperties;

        public GridSearchOptions()
        {
            _hasSetOptionsProperties = new Dictionary<string, object>();
        }

        private string _search;
        /// <summary>
        /// 查询条件
        /// </summary>
        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(Search).ToCamelCaseString(), value);
            }
        }

        private bool _regex;
        /// <summary>
        /// 应用正则
        /// </summary>
        public bool Regex
        {
            get { return _regex; }
            set
            {
                _regex = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(Regex).ToCamelCaseString(), value);
            }
        }

        private bool _caseInsensitive;
        /// <summary>
        /// 大小写敏感
        /// </summary>
        public bool CaseInsensitive
        {
            get { return _caseInsensitive; }
            set
            {
                _caseInsensitive = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(CaseInsensitive).ToCamelCaseString(), value);
            }
        }

        internal IDictionary<string, object> ConvertToDic()
        {
            return _hasSetOptionsProperties;
        }
    }
}