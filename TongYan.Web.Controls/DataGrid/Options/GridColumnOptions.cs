using System;
using System.Collections.Generic;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.DataGrid.Options
{
    /// <summary>
    /// 列定义
    /// </summary>
    public class GridColumnOptions
    {
        private readonly IDictionary<string, object> _hasSetOptionsProperties;

        internal GridColumnOptions()
        {
            _hasSetOptionsProperties = new Dictionary<string, object>();
        }

        private string _width;
        /// <summary>
        /// 列宽
        /// </summary>
        public string Width
        {
            get { return _width; }
            set
            {
                _width = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Width).ToCamelCaseString(), value);
            }
        }

        private bool _visible;
        /// <summary>
        /// 列可见性
        /// </summary>
        public bool Visible
        {
            get { return _visible; }
            set
            {
                _visible = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Visible).ToCamelCaseString(), value);
            }
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Type).ToCamelCaseString(), value);
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                //_hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Title).ToCamelCaseString(), value);
            }
        }

        private bool _searchable;
        /// <summary>
        /// 是否可搜索
        /// </summary>
        public bool Searchable
        {
            get { return _searchable; }
            set
            {
                _searchable = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Searchable).ToCamelCaseString(), value);
            }
        }

        private string _render;
        /// <summary>
        /// 列呈现器(格式化较常用)
        /// </summary>
        public string Render
        {
            get { return _render; }
            set
            {
                _render = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Render).ToCamelCaseString(), value);
            }
        }

        private string _orderSequence;
        /// <summary>
        /// js array
        /// https://datatables.net/reference/option/columns.orderSequence
        /// </summary>
        public string OrderSequence
        {
            get { return _orderSequence; }
            set
            {
                _orderSequence = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.OrderSequence).ToCamelCaseString(), value);
            }
        }

        private bool _orderable;
        /// <summary>
        /// 可否排序
        /// </summary>
        public bool Orderable
        {
            get { return _orderable; }
            set
            {
                _orderable = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Orderable).ToCamelCaseString(), value);
            }
        }

        private string _name;
        /// <summary>
        /// 列名称标识
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Name).ToCamelCaseString(), value);
            }
        }

        private string _defaultContent;
        /// <summary>
        /// 列的默认内容
        /// https://datatables.net/reference/option/columns.defaultContent
        /// </summary>
        public string DefaultContent
        {
            get { return _defaultContent; }
            set
            {
                _defaultContent = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.DefaultContent).ToCamelCaseString(), value);
            }
        }

        private string _data;
        /// <summary>
        /// 列数据源，一般就用简单的字符串就好了；其他的取值较复杂，请参考以下链接，
        /// https://datatables.net/reference/option/columns.data
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

        private string _createdCell;
        /// <summary>
        /// Cell created callback to allow DOM manipulation.
        /// </summary>
        public string CreatedCell
        {
            get { return _createdCell; }
            set
            {
                _createdCell = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.CreatedCell).ToCamelCaseString(), value);
            }
        }

        private string _cellType;
        /// <summary>
        /// 列类型(默认td)
        /// </summary>
        protected string CellType
        {
            get { return _cellType; }
            set
            {
                _cellType = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.CellType).ToCamelCaseString(), value);
            }
        }

        private string _className;

        /// <summary>
        /// 样式名
        /// </summary>
        public string ClassName
        {
            get { return _className; }
            set
            {
                _className = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.ClassName).ToCamelCaseString(), value);
            }
        }

        internal IDictionary<string, object> ConvertToDic()
        {
            return _hasSetOptionsProperties;
        }

    }
}