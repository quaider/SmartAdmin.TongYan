using System;
using System.Collections.Generic;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.DataGrid.Options
{
    /// <summary>
    /// 列定义
    /// </summary>
    internal class GridColumnsOptions : IOptionKey
    {
        private readonly IDictionary<string, object> _hasSetOptionsProperties;

        internal GridColumnsOptions()
        {
            _hasSetOptionsProperties = new Dictionary<string, object>();
            Searchable = false;
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
                _hasSetOptionsProperties.SetKeyValue(nameof(Width).ToCamelCaseString(), value);
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
                _hasSetOptionsProperties.SetKeyValue(nameof(Visible).ToCamelCaseString(), value);
            }
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(Type).ToCamelCaseString(), value);
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(Title).ToCamelCaseString(), value);
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
                _hasSetOptionsProperties.SetKeyValue(nameof(Searchable).ToCamelCaseString(), value);
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
                _hasSetOptionsProperties.SetKeyValue(nameof(Render).ToCamelCaseString(), value);
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
                _hasSetOptionsProperties.SetKeyValue(nameof(OrderSequence).ToCamelCaseString(), value);
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
                _hasSetOptionsProperties.SetKeyValue(nameof(Orderable).ToCamelCaseString(), value);
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
                _hasSetOptionsProperties.SetKeyValue(nameof(Name).ToCamelCaseString(), value);
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
                _hasSetOptionsProperties.SetKeyValue(nameof(DefaultContent).ToCamelCaseString(), value);
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
                _hasSetOptionsProperties.SetKeyValue(nameof(Data).ToCamelCaseString(), value);
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
                _hasSetOptionsProperties.SetKeyValue(nameof(CreatedCell).ToCamelCaseString(), value);
            }
        }

        private string _className;
        /// <summary>
        /// Class to assign to each cell in the column.
        /// </summary>
        public string ClassName
        {
            get { return _className; }
            set
            {
                _className = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(ClassName).ToCamelCaseString(), value);
            }
        }

        private string _align;
        /// <summary>
        /// center left right
        /// </summary>
        public string Align
        {
            get { return _align; }
            set
            {
                _align = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(Align).ToCamelCaseString(), value);
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
                _hasSetOptionsProperties.SetKeyValue(nameof(CellType).ToCamelCaseString(), value);
            }
        }


        public string OptionKey
        {
            get { return "data-grid-columns"; }
        }

        IDictionary<string, object> IOptionKey.ConvertToDic()
        {
            return _hasSetOptionsProperties;
        }
    }
}