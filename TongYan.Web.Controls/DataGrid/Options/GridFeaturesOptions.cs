using System;
using System.Collections.Generic;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.DataGrid.Options
{
    /// <summary>
    /// DataTables Features
    /// </summary>
    public class GridFeaturesOptions : IOptionKey
    {
        private readonly IDictionary<string, object> _hasSetOptionsProperties;

        internal GridFeaturesOptions()
        {
            _hasSetOptionsProperties = new Dictionary<string, object>();
            Processing = true;
            ServerSide = true;
        }

        private bool _autoWidth;
        /// <summary>
        /// 启用或禁用 列宽自动计算
        /// Enable or disable automatic column width calculation
        /// </summary>
        public bool AutoWidth
        {
            get { return _autoWidth; }
            set
            {
                _autoWidth = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.AutoWidth).ToCamelCaseString(), value);
            }
        }

        private bool _deferRender;
        /// <summary>
        /// 是否启用 管道加载
        /// 一般不会用到，原文档 https://datatables.net/reference/option/deferRender
        /// </summary>
        public bool DeferRender
        {
            get { return _deferRender; }
            set
            {
                _deferRender = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.DeferRender).ToCamelCaseString(), value);
            }
        }

        private bool _info;
        /// <summary>
        /// 是否启用 信息显示(是分页等信息么?)
        /// https://datatables.net/reference/option/info
        /// </summary>
        public bool Info
        {
            get { return _info; }
            set
            {
                _info = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Info).ToCamelCaseString(), value);
            }
        }

        private bool _lengthChange;
        /// <summary>
        /// 启用或禁用 分页长度变更
        /// Enable or disable user ability to change number of records per page:
        /// </summary>
        public bool LengthChange
        {
            get { return _lengthChange; }
            set
            {
                _lengthChange = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.LengthChange).ToCamelCaseString(), value);
            }
        }

        private bool _ordering;
        /// <summary>
        /// 启用会禁用表格排序
        /// </summary>
        public bool Ordering
        {
            get { return _ordering; }
            set
            {
                _ordering = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Ordering).ToCamelCaseString(), value);
            }
        }

        private bool _paging;
        /// <summary>
        /// 启用会禁用表格分页
        /// </summary>
        public bool Paging
        {
            get { return _paging; }
            set
            {
                _paging = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Paging).ToCamelCaseString(), value);
            }
        }

        private bool _processing;
        /// <summary>
        /// 启用加载过渡(loading or 处理中...)
        /// </summary>
        public bool Processing
        {
            get { return _processing; }
            set
            {
                _processing = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Processing).ToCamelCaseString(), value);
            }
        }

        private bool _scrollX;
        /// <summary>
        /// 启用或禁用横向滚动
        /// </summary>
        public bool ScrollX
        {
            get { return _scrollX; }
            set
            {
                _scrollX = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.ScrollX).ToCamelCaseString(), value);
            }
        }

        private string _scrollY;
        /// <summary>
        /// 启用或禁用垂直滚动(高度字符，CSS unit, or a number，如200px,超出改长度即滚动)
        /// https://datatables.net/reference/option/scrollY
        /// </summary>
        public string ScrollY
        {
            get { return _scrollY; }
            set
            {
                _scrollY = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.ScrollY).ToCamelCaseString(), value);
            }
        }

        private bool _searching;
        /// <summary>
        /// 启用或禁用搜索功能
        /// </summary>
        public bool Searching
        {
            get { return _searching; }
            set
            {
                _searching = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Searching).ToCamelCaseString(), value);
            }
        }

        private bool _serverSide;
        /// <summary>
        /// 启用或禁用服务端数据处理
        /// https://datatables.net/reference/option/serverSide
        /// </summary>
        public bool ServerSide
        {
            get { return _serverSide; }
            set
            {
                _serverSide = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.ServerSide).ToCamelCaseString(), value);
            }
        }

        /// <summary>
        /// 启用表格首列勾选(采用方法而非属性是为了减少配置的复杂度)
        /// </summary>
        /// <param name="theme">复选框主题(className)</param>
        public void EnableCheck(string theme = "")
        {
            if (!string.IsNullOrWhiteSpace(theme))
            {
                theme = theme.Replace("'", "").Replace("\"", "");
                _hasSetOptionsProperties.SetKeyValue("check", "jo:{className:'" + theme + "'}");
            }
            else
            {
                _hasSetOptionsProperties.SetKeyValue("check", true);
            }
        }


        public string OptionKey
        {
            get { return "data-grid-features"; }
        }

        IDictionary<string, object> IOptionKey.ConvertToDic()
        {
            return _hasSetOptionsProperties;
        }
    }
}