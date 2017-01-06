using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace TongYan.Web.Controls
{
    /// <summary>
    /// 默认控件渲染器
    /// </summary>
    /// <typeparam name="T">model type</typeparam>
    public class DefaultWebControlRender<T> : IWebControlRender<T>
    {
        private TextWriter _writer;

        /// <summary>
        /// Html流
        /// </summary>
        protected TextWriter Writer
        {
            get { return _writer; }
        }

        /// <summary>
        /// ViewContext
        /// </summary>
        protected ViewContext ViewContext { get; private set; }

        /// <summary>
        /// 控件配置信息
        /// </summary>
        protected IWebControlOptions<T> Options { get; private set; }

        /// <summary>
        /// 将控件渲染的Html写入到输出流
        /// </summary>
        /// <param name="options">组件配置项</param>
        /// <param name="output">输出流</param>
        /// <param name="viewContext">viewContext</param>
        public void Render(IWebControlOptions<T> options, TextWriter output, ViewContext viewContext)
        {
            Options = options;
            _writer = output;
            ViewContext = viewContext;

            RenderStart();
            RenderBody();
            RenderEnd();
        }

        /// <summary>
        /// Html开始标记
        /// </summary>
        protected virtual string BeginTag
        {
            get { return "<div{0}>"; }
        }

        /// <summary>
        /// Html结束标记
        /// </summary>
        protected virtual string EndTag
        {
            get { return "</div>"; }
        }

        protected virtual void RenderStart()
        {

        }

        /// <summary>
        /// eg: &lt;div class="test" data-val="1" data-options="border:0, width:200"&gt;
        /// </summary>
        protected virtual void RenderBody()
        {
            RenderText(string.Format(BeginTag, GetAttributes()));
        }

        /// <summary>
        /// eg: &lt;/div&gt;
        /// </summary>
        protected virtual void RenderEnd()
        {
            RenderWrapIndent(0);
            RenderText(EndTag);
        }

        #region Helpers

        /// <summary>
        /// 返回自定义Html特性的字符(a=b c=d ...)
        /// </summary>
        /// <returns>StringBuilder</returns>
        protected virtual StringBuilder GetAttributes()
        {
            var builder = new StringBuilder();
            if (Options.Attributes == null || !Options.Attributes.Keys.Any())
                return builder;

            builder.Append(" ");

            foreach (var attr in Options.Attributes)
            {
                if (!(attr.Value is IDictionary<string, object>))
                {
                    builder.AppendFormat("{0}=\"{1}\"", attr.Key, attr.Value);
                }
                else
                {
                    //eg: data-options = "fixed: true, border: 0"
                    //不同类型控件，我们都会我们会内置一些key
                    builder.AppendFormat("{0}=\"{1}\"", attr.Key, GetOptions(attr.Key));
                }

                if (attr.Key != Options.Attributes.Keys.Last())
                    builder.Append(" ");
            }

            return builder;
        }

        /// <summary>
        /// 返回控件的所有配置信息(eg: border:'none', pagination:true, width:200)
        /// </summary>
        /// <returns>StringBuilder</returns>
        protected virtual StringBuilder GetOptions(string key)
        {
            var builder = ParseNestedOptions(Options.Options);

            return builder;
        }

        /// <summary>
        /// 解析嵌套Dictionary为Html属性(注：配置并不是json格式，曾经陷入误区，它应该是js字面量！)
        /// </summary>
        /// <param name="dic">待解析字典配置</param>
        /// <returns>StringBuilder</returns>
        protected StringBuilder ParseNestedOptions(IDictionary<string, object> dic)
        {
            var builder = new StringBuilder();
            builder.Append("{");

            foreach (var option in dic)
            {
                if (option.Value is IDictionary<string, object>)
                {
                    builder.AppendFormat("{0}:{1}", option.Key,
                        ParseNestedOptions(option.Value as IDictionary<string, object>));
                }
                else if (option.Value is string)
                {
                    var value = option.Value.ToString();
                    if (!string.IsNullOrWhiteSpace(value) && (value.StartsWith("jo:") || value.StartsWith("fn:") || value.StartsWith("fr:")))
                    {
                        //解析js对象、函数
                        builder.AppendFormat("{0}:{1}", option.Key, value.Substring(3));
                    }
                    else
                    {
                        builder.AppendFormat("{0}:'{1}'", option.Key, option.Value);
                    }
                }
                else if (option.Value is bool)
                {
                    builder.AppendFormat("{0}:{1}", option.Key, option.Value.ToString().ToLower());
                }
                else if (option.Value is IEnumerable)
                {
                    builder.AppendFormat("{0}:{1}", option.Key, JsonConvert.SerializeObject(option.Value).Replace("\"","\'"));
                }
                else
                {
                    builder.AppendFormat("{0}:{1}", option.Key, option.Value);
                }

                if (option.Key != dic.Keys.Last())
                    builder.Append(",");
            }

            builder.Append("}");

            return builder;
        }

        /// <summary>
        /// 将Html写入流
        /// </summary>
        /// <param name="html"></param>
        protected void RenderText(string html)
        {
            _writer.Write(html);
        }

        /// <summary>
        /// 先换行再缩进
        /// </summary>
        protected void RenderWrapIndent(int indent = 1)
        {
            var indentStr = "\r\n";
            for (var i = 0; i < indent; i++)
            {
                indentStr += "\t";
            }

            RenderText(indentStr);
        }

        /// <summary>
        /// 写入流后换行缩进
        /// </summary>
        protected void RenderTextLine(string html)
        {
            RenderText(html);
            RenderWrapIndent();
        }

        #endregion
    }
}