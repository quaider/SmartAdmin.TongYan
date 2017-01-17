using System;
using System.Collections.Generic;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.Tree.Options
{
    public class TreeEditOptions : IOptionKey
    {
        private readonly IDictionary<string, object> _hasSetOptionsProperties;
        internal TreeEditOptions()
        {
            _hasSetOptionsProperties = new Dictionary<string, object>
            {
                {"enable", true }
            };

            _drag = new TreeEditWithDragOptions();
        }

        public string OptionKey
        {
            get { return "data-tree-edit"; }
        }

        #region 对应zTree的edit配置

        private readonly TreeEditWithDragOptions _drag;
        public TreeEditWithDragOptions Drag
        {
            get { return _drag; }
        }

        private bool _editNameSelectAll;
        public bool EditNameSelectAll
        {
            get { return _editNameSelectAll; }
            set
            {
                _editNameSelectAll = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.EditNameSelectAll).ToCamelCaseString(), value);
            }
        }

        private string _removeTitle;
        public string RemoveTitle
        {
            get { return _removeTitle; }
            set
            {
                _removeTitle = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.RemoveTitle).ToCamelCaseString(), value);
            }
        }

        private string _renameTitle;
        public string RenameTitle
        {
            get { return _renameTitle; }
            set
            {
                _renameTitle = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.RenameTitle).ToCamelCaseString(), value);
            }
        }

        private bool _showRemoveBtn;
        public bool ShowRemoveBtn
        {
            get { return _showRemoveBtn; }
            set
            {
                _showRemoveBtn = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.ShowRemoveBtn).ToCamelCaseString(), value);
            }
        }

        private bool _showRenameBtn;
        public bool ShowRenameBtn
        {
            get { return _showRenameBtn; }
            set
            {
                _showRenameBtn = value;
                _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.ShowRenameBtn).ToCamelCaseString(), value);
            }
        }

        #endregion

        IDictionary<string, object> IOptionKey.ConvertToDic()
        {
            _hasSetOptionsProperties.SetKeyValue(this.NameOf(f => f.Drag).ToCamelCaseString(), Drag.ConvertToDic());

            return _hasSetOptionsProperties;
        }
    }
}