using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TongYan.Web.Controls;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls
{
    /// <summary>
    /// 具有多个Html属性的默认呈现器实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DefaultWebControlMultipleOptionsRender<T> : DefaultWebControlRender<T>
    {
        protected DefaultWebControlMultipleOptions<T> MultipleOptions
        {
            get { return Options as DefaultWebControlMultipleOptions<T>; }
        }

        /// <summary>
        /// 组装zTree各模块配置信息
        /// </summary>
        /// <param name="key">模块对应的配置名称 如data-tree-async</param>
        /// <returns>StringBuilder</returns>
        protected override StringBuilder GetOptions(string key)
        {
            var builder = ParseNestedOptions(MultipleOptions[key]);

            return builder;
        }

        protected override void RenderEnd()
        {
            RenderTextLine(EndTag);

            if (MultipleOptions.RunScript)
                RenderScript();
        }

        protected virtual void RenderScript()
        {
            
        }
    }
}
