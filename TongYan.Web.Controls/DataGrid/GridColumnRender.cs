﻿using System.Text;
using TongYan.Web.Controls.DataGrid.Options;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls.DataGrid
{
    public class GridColumnRender : DefaultWebControlRender<object>
    {
        public GridColumnRender(GridColumnOptions opt)
        {
            GridColumnsOptions = opt;
        }

        protected GridColumnOptions GridColumnsOptions { get; private set; }

        protected override string BeginTag
        {
            get { return "<th{0}>"; }
        }

        protected override string EndTag
        {
            get { return "</th>"; }
        }

        protected override void RenderBody()
        {
            base.RenderBody();
            RenderText(GridColumnsOptions.Title);
        }

        protected override void RenderEnd()
        {
            RenderText(EndTag);
        }
    }
}