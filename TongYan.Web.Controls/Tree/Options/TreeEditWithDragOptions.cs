using System.Collections.Generic;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.Tree.Options
{
    public class TreeEditWithDragOptions
    {
        private readonly IDictionary<string, object> _hasSetOptionsProperties;
        public TreeEditWithDragOptions()
        {
            _hasSetOptionsProperties = new Dictionary<string, object>();
        }

        #region 对应zTree的edit.drag配置

        private bool _autoExpandTrigger;
        public bool AutoExpandTrigger
        {
            get { return _autoExpandTrigger; }
            set
            {
                _autoExpandTrigger = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(AutoExpandTrigger), value);
            }
        }

        private bool _isCopy;
        public bool IsCopy
        {
            get { return _isCopy; }
            set
            {
                _isCopy = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(IsCopy), value);
            }
        }

        private bool _isMove;
        public bool IsMove
        {
            get { return _isMove; }
            set
            {
                _isMove = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(IsMove), value);
            }
        }

        private bool _prev;
        public bool Prev
        {
            get { return _prev; }
            set
            {
                _prev = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(Prev), value);
            }
        }

        private bool _next;
        public bool Next
        {
            get { return _next; }
            set
            {
                _next = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(Next), value);
            }
        }

        private bool _inner;
        public bool Inner
        {
            get { return _inner; }
            set
            {
                _inner = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(Inner), value);
            }
        }

        private int _borderMax;
        public int BorderMax
        {
            get { return _borderMax; }
            set
            {
                _borderMax = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(BorderMax), value);
            }
        }

        private int _borderMin;
        public int BorderMin
        {
            get { return _borderMin; }
            set
            {
                _borderMin = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(BorderMin), value);
            }
        }

        private int _minMoveSize;
        public int MinMoveSize
        {
            get { return _minMoveSize; }
            set
            {
                _minMoveSize = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(MinMoveSize), value);
            }
        }

        private int _maxShowNodeNum;
        public int MaxShowNodeNum
        {
            get { return _maxShowNodeNum; }
            set
            {
                _maxShowNodeNum = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(MaxShowNodeNum), value);
            }
        }

        private int _autoOpenTime;
        public int AutoOpenTime
        {
            get { return _autoOpenTime; }
            set
            {
                _autoOpenTime = value;
                _hasSetOptionsProperties.SetKeyValue(nameof(AutoOpenTime), value);
            }
        }

        #endregion

        internal IDictionary<string, object> ConvertToDic()
        {
            return _hasSetOptionsProperties;
        }
    }
}