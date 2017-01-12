using System.Collections.Generic;

namespace TongYan.Web.Controls.Tree.Options
{
    /// <summary>
    /// 包含整个树的配置信息
    /// </summary>
    public class TreeControlOptions : DefaultWebControlMultipleOptions<object>
    {
        /// <summary>
        /// 初始化整个树的配置信息
        /// </summary>
        public TreeControlOptions()
        {
            ItemOptions = new List<IOptionKey>();
            Render = new TreeControlRender();
        }
    }
}