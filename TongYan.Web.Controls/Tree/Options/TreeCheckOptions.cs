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
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.AutoCheckTrigger).ToCamelCaseString(), value);
            }
        }

        private string _chkboxType;
        public string ChkboxType
        {
            get { return _chkboxType; }
            set
            {
                _chkboxType = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.ChkboxType).ToCamelCaseString(), value);
            }
        }

        private string _chkStyle;
        public string ChkStyle
        {
            get { return _chkStyle; }
            set
            {
                _chkStyle = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.ChkStyle).ToCamelCaseString(), value);
            }
        }

        private bool _nocheckInherit;
        public bool NocheckInherit
        {
            get { return _nocheckInherit; }
            set
            {
                _nocheckInherit = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.NocheckInherit).ToCamelCaseString(), value);
            }
        }

        private bool _chkDisabledInherit;
        public bool ChkDisabledInherit
        {
            get { return _chkDisabledInherit; }
            set
            {
                _chkDisabledInherit = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.ChkDisabledInherit).ToCamelCaseString(), value);
            }
        }

        private string _radioType;
        public string RadioType
        {
            get { return _radioType; }
            set
            {
                _radioType = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.RadioType).ToCamelCaseString(), value);
            }
        }

        #endregion

        IDictionary<string, object> IOptionKey.ConvertToDic()
        {
            return _hasSetOptionsProperties;
        }
    }
}