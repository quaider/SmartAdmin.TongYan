using System.Collections.Generic;
using System.Web;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.Select.Options
{
    public class SelectOptions : IOptionKey
    {
        private readonly IDictionary<string, object> _hasSetOptionsProperties;

        internal SelectOptions()
        {
            _hasSetOptionsProperties = new Dictionary<string, object>();
            _ajax = new SelectWithAjax();
        }

        #region Select2 配置 http://select2.github.io/select2/#documentation

        private string _width;

        public string Width
        {
            get { return _width; }
            set
            {
                _width = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Width).ToCamelCaseString(), value);
            }
        }

        private int _minimumInputLength;

        public int MinimumInputLength
        {
            get { return _minimumInputLength; }
            set
            {
                _minimumInputLength = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.MinimumInputLength).ToCamelCaseString(), value);
            }
        }

        private int _maximumInputLength;

        public int MaximumInputLength
        {
            get { return _maximumInputLength; }
            set
            {
                _maximumInputLength = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.MaximumInputLength).ToCamelCaseString(), value);
            }
        }

        private int _minimumResultsForSearch;

        public int MinimumResultsForSearch
        {
            get { return _minimumResultsForSearch; }
            set
            {
                _minimumResultsForSearch = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.MinimumResultsForSearch).ToCamelCaseString(), value);
            }
        }

        private object _maximumSelectionSize;

        /// <summary>
        /// string or int
        /// </summary>
        public object MaximumSelectionSize
        {
            get { return _maximumSelectionSize; }
            set
            {
                _maximumSelectionSize = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.MaximumSelectionSize).ToCamelCaseString(), value);
            }
        }

        private object _placeholder;

        public object Placeholder
        {
            get { return _placeholder; }
            set
            {
                _placeholder = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Placeholder).ToCamelCaseString(), value);
            }
        }

        private object _placeholderOption;

        public object PlaceholderOption
        {
            get { return _placeholderOption; }
            set
            {
                _placeholderOption = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.PlaceholderOption).ToCamelCaseString(), value);
            }
        }

        private string _separator;

        public string Separator
        {
            get { return _separator; }
            set
            {
                _separator = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Separator).ToCamelCaseString(), value);
            }
        }

        private bool _allowClear;

        public bool AllowClear
        {
            get { return _allowClear; }
            set
            {
                _allowClear = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.AllowClear).ToCamelCaseString(), value);
            }
        }

        private bool _multiple;

        public bool Multiple
        {
            get { return _multiple; }
            set
            {
                _multiple = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Multiple).ToCamelCaseString(), value);
            }
        }

        private bool _closeOnSelect;

        public bool CloseOnSelect
        {
            get { return _closeOnSelect; }
            set
            {
                _closeOnSelect = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.CloseOnSelect).ToCamelCaseString(), value);
            }
        }

        private bool _openOnEnter;

        public bool OpenOnEnter
        {
            get { return _openOnEnter; }
            set
            {
                _openOnEnter = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.OpenOnEnter).ToCamelCaseString(), value);
            }
        }

        private string _id;

        /// <summary>
        /// js function
        /// </summary>
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value.StartsWith("fn:") ? value : ("fn:" + value);
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Id).ToCamelCaseString(), value);
            }
        }

        private string _matcher;

        /// <summary>
        /// js function
        /// </summary>
        public string Matcher
        {
            get { return _matcher; }
            set
            {
                _matcher = value.StartsWith("fn:") ? value : ("fn:" + value);
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Matcher).ToCamelCaseString(), value);
            }
        }

        private string _sortResults;

        /// <summary>
        /// js function
        /// </summary>
        public string SortResults
        {
            get { return _sortResults; }
            set
            {
                _sortResults = value.StartsWith("fn:") ? value : ("fn:" + value);
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.SortResults).ToCamelCaseString(), value);
            }
        }

        private string _formatSelection;

        /// <summary>
        /// js function
        /// </summary>
        public string FormatSelection
        {
            get { return _formatSelection; }
            set
            {
                _formatSelection = value.StartsWith("fn:") ? value : ("fn:" + value);
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.FormatSelection).ToCamelCaseString(), value);
            }
        }

        private string _formatResult;

        /// <summary>
        /// js function
        /// </summary>
        public string FormatResult
        {
            get { return _formatResult; }
            set
            {
                _formatResult = value.StartsWith("fn:") ? value : ("fn:" + value);
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.FormatResult).ToCamelCaseString(), value);
            }
        }

        private string _formatResultCssClass;

        /// <summary>
        /// js function
        /// </summary>
        public string FormatResultCssClass
        {
            get { return _formatResultCssClass; }
            set
            {
                _formatResultCssClass = value.StartsWith("fn:") ? value : ("fn:" + value);
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.FormatResultCssClass).ToCamelCaseString(), value);
            }
        }

        private string _formatNoMatches;

        /// <summary>
        /// string or function(如果是函数请以fn:开头作为识别标识)
        /// </summary>
        public string FormatNoMatches
        {
            get { return _formatNoMatches; }
            set
            {
                _formatNoMatches = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.FormatNoMatches).ToCamelCaseString(), value);
            }
        }

        private string _formatSearching;

        /// <summary>
        /// string or function(如果是函数请以fn:开头作为识别标识)
        /// </summary>
        public string FormatSearching
        {
            get { return _formatSearching; }
            set
            {
                _formatSearching = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.FormatSearching).ToCamelCaseString(), value);
            }
        }

        private string _formatAjaxError;

        /// <summary>
        /// string or function(如果是函数请以fn:开头作为识别标识)
        /// </summary>
        public string FormatAjaxError
        {
            get { return _formatAjaxError; }
            set
            {
                _formatAjaxError = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.FormatAjaxError).ToCamelCaseString(), value);
            }
        }

        private string _formatInputTooShort;

        /// <summary>
        /// string or function(如果是函数请以fn:开头作为识别标识)
        /// </summary>
        public string FormatInputTooShort
        {
            get { return _formatInputTooShort; }
            set
            {
                _formatInputTooShort = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.FormatInputTooShort).ToCamelCaseString(), value);
            }
        }

        private string _formatInputTooLong;

        /// <summary>
        /// string or function(如果是函数请以fn:开头作为识别标识)
        /// </summary>
        public string FormatInputTooLong
        {
            get { return _formatInputTooLong; }
            set
            {
                _formatInputTooLong = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.FormatInputTooLong).ToCamelCaseString(), value);
            }
        }

        private string _formatSelectionTooBig;

        /// <summary>
        /// string or function(如果是函数请以fn:开头作为识别标识)
        /// </summary>
        public string FormatSelectionTooBig
        {
            get { return _formatSelectionTooBig; }
            set
            {
                _formatSelectionTooBig = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.FormatSelectionTooBig).ToCamelCaseString(), value);
            }
        }

        private string _formatLoadMore;

        /// <summary>
        /// string or function(如果是函数请以fn:开头作为识别标识)
        /// </summary>
        public string FormatLoadMore
        {
            get { return _formatLoadMore; }
            set
            {
                _formatLoadMore = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.FormatLoadMore).ToCamelCaseString(), value);
            }
        }

        private string _createSearchChoice;

        /// <summary>
        /// function
        /// </summary>
        public string CreateSearchChoice
        {
            get { return _createSearchChoice; }
            set
            {
                _createSearchChoice = value.StartsWith("fn:") ? value : ("fn:" + value);
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.CreateSearchChoice).ToCamelCaseString(), value);
            }
        }

        private string _createSearchChoicePosition;

        /// <summary>
        /// string or function(function请以fn:开头作为识别标识)
        /// </summary>
        public string CreateSearchChoicePosition
        {
            get { return _createSearchChoicePosition; }
            set
            {
                _createSearchChoicePosition = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.CreateSearchChoicePosition).ToCamelCaseString(), value);
            }
        }

        private string _initSelection;

        /// <summary>
        /// function
        /// </summary>
        public string InitSelection
        {
            get { return _initSelection; }
            set
            {
                _initSelection = value.StartsWith("fn:") ? value : ("fn:" + value);
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.InitSelection).ToCamelCaseString(), value);
            }
        }

        private string _tokenizer;

        /// <summary>
        /// function
        /// </summary>
        public string Tokenizer
        {
            get { return _tokenizer; }
            set
            {
                _tokenizer = value.StartsWith("fn:") ? value : ("fn:" + value);
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Tokenizer).ToCamelCaseString(), value);
            }
        }

        private string _tokenSeparators;

        /// <summary>
        /// An array of strings 如[',', ' ']
        /// </summary>
        public string TokenSeparators
        {
            get { return _tokenSeparators; }
            set
            {
                _tokenSeparators = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.TokenSeparators).ToCamelCaseString(), value);
            }
        }

        private string _query;

        /// <summary>
        /// function
        /// </summary>
        public string Query
        {
            get { return _query; }
            set
            {
                _query = value.StartsWith("fn:") ? value : ("fn:" + value);
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Query).ToCamelCaseString(), value);
            }
        }

        private SelectWithAjax _ajax;

        public SelectWithAjax Ajax
        {
            get { return _ajax; }
        }

        private string _tags;

        /// <summary>
        /// boolean, array or function
        /// array: jo:[{id:1, text:'test'},{id:2, text:'test2'}]
        /// fn: fr:getTags  返回array的函数
        /// </summary>
        public string Tags
        {
            get { return _tags; }
            set
            {
                _tags = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Tags).ToCamelCaseString(), value);
            }
        }

        private string _containerCss;

        public string ContainerCss
        {
            get { return _containerCss; }
            set
            {
                _containerCss = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.ContainerCss).ToCamelCaseString(), value);
            }
        }

        private string _containerCssClass;

        /// <summary>
        /// string or function(function请以fn:开头作为识别标识)
        /// </summary>
        public string ContainerCssClass
        {
            get { return _containerCssClass; }
            set
            {
                _containerCssClass = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.ContainerCssClass).ToCamelCaseString(), value);
            }
        }

        private string _dropdownCss;

        public string DropdownCss
        {
            get { return _dropdownCss; }
            set
            {
                _dropdownCss = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.DropdownCss).ToCamelCaseString(), value);
            }
        }

        private string _dropdownCssClass;

        /// <summary>
        /// string or function(function请以fn:开头作为识别标识)
        /// </summary>
        public string DropdownCssClass
        {
            get { return _dropdownCssClass; }
            set
            {
                _dropdownCssClass = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.DropdownCssClass).ToCamelCaseString(), value);
            }
        }

        private bool _dropdownAutoWidth;

        public bool DropdownAutoWidth
        {
            get { return _dropdownAutoWidth; }
            set
            {
                _dropdownAutoWidth = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.DropdownAutoWidth).ToCamelCaseString(), value);
            }
        }

        private string _adaptContainerCssClass;

        /// <summary>
        /// function
        /// </summary>
        public string AdaptContainerCssClass
        {
            get { return _adaptContainerCssClass; }
            set
            {
                _adaptContainerCssClass = value.StartsWith("fn:") ? value : ("fn:" + value);
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.AdaptContainerCssClass).ToCamelCaseString(), value);
            }
        }

        private string _adaptDropdownCssClass;

        /// <summary>
        /// function
        /// </summary>
        public string AdaptDropdownCssClass
        {
            get { return _adaptDropdownCssClass; }
            set
            {
                _adaptDropdownCssClass = value.StartsWith("fn:") ? value : ("fn:" + value);
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.AdaptDropdownCssClass).ToCamelCaseString(), value);
            }
        }

        private string _escapeMarkup;

        /// <summary>
        /// function
        /// </summary>
        public string EscapeMarkup
        {
            get { return _escapeMarkup; }
            set
            {
                _escapeMarkup = value.StartsWith("fn:") ? value : ("fn:" + value);
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.EscapeMarkup).ToCamelCaseString(), value);
            }
        }

        private bool _selectOnBlur;

        /// <summary>
        /// function
        /// </summary>
        public bool SelectOnBlur
        {
            get { return _selectOnBlur; }
            set
            {
                _selectOnBlur = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.SelectOnBlur).ToCamelCaseString(), value);
            }
        }

        private int _loadMorePadding;

        public int LoadMorePadding
        {
            get { return _loadMorePadding; }
            set
            {
                _loadMorePadding = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.LoadMorePadding).ToCamelCaseString(), value);
            }
        }

        private string _nextSearchTerm;

        /// <summary>
        /// function
        /// </summary>
        public string NextSearchTerm
        {
            get { return _nextSearchTerm; }
            set
            {
                _nextSearchTerm = value.StartsWith("fn:") ? value : ("fn:" + value);
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.NextSearchTerm).ToCamelCaseString(), value);
            }
        }

        #endregion

        public SelectModel[] Data { get; private set; }
        /// <summary>
        /// 设置下拉数据源(数据来源于后端定义)
        /// </summary>
        /// <param name="selectItems">数据项数组</param>
        public void SetData(SelectModel[] selectItems)
        {
            Data = selectItems;
        }

        public void SetDataFromJsObj(string jsObj)
        {
            jsObj = jsObj.StartsWith("jo:") ? jsObj : ("jo:" + jsObj);
            _hasSetOptionsProperties.SetKeyValue("data", jsObj);
        }

        public string OptionKey
        {
            get { return "data-options"; }
        }

        public IDictionary<string, object> ConvertToDic()
        {
            return _hasSetOptionsProperties;
        }
    }

    public class SelectWithAjax
    {
        private readonly IDictionary<string, object> _hasSetOptionsProperties;

        public SelectWithAjax()
        {
            _hasSetOptionsProperties = new Dictionary<string, object>();
        }

        private string _transportp;

        /// <summary>
        /// function
        /// </summary>
        public string Transportp
        {
            get { return _transportp; }
            set
            {
                _transportp = value.StartsWith("fn:") ? value : ("fn:" + value);
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Transportp).ToCamelCaseString(), value);
            }
        }

        private string _url;

        /// <summary>
        /// string or function
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

        private string _dataType;

        public string DataType
        {
            get { return _dataType; }
            set
            {
                _dataType = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.DataType).ToCamelCaseString(), value);
            }
        }

        private int _quietMillis;

        public int QuietMillis
        {
            get { return _quietMillis; }
            set
            {
                _quietMillis = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.QuietMillis).ToCamelCaseString(), value);
            }
        }

        private bool _cache;

        public bool Cache
        {
            get { return _cache; }
            set
            {
                _cache = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Cache).ToCamelCaseString(), value);
            }
        }

        private string _jsonpCallback;

        /// <summary>
        /// string or function
        /// </summary>
        public string JsonpCallback
        {
            get { return _jsonpCallback; }
            set
            {
                _jsonpCallback = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.JsonpCallback).ToCamelCaseString(), value);
            }
        }

        private string _data;

        /// <summary>
        /// function to generate query parameters for the ajax request.
        /// </summary>
        public string Data
        {
            get { return _data; }
            set
            {
                _data = value.StartsWith("fn:") ? value : ("fn:" + value);
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Data).ToCamelCaseString(), value);
            }
        }

        private string _result;

        /// <summary>
        /// function
        /// </summary>
        public string Result
        {
            get { return _result; }
            set
            {
                _result = value.StartsWith("fn:") ? value : ("fn:" + value);
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Result).ToCamelCaseString(), value);
            }
        }

        private string _params;

        /// <summary>
        /// object or function
        /// </summary>
        public string Params
        {
            get { return _params; }
            set
            {
                _params = value.StartsWith("fn:") ? value : ("fn:" + value);
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Params).ToCamelCaseString(), value);
            }
        }

        public IDictionary<string, object> ConvertToDic()
        {
            return _hasSetOptionsProperties;
        }
    }
}