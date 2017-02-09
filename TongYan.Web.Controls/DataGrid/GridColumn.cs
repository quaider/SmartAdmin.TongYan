using System;
using System.IO;
using TongYan.Web.Controls.DataGrid.Options;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.DataGrid
{
    /// <summary>
    /// DataTable Column控件部分
    /// </summary>
    public class GridColumn : WebControlBase<object>, IGridColumn
    {
        /// <summary>
        /// 存储列配置信息
        /// </summary>
        internal GridColumnOptions ColumnOptions { get; private set; }

        public GridColumn(string title) : base(new DefaultWebControlOptions<object>("data-grid-column"))
        {
            ColumnOptions = new GridColumnOptions()
            {
                Title = title
            };

            Options.Render = new GridColumnRender(ColumnOptions);
        }

        public override string ToHtmlString()
        {
            foreach (var dic in ColumnOptions.ConvertToDic())
            {
                Options.Options.SetKeyValue(dic.Key, dic.Value);
            }

            var writer = new StringWriter();
            Options.Render.Render(Options, writer, null);

            return writer.ToString();
        }

        public string GetColumnName()
        {
            return ColumnOptions.Name;
        }

        #region IGridColumn Members

        IGridColumn IGridColumn.ClassName(string cls)
        {
            //设置表头样式(多列时需设置)
            AddClass(cls);
            //设置表内容样式
            ColumnOptions.ClassName = cls;
            return this;
        }

        IGridColumn IGridColumn.CreatedCellCallback(string callback)
        {
            ColumnOptions.CreatedCell = callback;
            return this;
        }

        IGridColumn IGridColumn.DefaultContent(string content)
        {
            ColumnOptions.DefaultContent = content;
            return this;
        }

        IGridColumn IGridColumn.Hidden()
        {
            ColumnOptions.Visible = false;
            return this;
        }

        /// <summary>
        /// 列呈现器
        /// </summary>
        /// <param name="render">呈现器函数(自动以fr:打头)</param>
        /// <returns>IGridColumn</returns>
        IGridColumn IGridColumn.Render(string render)
        {
            ColumnOptions.Render = render.StartsWith("fr:") ? render : ("fr:" + render);
            return this;
        }

        IGridColumn IGridColumn.UnSearchable()
        {
            ColumnOptions.Searchable = false;
            return this;
        }

        IGridColumn IGridColumn.Title(string title)
        {
            ColumnOptions.Title = title;
            return this;
        }

        IGridColumn IGridColumn.Name(string name)
        {
            ColumnOptions.Data = name;
            ColumnOptions.Name = name;
            return this;
        }

        IGridColumn IGridColumn.UnOrderable()
        {
            ColumnOptions.Orderable = false;
            return this;
        }

        IGridColumn IGridColumn.Width(string width)
        {
            ColumnOptions.Width = width;
            return this;
        }

        IGridColumn IGridColumn.Width(int width)
        {
            ColumnOptions.Width = width.ToString();
            return this;
        }

        IGridColumn IGridColumn.Rowspan(int rows)
        {
            if (rows > 1)
                Options.Attributes.SetKeyValue("rowspan", rows);
            return this;
        }

        IGridColumn IGridColumn.Colspan(int cols)
        {
            if (cols > 1)
                Options.Attributes.SetKeyValue("colspan", cols);
            return this;
        }

        IGridColumn IGridColumn.SetOrderCrossRows(int order)
        {
            Options.Attributes.SetKeyValue("data-grid-columnOrder", order);
            return this;
        }

        #endregion
    }
}