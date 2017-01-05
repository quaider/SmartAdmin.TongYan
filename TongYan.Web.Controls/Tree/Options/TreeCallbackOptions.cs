using System;
using System.Collections.Generic;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.Tree.Options
{
    public class TreeCallbackOptions : IOptionKey
    {
        private readonly IDictionary<string, object> _hasSetOptionsProperties;

        public TreeCallbackOptions()
        {
            _hasSetOptionsProperties = new Dictionary<string, object>();
        }

        public string OptionKey
        {
            get { return "data-tree-callback"; }
        }

        #region 对应zTree的callback配置

        private string _beforeAsync;
        public string BeforeAsync
        {
            get { return _beforeAsync; }
            set
            {
                _beforeAsync = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(BeforeAsync), value);
            }
        }

        private string _beforeCheck;
        public string BeforeCheck
        {
            get { return _beforeCheck; }
            set
            {
                _beforeCheck = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(BeforeCheck), value);
            }
        }

        private string _beforeClick;
        public string BeforeClick
        {
            get { return _beforeClick; }
            set
            {
                _beforeClick = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(BeforeClick), value);
            }
        }

        private string _beforeCollapse;
        public string BeforeCollapse
        {
            get { return _beforeCollapse; }
            set
            {
                _beforeCollapse = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(BeforeCollapse), value);
            }
        }

        private string _beforeDblClick;
        public string BeforeDblClick
        {
            get { return _beforeDblClick; }
            set
            {
                _beforeDblClick = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(BeforeDblClick), value);
            }
        }

        private string _beforeDrag;
        public string BeforeDrag
        {
            get { return _beforeDrag; }
            set
            {
                _beforeDrag = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(BeforeDrag), value);
            }
        }

        private string _beforeDragOpen;
        public string BeforeDragOpen
        {
            get { return _beforeDragOpen; }
            set
            {
                _beforeDragOpen = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(BeforeDragOpen), value);
            }
        }

        private string _beforeDrop;
        public string BeforeDrop
        {
            get { return _beforeDrop; }
            set
            {
                _beforeDrop = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(BeforeDrop), value);
            }
        }

        private string _beforeEditName;
        public string BeforeEditName
        {
            get { return _beforeEditName; }
            set
            {
                _beforeEditName = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(BeforeEditName), value);
            }
        }

        private string _beforeExpand;
        public string BeforeExpand
        {
            get { return _beforeExpand; }
            set
            {
                _beforeExpand = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(BeforeExpand), value);
            }
        }

        private string _beforeMouseDown;
        public string BeforeMouseDown
        {
            get { return _beforeMouseDown; }
            set
            {
                _beforeMouseDown = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(BeforeMouseDown), value);
            }
        }

        private string _beforeMouseUp;
        public string BeforeMouseUp
        {
            get { return _beforeMouseUp; }
            set
            {
                _beforeMouseUp = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(BeforeMouseUp), value);
            }
        }

        private string _beforeRemove;
        public string BeforeRemove
        {
            get { return _beforeRemove; }
            set
            {
                _beforeRemove = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(BeforeRemove), value);
            }
        }

        private string _beforeRename;
        public string BeforeRename
        {
            get { return _beforeRename; }
            set
            {
                _beforeRename = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(BeforeRename), value);
            }
        }

        private string _beforeRightClick;
        public string BeforeRightClick
        {
            get { return _beforeRightClick; }
            set
            {
                _beforeRightClick = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(BeforeRightClick), value);
            }
        }

        private string _onAsyncError;
        public string OnAsyncError
        {
            get { return _onAsyncError; }
            set
            {
                _onAsyncError = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(OnAsyncError), value);
            }
        }

        private string _onAsyncSuccess;
        public string OnAsyncSuccess
        {
            get { return _onAsyncSuccess; }
            set
            {
                _onAsyncSuccess = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(OnAsyncSuccess), value);
            }
        }

        private string _onCheck;
        public string OnCheck
        {
            get { return _onCheck; }
            set
            {
                _onCheck = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(OnCheck), value);
            }
        }

        private string _onClick;
        public string OnClick
        {
            get { return _onClick; }
            set
            {
                _onClick = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(OnClick), value);
            }
        }

        private string _onCollapse;
        public string OnCollapse
        {
            get { return _onCollapse; }
            set
            {
                _onCollapse = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(OnCollapse), value);
            }
        }

        private string _onDblClick;
        public string OnDblClick
        {
            get { return _onDblClick; }
            set
            {
                _onDblClick = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(OnDblClick), value);
            }
        }

        private string _onDrag;
        public string OnDrag
        {
            get { return _onDrag; }
            set
            {
                _onDrag = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(OnDrag), value);
            }
        }

        private string _onDragMove;
        public string OnDragMove
        {
            get { return _onDragMove; }
            set
            {
                _onDragMove = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(OnDragMove), value);
            }
        }

        private string _onDrop;
        public string OnDrop
        {
            get { return _onDrop; }
            set
            {
                _onDrop = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(OnDrop), value);
            }
        }

        private string _onExpand;
        public string OnExpand
        {
            get { return _onExpand; }
            set
            {
                _onExpand = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(OnExpand), value);
            }
        }

        private string _onMouseDown;
        public string OnMouseDown
        {
            get { return _onMouseDown; }
            set
            {
                _onMouseDown = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(OnMouseDown), value);
            }
        }

        private string _onMouseUp;
        public string OnMouseUp
        {
            get { return _onMouseUp; }
            set
            {
                _onMouseUp = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(OnMouseUp), value);
            }
        }

        private string _onNodeCreated;
        public string OnNodeCreated
        {
            get { return _onNodeCreated; }
            set
            {
                _onNodeCreated = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(OnNodeCreated), value);
            }
        }

        private string _onRemove;
        public string OnRemove
        {
            get { return _onRemove; }
            set
            {
                _onRemove = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(OnRemove), value);
            }
        }

        private string _onRename;
        public string OnRename
        {
            get { return _onRename; }
            set
            {
                _onRename = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(OnRename), value);
            }
        }

        private string _onRightClick;
        public string OnRightClick
        {
            get { return _onRightClick; }
            set
            {
                _onRightClick = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(OnRightClick), value);
            }
        }

        #endregion

        IDictionary<string, object> IOptionKey.ConvertToDic()
        {
            return _hasSetOptionsProperties;
        }
    }
}