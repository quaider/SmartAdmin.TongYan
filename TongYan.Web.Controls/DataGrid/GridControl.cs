using System;
using System.IO;
using TongYan.Web.Controls.DataGrid.Options;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.DataGrid
{
    /// <summary>
    /// Grid最外层包装
    /// </summary>
    public class GridControl : WebControlBase<object>, IGridApi
    {
        public GridControl(string id) : base(new GridControlOptions())
        {
            Options.Id = id;
            InitDefault();
        }

        protected GridControlOptions GridCtrlOptions
        {
            get { return Options as GridControlOptions; }
        }

        public override string ToHtmlString()
        {
            var writer = new StringWriter();
            GridCtrlOptions.Render.Render(GridCtrlOptions, writer, null);
            return writer.ToString();
        }

        public IGridApi GridOptions(Action<GridOptions> action)
        {
            var gridOptions = new GridOptions();
            if (action != null)
                action(gridOptions);

            return this;
        }

        private void InitDefault()
        {
            AddClass("table table-hover table-bordered table-striped");
        }
    }
}
