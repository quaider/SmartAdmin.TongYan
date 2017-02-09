using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TongYan.Web.Controls.DataGrid.Providers
{
    /// <summary>
    /// 简单测试Provider
    /// </summary>
    public class JsonGridColumnsProvider : GridColumnsProvider
    {
        protected override IList<IList<IGridColumn>> GetGridColumns(string group)
        {
            var columnsGroups = new List<IList<IGridColumn>>();
            var jsonStr = File.ReadAllText(HttpContext.Current.Server.MapPath("~/test/columns.json"));
            var allColumnsCgfs = JsonConvert.DeserializeObject<IList<IList<GridColumn4Provider>>>(jsonStr);
            var keyColumns = allColumnsCgfs.SingleOrDefault(f => f.Count(c => c.Key == group) > 0);

            foreach (var row in keyColumns.GroupBy(f => f.Row).Select(f => f.Key))
            {
                var columns = new List<IGridColumn>();
                foreach (var c in keyColumns.Where(f => f.Row == row).OrderBy(f => f.ShowOrder))
                {
                    IGridColumn gridColumn = new GridColumn(c.Title);

                    if (c.Name != null)
                    {
                        gridColumn.Name(c.Name);
                    }

                    if (c.Orderable.HasValue && !c.Orderable.Value)
                    {
                        gridColumn.UnOrderable();
                    }

                    if (c.Searchable.HasValue && !c.Searchable.Value)
                    {
                        gridColumn.UnSearchable();
                    }

                    if (c.Rowspan.HasValue && c.Rowspan.Value > 1)
                    {
                        gridColumn.Rowspan(c.Rowspan.Value);
                    }

                    if (c.Colspan.HasValue && c.Colspan.Value > 1)
                    {
                        gridColumn.Colspan(c.Colspan.Value);
                    }

                    if (c.CrossRowDataColumnsOrder.HasValue)
                    {
                        gridColumn.SetOrderCrossRows(c.CrossRowDataColumnsOrder.Value);
                    }

                    if (!string.IsNullOrWhiteSpace(c.Width))
                    {
                        gridColumn.Width(c.Width);
                    }

                    if (!string.IsNullOrWhiteSpace(c.ClassName))
                    {
                        gridColumn.ClassName(c.ClassName.Trim());
                    }

                    if (!string.IsNullOrWhiteSpace(c.Render))
                    {
                        gridColumn.Render(c.Render);
                    }

                    columns.Add(gridColumn);
                }

                columnsGroups.Add(columns);
            }

            return columnsGroups;
        }
    }
}
