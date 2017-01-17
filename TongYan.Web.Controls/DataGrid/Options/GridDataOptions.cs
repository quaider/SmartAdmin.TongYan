﻿using System;
using System.Collections.Generic;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.DataGrid.Options
{
    /// <summary>
    /// DataTables Data
    /// </summary>
    public class GridDataOptions : IOptionKey
    {
        private readonly IDictionary<string, object> _hasSetOptionsProperties;

        internal GridDataOptions()
        {
            _hasSetOptionsProperties = new Dictionary<string, object>();
            _ajax = new GridDataAjaxOptions();
        }

        private IEnumerable<object> _data;
        /// <summary>
        /// grid显示的数据(2D数据不列入支持计划)
        /// if data is specified, the data given in the array will replace any information that was found in the table's DOM when initialised.
        /// </summary>
        public IEnumerable<object> Data
        {
            get { return _data; }
            set
            {
                _data = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Data).ToCamelCaseString(), value);
            }
        }

        private GridDataAjaxOptions _ajax;
        /// <summary>
        /// 三种模式
        /// 1、一个url链接字符串
        /// 2、和$.ajax一样的参数对象
        /// 3、function:Custom data get function, 一些用法请参考以下文档
        /// https://datatables.net/reference/option/ajax
        /// </summary>
        public GridDataAjaxOptions Ajax
        {
            get { return _ajax; }
        }

        public string OptionKey
        {
            get { return "data-grid-data"; }
        }

        IDictionary<string, object> IOptionKey.ConvertToDic()
        {
            _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Ajax).ToCamelCaseString(), Ajax.ConvertToDic());
            return _hasSetOptionsProperties;
        }
    }

    /// <summary>
    /// GridDataOptions for ajax options
    /// </summary>
    public class GridDataAjaxOptions
    {
        private IDictionary<string, object> _hasSetOptionsProperties;

        internal GridDataAjaxOptions()
        {
            _hasSetOptionsProperties = new Dictionary<string, object>();
        }

        private string _url;
        /// <summary>
        /// 提供数据的Url地址
        /// </summary>
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Url).ToCamelCaseString(), value);
            }
        }

        private string _ajaxFunction;
        /// <summary>
        /// 提供DataTable所需的数据，如果给其设定值，将忽略其他ajax设置(互斥)
        /// </summary>
        public string AjaxFunction
        {
            get { return _ajaxFunction; }
            set
            {
                _ajaxFunction = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.AjaxFunction).ToCamelCaseString(), value);
            }
        }

        private string _data;
        /// <summary>
        /// 发送到服务器的参数 data:{user_id:451} or data: function(d){ d.some_name = $('#element').val(); }
        /// or data: function(d) { return $.extend({}, d, {some_name: $('#element').val()}); }
        /// </summary>
        public string Data
        {
            get { return _data; }
            set
            {
                _data = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Data).ToCamelCaseString(), value);
            }
        }

        private string _dataSrc;
        /// <summary>
        /// 主体数据的根定义(默认是data)
        /// </summary>
        public string DataSrc
        {
            get { return _dataSrc; }
            set
            {
                _dataSrc = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.DataSrc).ToCamelCaseString(), value);
            }
        }

        internal IDictionary<string, object> ConvertToDic()
        {
            return _hasSetOptionsProperties;
        }
    }
}