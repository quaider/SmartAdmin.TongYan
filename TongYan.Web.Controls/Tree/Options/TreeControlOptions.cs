using System.Collections.Generic;
using System.Linq;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.Tree.Options
{
    /// <summary>
    /// 包含整个树的配置信息
    /// </summary>
    public class TreeControlOptions : DefaultWebControlOptions<object>
    {
        public IList<IOptionKey> ItemOptions { get; private set; }

        /// <summary>
        /// 是否执行脚本
        /// </summary>
        public bool RunScript { get; private set; }

        /// <summary>
        /// 初始化整个树的配置信息
        /// </summary>
        public TreeControlOptions()
        {
            ItemOptions = new List<IOptionKey>();
            Render = new TreeControlRender();
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
        public void EnableClientScript()
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