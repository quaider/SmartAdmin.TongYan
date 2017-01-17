using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TongYan.Web.Controls.DataGrid.Options;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.DataGrid
{
    public class GridControlRender : DefaultWebControlMultipleOptionsRender<object>
    {
        protected override string BeginTag
        {
            get { return "<table{0}>"; }
        }

        protected override string EndTag
        {
            get { return "</table>"; }
        }

        /// <summary>
        /// 强类型表格控件配置信息
        /// </summary>
        protected GridControlOptions GridControlOptions
        {
            get { return Options as GridControlOptions; }
        }

        protected override void RenderBody()
        {
            base.RenderBody();
            RenderColumns();
        }

        /// <summary>
        /// table thead 列渲染
        /// </summary>
        protected virtual void RenderColumns()
        {
            RenderWrapIndent(1);
            RenderText("<thead>");

            //设置勾选列
            if (GridControlOptions.Checkable && GridControlOptions.ColumnBuilders.Any())
            {
                var ckCol = GridControlOptions.CheckGridColumn as IGridColumn;
                if (GridControlOptions.ColumnBuilders.Count > 1)
                    ckCol.Rowspan(GridControlOptions.ColumnBuilders.Count);

                GridControlOptions.ColumnBuilders.First().Insert(0, (GridColumn)ckCol);
            }

            //组装Thead tr 及 th
            foreach (var builder in GridControlOptions.ColumnBuilders)
            {
                //tr
                RenderWrapIndent(2);
                RenderText("<tr>");

                //th
                foreach (var column in builder)
                {
                    RenderWrapIndent(3);
                    RenderText(column.ToString());
                }

                RenderWrapIndent(2);
                RenderText("</tr>");
            }

            RenderWrapIndent(1);
            RenderText("</thead>");
            RenderWrapIndent(1);
        }

        protected override void RenderScript()
        {
            ViewContext.HttpContext.WriteControlScript(string.Format("$('#{0}').tyDataTable();", GridControlOptions.Id));
        }
    }
}
