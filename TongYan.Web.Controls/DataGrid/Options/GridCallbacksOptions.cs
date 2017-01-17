using System;
using System.Collections.Generic;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.DataGrid.Options
{
    /// <summary>
    /// DataTable Callbacks
    /// </summary>
    public class GridCallbacksOptions : IOptionKey
    {
        private readonly IDictionary<string, object> _hasSetOptionsProperties;

        internal GridCallbacksOptions()
        {
            _hasSetOptionsProperties = new Dictionary<string, object>();
        }

        private string _createdRow;
        /// <summary>
        /// 行创建回调(可以自定义行样式、行事件等) function(row, data, dataIndex)
        /// https://datatables.net/reference/option/createdRow
        /// </summary>
        public string CreatedRow
        {
            get { return _createdRow; }
            set
            {
                _createdRow = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.CreatedRow).ToCamelCaseString(), value);
            }
        }

        private string _preDrawCallback;
        /// <summary>
        /// DataTable开始绘制前的回调
        /// </summary>
        public string PreDrawCallback
        {
            get { return _preDrawCallback; }
            set
            {
                _preDrawCallback = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.PreDrawCallback).ToCamelCaseString(), value);
            }
        }

        private string _drawCallback;
        /// <summary>
        /// DataTable绘制回调(如给新创建的元素添加事件、新数据的额外控制)
        /// https://datatables.net/reference/option/drawCallback
        /// </summary>
        public string DrawCallback
        {
            get { return _drawCallback; }
            set
            {
                _drawCallback = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.DrawCallback).ToCamelCaseString(), value);
            }
        }

        private string _footerCallback;
        /// <summary>
        /// Table Foot创建事件
        /// </summary>
        public string FooterCallback
        {
            get { return _footerCallback; }
            set
            {
                _footerCallback = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.FooterCallback).ToCamelCaseString(), value);
            }
        }

        private string _formatNumber;
        /// <summary>
        /// Number formatting callback function.
        /// https://datatables.net/reference/option/formatNumber
        /// </summary>
        public string FormatNumber
        {
            get { return _formatNumber; }
            set
            {
                _formatNumber = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.FormatNumber).ToCamelCaseString(), value);
            }
        }

        private string _headerCallback;
        /// <summary>
        /// This function is called on every 'draw' event 
        /// when a filter, sort or page event is initiated by the end user or the API
        /// https://datatables.net/reference/option/headerCallback
        /// </summary>
        public string HeaderCallback
        {
            get { return _headerCallback; }
            set
            {
                _headerCallback = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.HeaderCallback).ToCamelCaseString(), value);
            }
        }

        private string _infoCallback;
        /// <summary>
        /// Table summary information display callback.
        /// https://datatables.net/reference/option/infoCallback
        /// </summary>
        public string InfoCallback
        {
            get { return _infoCallback; }
            set
            {
                _infoCallback = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.InfoCallback).ToCamelCaseString(), value);
            }
        }

        private string _initComplete;
        /// <summary>
        /// 初始化完成回调, 包含ajax数据请求完成
        /// https://datatables.net/reference/option/initComplete
        /// </summary>
        public string InitComplete
        {
            get { return _initComplete; }
            set
            {
                _initComplete = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.InitComplete).ToCamelCaseString(), value);
            }
        }

        private string _rowCallback;
        /// <summary>
        /// Row draw callback(行绘制 但是没有添加到dom中)
        /// </summary>
        public string RowCallback
        {
            get { return _rowCallback; }
            set
            {
                _rowCallback = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.RowCallback).ToCamelCaseString(), value);
            }
        }

        private string _stateLoadCallback;
        /// <summary>
        /// Callback that defines where and how a saved state should be loaded.
        /// https://datatables.net/reference/option/stateLoadCallback
        /// </summary>
        public string StateLoadCallback
        {
            get { return _stateLoadCallback; }
            set
            {
                _stateLoadCallback = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.StateLoadCallback).ToCamelCaseString(), value);
            }
        }

        private string _stateLoaded;
        /// <summary>
        /// State loaded callback.
        /// https://datatables.net/reference/option/stateLoaded
        /// </summary>
        public string StateLoaded
        {
            get { return _stateLoaded; }
            set
            {
                _stateLoaded = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.StateLoaded).ToCamelCaseString(), value);
            }
        }

        private string _stateLoadParams;
        /// <summary>
        /// State loaded - data manipulation callback.
        /// this function is used to manipulate the data once it has been retrieved from storage
        /// https://datatables.net/reference/option/stateLoadParams
        /// </summary>
        public string StateLoadParams
        {
            get { return _stateLoadParams; }
            set
            {
                _stateLoadParams = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.StateLoadParams).ToCamelCaseString(), value);
            }
        }

        private string _stateSaveCallback;
        /// <summary>
        /// Callback that defines how and where the table state is stored.
        /// https://datatables.net/reference/option/stateSaveCallback
        /// </summary>
        public string StateSaveCallback
        {
            get { return _stateSaveCallback; }
            set
            {
                _stateSaveCallback = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.StateSaveCallback).ToCamelCaseString(), value);
            }
        }

        private string _stateSaveParams;
        /// <summary>
        /// State save - data manipulation callback.
        /// https://datatables.net/reference/option/stateSaveParams
        /// </summary>
        public string StateSaveParams
        {
            get { return _stateSaveParams; }
            set
            {
                _stateSaveParams = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.StateSaveParams).ToCamelCaseString(), value);
            }
        }

        public string OptionKey
        {
            get { return "data-grid-callbacks"; }
        }

        IDictionary<string, object> IOptionKey.ConvertToDic()
        {
            return _hasSetOptionsProperties;
        }
    }
}
