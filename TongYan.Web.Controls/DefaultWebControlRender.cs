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
                    InitOptions(attr.Key);
                    builder.AppendFormat("{0}=\'{1}'", attr.Key, JsonConvert.SerializeObject(DynamicOptionContainer));
                }

                if (attr.Key != Options.Attributes.Keys.Last())
                    builder.Append(" ");
            }

            return builder;
        }

        /// <summary>
        /// 设置控件的所有配置信息(eg: border:'none', pagination:true, width:200)
        /// </summary>
        /// <returns>StringBuilder</returns>
        protected virtual void InitOptions(string key)
        {
            ParseNestedOptions(Options.Options);
        }

        /// <summary>
        /// 存放配置数据的容器
        /// </summary>
        protected dynamic DynamicOptionContainer = new ExpandoObject();

        /// <summary>
        /// 解析嵌套Dictionary为Html属性
        /// todo: 待改成嵌套对象再序列化的形式
        /// </summary>
        /// <param name="dic">待解析字典配置</param>
        /// <returns>StringBuilder</returns>
        protected dynamic ParseNestedOptions(IDictionary<string, object> dic)
        {
            //临时容器
            dynamic currentOptionContainer = new ExpandoObject();
            var d = currentOptionContainer as IDictionary<string, object>;

            //全局容器
            var dynamicDic = DynamicOptionContainer as IDictionary<string, object>;

            foreach (var option in dic)
            {
                if (option.Value is IDictionary<string, object>)
                {
                    dynamicDic[option.Key] = ParseNestedOptions(option.Value as IDictionary<string, object>);
                }
                else
                {
                    dynamicDic[option.Key] = option.Value;
                    d[option.Key] = option.Value;
                }
            }

            return d;
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