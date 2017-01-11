using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TongYan.Web.Controls.DataGrid.Options;

namespace TongYan.Web.Controls.DataGrid
{
    public class GridControl : WebControlBase<object>, IGridApi
    {
        public GridControl(string id) : base(new GridControlOptions())
        {

        }

        public override string ToHtmlString()
        {
            throw new NotImplementedException();
        }
    }
}
