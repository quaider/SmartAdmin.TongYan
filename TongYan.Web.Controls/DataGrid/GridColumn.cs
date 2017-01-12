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
        private readonly GridColumnsOptions _columnOptions;

        public GridColumn(string fieldName) : base(new DefaultWebControlOptions<object>())
        {
            Options.Render = new GridColumnRender();
            _columnOptions = new GridColumnsOptions
            {
                Data = fieldName,
                Name = fieldName
            };
        }

        public override string ToHtmlString()
        {
            foreach(var dic in (_columnOptions as IOptionKey).ConvertToDic())
            {
                Options.Options.SetKeyValue(dic.Key, dic.Value);
            }

            var writer = new StringWriter();
            Options.Render.Render(Options, writer, null);

            return writer.ToString();
        }

        #region IGridColumn Members

        IGridColumn IGridColumn.Align(Align align)
        {
            if (align == Align.Right)
            {
                _columnOptions.ClassName = (_columnOptions.ClassName + " text-right").Trim();
            }
            else if (align == Align.Center)
            {
                _columnOptions.ClassName = (_columnOptions.ClassName + " text-center").Trim();
            }

            //Options.Options.SetKeyValue

            return this;
        }

        IGridColumn IGridColumn.ClassName(string cls)
        {
            _columnOptions.ClassName = (_columnOptions.ClassName + " " + cls).Trim();
            return this;
        }

        IGridColumn IGridColumn.CreatedCellCallback(string callback)
        {
            _columnOptions.CreatedCell = callback;
            return this;
        }

        IGridColumn IGridColumn.DefaultContent(string content)
        {
            _columnOptions.DefaultContent = content;
            return this;
        }

        IGridColumn IGridColumn.Hidden()
        {
            _columnOptions.Visible = false;
            return this;
        }

        IGridColumn IGridColumn.Render(string render)
        {
            _columnOptions.Render = render;
            return this;
        }

        IGridColumn IGridColumn.Searchable()
        {
            _columnOptions.Searchable = true;
            return this;
        }

        IGridColumn IGridColumn.Title(string title)
        {
            _columnOptions.Title = title;
            return this;
        }

        IGridColumn IGridColumn.UnOrderable()
        {
            _columnOptions.Orderable = false;
            return this;
        }

        IGridColumn IGridColumn.Width(string width)
        {
            _columnOptions.Width = width;
            return this;
        }

        IGridColumn IGridColumn.Width(int width)
        {
            _columnOptions.Width = width.ToString();
            return this;
        }

        #endregion
    }
}