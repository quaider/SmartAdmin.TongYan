using System;
using System.Collections.Generic;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.Tree.Options
{
    public class TreeCheckOptions : IOptionKey
    {
        private readonly IDictionary<string, object> _hasSetOptionsProperties;
        internal TreeCheckOptions()
        {
            _hasSetOptionsProperties = new Dictionary<string, object>
            {
                {"enable", true }
            };
        }

        public string OptionKey
        {
            get { return "data-tree-check"; }
        }

        #region 对应zTree的check配置

        private bool _autoCheckTrigger;
        public bool AutoCheckTrigger
        {
            get { return _autoCheckTrigger; }
            set
            {
                _autoCheckTrigger = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(AutoCheckTrigger).ToCamelCaseString(), value);
            }
        }

        private string _chkboxType;
        public string ChkboxType
        {
            get { return _chkboxType; }
            set
            {
                _chkboxType = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(ChkboxType).ToCamelCaseString(), value);
            }
        }

        private string _chkStyle;
        public string ChkStyle
        {
            get { return _chkStyle; }
            set
            {
                _chkStyle = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(ChkStyle).ToCamelCaseString(), value);
            }
        }

        private bool _nocheckInherit;
        public bool NocheckInherit
        {
            get { return _nocheckInherit; }
            set
            {
                _nocheckInherit = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(NocheckInherit).ToCamelCaseString(), value);
            }
        }

        private bool _chkDisabledInherit;
        public bool ChkDisabledInherit
        {
            get { return _chkDisabledInherit; }
            set
            {
                _chkDisabledInherit = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(ChkDisabledInherit).ToCamelCaseString(), value);
            }
        }

        private string _radioType;
        public string RadioType
        {
            get { return _radioType; }
            set
            {
                _radioType = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(RadioType).ToCamelCaseString(), value);
            }
        }

        #endregion

        IDictionary<string, object> IOptionKey.ConvertToDic()
        {
            return _hasSetOptionsProperties;
        }
    }
}