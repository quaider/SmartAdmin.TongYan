using System;
using System.Collections.Generic;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.Tree.Options
{
    public class TreeCheckOptions : IOptionKey
    {
        private readonly IDictionary<string, object> _hasSetOptionsProperties;
        public TreeCheckOptions()
        {
            _hasSetOptionsProperties = new Dictionary<string, object>
            {
                {"Enable", true }
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
                _hasSetOptionsProperties.SetKeyValue(nameof(AutoCheckTrigger), value);
            }
        }

        private string _chkboxType;
        public string ChkboxType
        {
            get { return _chkboxType; }
            set
            {
                _chkboxType = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(ChkboxType), value);
            }
        }

        private string _chkStyle;
        public string ChkStyle
        {
            get { return _chkStyle; }
            set
            {
                _chkStyle = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(ChkStyle), value);
            }
        }

        private bool _nocheckInherit;
        public bool NocheckInherit
        {
            get { return _nocheckInherit; }
            set
            {
                _nocheckInherit = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(NocheckInherit), value);
            }
        }

        private bool _chkDisabledInherit;
        public bool ChkDisabledInherit
        {
            get { return _chkDisabledInherit; }
            set
            {
                _chkDisabledInherit = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(ChkDisabledInherit), value);
            }
        }

        private string _radioType;
        public string RadioType
        {
            get { return _radioType; }
            set
            {
                _radioType = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(RadioType), value);
            }
        }

        #endregion

        IDictionary<string, object> IOptionKey.ConvertToDic()
        {
            return _hasSetOptionsProperties;
        }
    }
}