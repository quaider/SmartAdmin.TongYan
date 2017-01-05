using System.IO;
using System.Web.Mvc;

namespace TongYan.Web.Controls
{
    /// <summary>
    /// 控件渲染器(生成Html等)
    /// </summary>
    /// <typeparam name="T">model type</typeparam>
    public interface IWebControlRender<T>
    {
        /// <summary>
        /// 将组件渲染的Html写入到输出流
        /// </summary>
        /// <param name="options">组件配置项</param>
        /// <param name="output">输出流</param>
        /// <param name="viewContext">viewContext</param>
        void Render(IWebControlOptions<T> options, TextWriter output, ViewContext viewContext);
    }
}