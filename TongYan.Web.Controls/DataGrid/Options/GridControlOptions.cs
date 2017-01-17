using System;
using System.Collections.Generic;
using System.Linq;

namespace TongYan.Web.Controls.DataGrid.Options
{
    /// <summary>
    /// DataTable最外层配置封装
    /// </summary>
    public class GridControlOptions : DefaultWebControlMultipleOptions<object>
    {
        public GridControlOptions()
        {
            ColumnBuilders = new List<GridColumnsBuilder>();
            Render = new GridControlRender();
            ItemOptions = new List<IOptionKey>();
        }

        public bool Checkable { get; internal set; }

        /// <summary>
        /// DataTable列定义
        /// </summary>
        public IList<GridColumnsBuilder> ColumnBuilders { get; private set; }

        /// <summary>
        /// 复选框选择列
        /// </summary>
        internal GridColumn CheckGridColumn
        {
            get
            {
                if (!Checkable) return null;

                var title = "<div class=\"ckbox{1}\"><input id=\"{0}_check_all\" type =\"checkbox\">" +
                                "<label for=\"{0}_check_all\" ></label>" +
                            "</div>";

                return new GridColumn(string.Format(title, Id, ""));
            }
        }
    }
}
