using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TongYan.Web.Controls.DataGrid.Options;

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

        protected virtual void RenderColumns()
        {
            RenderWrapIndent(1);
            RenderText("<thead>");
            RenderWrapIndent(2);
            RenderText("<tr>");

            //th
            foreach (var column in GridControlOptions.Columns)
            {
                RenderWrapIndent(3);
                RenderText(column.ToString());
            }

            RenderWrapIndent(2);
            RenderText("</tr>");
            RenderWrapIndent(1);
            RenderText("</thead>");
        }

        protected override void RenderScript()
        {

        }
    }
}
