using System;
using System.Collections.Generic;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.Tree.Options
{
    public class TreeViewOptions : IOptionKey
    {
        private readonly IDictionary<string, object> _hasSetOptionsProperties;
        public TreeViewOptions()
        {
            _hasSetOptionsProperties = new Dictionary<string, object>();
        }

        public string OptionKey
        {
            get { return "data-tree-view"; }
        }

        #region 对应zTree的view配置

        private string _addDiyDom;
        public string AddDiyDom
        {
            get { return _addDiyDom; }
            set
            {
                _addDiyDom = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.AddDiyDom), value);
            }
        }

        private string _addHoverDom;
        public string AddHoverDom
        {
            get { return _addHoverDom; }
            set
            {
                _addHoverDom = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.AddHoverDom), value);
            }
        }

        private bool _autoCancelSelected;
        public bool AutoCancelSelected
        {
            get { return _autoCancelSelected; }
            set
            {
                _autoCancelSelected = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.AutoCancelSelected), value);
            }
        }

        private bool _dblClickExpand;
        public bool DblClickExpand
        {
            get { return _dblClickExpand; }
            set
            {
                _dblClickExpand = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.DblClickExpand), value);
            }
        }

        private string _expandSpeed;
        public string ExpandSpeed
        {
            get { return _expandSpeed; }
            set
            {
                _expandSpeed = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.ExpandSpeed), value);
            }
        }

        private string _fontCss;
        public string FontCss
        {
            get { return _fontCss; }
            set
            {
                _fontCss = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.FontCss), value);
            }
        }

        private bool _nameIsHTML;
        public bool NameIsHTML
        {
            get { return _nameIsHTML; }
            set
            {
                _nameIsHTML = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.NameIsHTML), value);
            }
        }

        private string _removeHoverDom;
        public string RemoveHoverDom
        {
            get { return _removeHoverDom; }
            set
            {
                _removeHoverDom = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.RemoveHoverDom), value);
            }
        }

        private string _selectedMulti;
        public string SelectedMulti
        {
            get { return _selectedMulti; }
            set
            {
                _selectedMulti = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.SelectedMulti), value);
            }
        }

        private bool _showIcon;
        public bool ShowIcon
        {
            get { return _showIcon; }
            set
            {
                _showIcon = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.ShowIcon), value);
            }
        }

        private bool _showLine;
        public bool ShowLine
        {
            get { return _showLine; }
            set
            {
                _showLine = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.ShowLine), value);
            }
        }

        private bool _showTitle;
        public bool ShowTitle
        {
            get { return _showTitle; }
            set
            {
                _showTitle = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.ShowTitle), value);
            }
        }

        private bool _txtSelectedEnable;
        public bool TxtSelectedEnable
        {
            get { return _txtSelectedEnable; }
            set
            {
                _txtSelectedEnable = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.TxtSelectedEnable), value);
            }
        }

        #endregion

        IDictionary<string, object> IOptionKey.ConvertToDic()
        {
            return _hasSetOptionsProperties;
        }
    }
}