namespace TongYan.Web.Controls.DataGrid
{
    public class GridColumnRender : DefaultWebControlRender<object>
    {
        protected override string BeginTag
        {
            get { return "<th{0}>"; }
        }

        protected override string EndTag
        {
            get { return "</th>"; }
        }
    }
}