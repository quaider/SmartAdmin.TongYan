using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TongYan.Web.Controls.DataGrid.Providers
{
    /// <summary>
    /// 数据库列提供器
    /// </summary>
    public abstract class GridColumnsProvider
    {
        public GridColumnsBuilder Builder { get; }

        protected GridColumnsProvider()
        {
            Builder = new GridColumnsBuilder();
            InitColumns();
        }

        protected abstract IList<IGridColumn> GetGridColumns();

        protected void InitColumns()
        {
            foreach (var c in GetGridColumns())
            {
                Builder.Column(c as GridColumn);
            }
        }
    }
}
