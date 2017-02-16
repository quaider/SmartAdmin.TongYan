using System;
using System.Collections.Generic;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.Select.Options
{
    /// <summary>
    /// 下拉联动，暂只支持ajax和js单独设置
    /// </summary>
    public class SelectLinkageOptions : IOptionKey
    {
        private readonly IDictionary<string, object> _hasSetOptionsProperties;

        internal SelectLinkageOptions()
        {
            _hasSetOptionsProperties = new Dictionary<string, object>();
        }

        public string OptionKey
        {
            get { return "data-select-linkage"; }
        }

        IDictionary<string, object> IOptionKey.ConvertToDic()
        {
            return _hasSetOptionsProperties;
        }

        public string Parent { get; set; }

        private string _url;

        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Url).ToCamelCaseString(), value);
            }
        }

        /// <summary>
        /// 通过js函数设置select的下拉选项
        /// </summary>
        /// <param name="functionName">js函数名称</param>
        public void SetDataViaJs(string functionName)
        {
            _hasSetOptionsProperties.SetKeyValue("dataSource", functionName);
        }
    }
}