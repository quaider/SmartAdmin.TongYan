using System.Collections.Generic;

namespace TongYan.Web.Controls
{
    /// <summary>
    /// 控件通用配置
    /// </summary>
    public interface IWebControlOptions<T>
    {
        /// <summary>
        /// 控件唯一标识
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// 自定义Html attribute
        /// </summary>
        IDictionary<string, object> Attributes { get; set; }

        /// <summary>
        /// 配置信息(不同控件结构可能都不一样)
        /// </summary>
        IDictionary<string, object> Options { get; }

        /// <summary>
        /// 控件渲染器
        /// </summary>
        IWebControlRender<T> Render { get; set; }
    }
}