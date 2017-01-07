using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TongYan.Web.Controls.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// 设置字典键值(有key则更新，无则添加)
        /// </summary>
        /// <param name="source">待设定的字典</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns>新的字典</returns>
        public static IDictionary<TKey, TValue> SetKeyValue<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue value)
        {
            source = source ?? new Dictionary<TKey, TValue>();
            if (source.ContainsKey(key))
                source[key] = value;
            else
                source.Add(key, value);

            return source;
        }

        /// <summary>
        /// 字符串首字母小写(驼峰)
        /// </summary>
        /// <param name="source">待转换字符串</param>
        /// <returns>驼峰字符串</returns>
        public static string ToCamelCaseString(this string source)
        {
            if (string.IsNullOrWhiteSpace(source)) return source;

            return source.Substring(0, 1).ToLower() + source.Substring(1);
        }

        public static void WriteControlScript(this HttpContextBase httpContext, string script)
        {
            var key = "__ControlScriptBlock__";
            if ((!httpContext.Items.Contains(key) || httpContext.Items[key] == null))
            {
                httpContext.Items[key] = new StringWriter();
            }

            var writer = httpContext.Items[key] as StringWriter;

            writer.WriteLine(script);
        }

        public static IHtmlString RenderControlScript(this HtmlHelper htmlHelper, bool containsScriptBlock = true)
        {
            var key = "__ControlScriptBlock__";
            var httpContext = htmlHelper.ViewContext.HttpContext;
            if (!httpContext.Items.Contains(key) || httpContext.Items[key] == null) return MvcHtmlString.Create("");

            var writer = httpContext.Items[key] as StringWriter;
            if (containsScriptBlock)
            {
                var builder = new StringBuilder();
                builder.AppendLine("<script>");
                builder.AppendLine("\t\t$(function(){");
                builder.AppendLine("\t\t\t" + writer.ToString());
                builder.AppendLine("\t\t});");
                builder.AppendLine("\t</script>");

                return MvcHtmlString.Create(builder.ToString());
            }

            return MvcHtmlString.Create(writer.ToString());
        }

        /// <summary>
        /// 封装了自定义控件集
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <returns>IWebControlWrapper</returns>
        public static IWebControlWrapper<T> Control<T>(this HtmlHelper<T> htmlHelper)
        {
            return new WebControlWrapper<T>(htmlHelper);
        }
    }
}