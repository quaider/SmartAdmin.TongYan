using System;
using System.Collections.Generic;
using System.Linq;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls
{
    /// <summary>
    /// 具有多个Html属性的默认配置实现
    /// </summary>
    public class DefaultWebControlMultipleOptions<T> : DefaultWebControlOptions<T>
    {
        /// <summary>
        /// 各配置项(一个控件有多个Html Attribute配置项 如data-grid-columns 和 data-grid-styles等)
        /// 开发者注：我鼓励(建议)这样的模块化配置
        /// </summary>
        public IList<IOptionKey> ItemOptions { get; protected set; }

        /// <summary>
        /// 是否执行脚本
        /// </summary>
        public bool RunScript { get; protected set; }

        /// <summary>
        /// 初始化整个树的配置信息
        /// </summary>
        public DefaultWebControlMultipleOptions()
        {
            ItemOptions = new List<IOptionKey>();
            Render = new DefaultWebControlMultipleOptionsRender<T>();
        }

        /// <summary>
        /// 返回特性之外的配置信息(2层Dictionary, Options本身可能就是嵌套的Dictionary)
        /// </summary>
        public override IDictionary<string, object> Options
        {
            get
            {
                return Attributes
                        .Where(a => ItemOptions.Select(f => f.OptionKey).Contains(a.Key))
                        .ToDictionary(f => f.Key, f => f.Value);
            }
        }

        /// <summary>
        /// 返回指定模块的配置
        /// </summary>
        /// <param name="key">如data-tree-async</param>
        /// <returns>对应模块的全部配置信息</returns>
        public IDictionary<string, object> this[string key]
        {
            get { return Options[key] as IDictionary<string, object>; }
        }

        /// <summary>
        /// 运行脚本
        /// </summary>
        public virtual void EnableClientScript()
        {
            RunScript = true;
        }

        /// <summary>
        /// 设定配置项
        /// </summary>
        /// <param name="itemOptions">具体功能的配置项</param>
        public void SetItemOptions(IOptionKey itemOptions)
        {
            var orginalOpts = ItemOptions.SingleOrDefault(f => f.OptionKey == itemOptions.OptionKey);
            if (orginalOpts != null)
            {
                ItemOptions.Remove(orginalOpts);
            }

            ItemOptions.Add(itemOptions);

            //同步到Attributes, 某种意义上，option实际上就是Attributes
            if (!Attributes.Keys.Contains(itemOptions.OptionKey))
                Attributes.SetKeyValue(itemOptions.OptionKey, itemOptions.ConvertToDic());
        }
    }
}
