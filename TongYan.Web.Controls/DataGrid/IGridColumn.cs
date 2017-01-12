using TongYan.Web.Controls.DataGrid.Options;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.DataGrid
{
    public interface IGridColumn
    {
        /// <summary>
        /// 设置列标题
        /// </summary>
        /// <param name="title">列标题</param>
        /// <returns>IGridColumn</returns>
        IGridColumn Title(string title);

        /// <summary>
        /// 设置列宽
        /// </summary>
        /// <param name="width">列宽度</param>
        /// <returns>IGridColumn</returns>
        IGridColumn Width(int width);

        /// <summary>
        /// 设置列宽
        /// </summary>
        /// <param name="width">列宽度('12px' or any other css styles)</param>
        /// <returns>IGridColumn</returns>
        IGridColumn Width(string width);

        /// <summary>
        /// 隐藏列， 默认是显示的
        /// </summary>
        /// <returns>IGridColumn</returns>
        IGridColumn Hidden();

        /// <summary>
        /// 可否搜索， 默认是可以的
        /// </summary>
        /// <returns>IGridColumn</returns>
        IGridColumn Searchable();

        /// <summary>
        /// 列呈现器
        /// </summary>
        /// <param name="render">列呈现器<seealso cref="GridColumnsOptions.Render"/></param>
        /// <returns>IGridColumn</returns>
        IGridColumn Render(string render);

        /// <summary>
        /// 不可排序列(默认是开启排序的)
        /// </summary>
        /// <returns>IGridColumn</returns>
        IGridColumn UnOrderable();

        /// <summary>
        /// 列的默认内容
        /// </summary>
        /// <param name="content">默认内容<seealso cref="GridColumnsOptions.DefaultContent"/></param>
        /// <returns>IGridColumn</returns>
        IGridColumn DefaultContent(string content);

        /// <summary>
        /// 列创建回调
        /// </summary>
        /// <param name="callback">回调函数名</param>
        /// <returns>IGridColumn</returns>
        IGridColumn CreatedCellCallback(string callback);

        /// <summary>
        /// 单元格样式
        /// </summary>
        /// <param name="cls">样式名</param>
        /// <returns>IGridColumn</returns>
        IGridColumn ClassName(string cls);

        /// <summary>
        /// 默认左对齐
        /// </summary>
        /// <returns>IGridColumn</returns>
        IGridColumn Align(Align align);


    }
}