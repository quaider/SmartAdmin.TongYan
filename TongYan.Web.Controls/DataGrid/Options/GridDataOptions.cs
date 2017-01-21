using System;
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
        [Obsolete("注意：为了与其他特性配合，减少查询等的代码量，我们使用自定义的完全控制ajax request的方式初始化，而不是DataTable的原生方式！", true)]
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
            Type = "post";
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

        private string _type;
        /// <summary>
        /// 请求方式默认就是post
        /// </summary>
        protected string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Type).ToCamelCaseString(), value);
            }
        }

        private string _ajaxFunction;
        /// <summary>
        /// 提供DataTable所需的数据，如果给其设定值，将忽略其他ajax设置(互斥)
        /// </summary>
        [Obsolete("注意：为了与其他特性配合，减少查询等的代码量，我们使用自定义的完全控制ajax request的方式初始化，而不是DataTable的原生方式！", true)]
        protected string AjaxFunction
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
        [Obsolete("注意：为了与其他特性配合，减少查询等的代码量，我们使用自定义的完全控制ajax request的方式初始化，而不是DataTable的原生方式！", true)]
        protected string Data
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
        [Obsolete("注意：为了与其他特性配合，减少查询等的代码量，我们使用自定义的完全控制ajax request的方式初始化，而不是DataTable的原生方式！", true)]
        protected string DataSrc
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