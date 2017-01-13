using System.Text;
using TongYan.Web.Controls.DataGrid.Options;

namespace TongYan.Web.Controls.DataGrid
{
    public class GridColumnRender : DefaultWebControlRender<object>
    {
        protected GridColumnsOptions GridColumnsOptions
        {
            get { return Options as GridColumnsOptions; }
        }
        protected override string BeginTag
        {
            get { return "<th{0}>"; }
        }

        protected override string EndTag
        {
            get { return "</th>"; }
        }

        protected override StringBuilder GetAttributes()
        {
            
            return new StringBuilder();
        }
    }
}