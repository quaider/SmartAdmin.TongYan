using System;
using System.Collections.Generic;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.Tree.Options
{
    /// <summary>
    /// todo: 最佳实践应该是属性的aop
    /// </summary>
    public class TreeAsyncOptions : IOptionKey
    {
        private readonly IDictionary<string, object> _hasSetOptionsProperties;

        internal TreeAsyncOptions()
        {
            //设置默认值
            AutoParam = new[] { "id" };
            _hasSetOptionsProperties = new Dictionary<string, object>
            {
                {"enable", true }
            };
        }

        public string OptionKey
        {
            get { return "data-tree-async"; }
        }

        #region 对应zTree的async配置

        private string[] _autoParam;
        public string[] AutoParam
        {
            get { return _autoParam; }
            set
            {
                _autoParam = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.AutoParam).ToCamelCaseString(), _autoParam);
            }
        }

        private string _contentType;
        public string ContentType
        {
            get { return _contentType; }
            set
            {
                _contentType = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.ContentType).ToCamelCaseString(), _contentType);
            }
        }

        private string _dataFilter;
        public string DataFilter
        {
            get { return _dataFilter; }
            set
            {
                _dataFilter = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.DataFilter).ToCamelCaseString(), _dataFilter);
            }
        }

        private string _dataType;
        public string DataType
        {
            get { return _dataType; }
            set
            {
                _dataType = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.DataType).ToCamelCaseString(), _dataType);
            }
        }

        private string _otherParam;
        public string OtherParam
        {
            get { return _otherParam; }
            set
            {
                _otherParam = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.OtherParam).ToCamelCaseString(), _otherParam);
            }
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Type).ToCamelCaseString(), _type);
            }
        }

        private string _url;
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Url).ToCamelCaseString(), _url);
            }
        }

        #endregion

        IDictionary<string, object> IOptionKey.ConvertToDic()
        {
            return _hasSetOptionsProperties;
        }
    }
}