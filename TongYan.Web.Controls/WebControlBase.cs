using System.Web;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls
{
    /// <summary>
    /// 控件基类
    /// </summary>
    /// <typeparam name="T">模型类型(通常它是object)</typeparam>
    public abstract class WebControlBase<T> : IHtmlString
    {
        protected WebControlBase(IWebControlOptions<T> options)
        {
            Options = options;
        }

        /// <summary>
        /// 控件配置
        /// </summary>
        protected IWebControlOptions<T> Options { get; set; }

        /// <summary>
        /// 控件Html渲染
        /// </summary>
        /// <returns>Html code</returns>
        public abstract string ToHtmlString();

        /// <summary>
        /// 控件Html渲染 参考<see cref="ToHtmlString"/>
        /// </summary>
        /// <returns>Html code</returns>
        public override string ToString()
        {
            return ToHtmlString();
        }

        protected void AddClass(params string[] classes)
        {
            var clsStr = string.Join(" ", classes);
            AddClass(clsStr);
        }

        protected void AddClass(string classes)
        {
            var cls = !Options.Attributes.Keys.Contains("class") || Options.Attributes["class"] == null
                ? ""
                : Options.Attributes["class"].ToString();

            if (!string.IsNullOrWhiteSpace(classes))
                cls += string.Format(" {0}", string.Join(" ", classes));

            Options.Attributes.SetKeyValue("class", cls.Trim());
        }
    }
}