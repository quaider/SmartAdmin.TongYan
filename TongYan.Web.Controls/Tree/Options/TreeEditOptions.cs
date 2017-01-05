using System;
using System.Collections.Generic;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.Tree.Options
{
    public class TreeEditOptions : IOptionKey
    {
        private readonly IDictionary<string, object> _hasSetOptionsProperties;
        public TreeEditOptions()
        {
            _hasSetOptionsProperties = new Dictionary<string, object>
            {
                {"Enable", true }
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
                _hasSetOptionsProperties.SetKeyValue(nameof(EditNameSelectAll), value);
            }
        }

        private string _removeTitle;
        public string RemoveTitle
        {
            get { return _removeTitle; }
            set
            {
                _removeTitle = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(RemoveTitle), value);
            }
        }

        private string _renameTitle;
        public string RenameTitle
        {
            get { return _renameTitle; }
            set
            {
                _renameTitle = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(RenameTitle), value);
            }
        }

        private bool _showRemoveBtn;
        public bool ShowRemoveBtn
        {
            get { return _showRemoveBtn; }
            set
            {
                _showRemoveBtn = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(ShowRemoveBtn), value);
            }
        }

        private bool _showRenameBtn;
        public bool ShowRenameBtn
        {
            get { return _showRenameBtn; }
            set
            {
                _showRenameBtn = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(ShowRenameBtn), value);
            }
        }

        #endregion

        IDictionary<string, object> IOptionKey.ConvertToDic()
        {
            _hasSetOptionsProperties.SetKeyValue(nameof(Drag), Drag.ConvertToDic());

            return _hasSetOptionsProperties;
        }
    }
}