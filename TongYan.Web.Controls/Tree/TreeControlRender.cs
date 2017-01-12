using System.Web.Mvc;
using TongYan.Web.Controls.Tree.Options;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.Tree
{
    /// <summary>
    /// 树形控件渲染器
    /// </summary>
    public class TreeControlRender : DefaultWebControlMultipleOptionsRender<object>
    {
        protected override string BeginTag
        {
            get { return "<ul{0}>"; }
        }

        protected override string EndTag
        {
            get { return "</ul>"; }
        }

        protected TreeControlOptions TreeOptions
        {
            get { return Options as TreeControlOptions; }
        }

        protected override void RenderScript()
        {
            ViewContext.HttpContext.WriteControlScript("$('#demoId').tyTree();");
        }
    }
}