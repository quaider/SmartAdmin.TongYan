using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TongYan.Web.Controls.Tree.Options;

namespace TongYan.Web.Controls.Tree
{
    /// <summary>
    /// 树形控件渲染器
    /// </summary>
    public class TreeControlRender : DefaultWebControlRender<object>
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

        /// <summary>
        /// 组装zTree各模块配置信息
        /// </summary>
        /// <param name="key">模块对应的配置名称 如data-tree-async</param>
        /// <returns>StringBuilder</returns>
        protected override StringBuilder GetOptions(string key)
        {
            var builder = ParseNestedOptions(TreeOptions[key]);

            return builder;
        }

        protected override void RenderEnd()
        {
            RenderText(EndTag);
            //输出js脚本
        }
    }
}