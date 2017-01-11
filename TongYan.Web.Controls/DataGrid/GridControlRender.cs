using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TongYan.Web.Controls.DataGrid
{
    public class GridControlRender : DefaultWebControlRender<object>
    {
        protected override string BeginTag
        {
            get { return "<table{0}>"; }
        }

        protected override string EndTag
        {
            get { return "</table>"; }
        }
    }
}
