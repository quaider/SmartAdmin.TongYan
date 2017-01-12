using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TongYan.Web.Controls.DataGrid.Options;

namespace TongYan.Web.Controls.DataGrid
{
    /// <summary>
    /// 提供Grid对外Api, 需显示实现此接口
    /// </summary>
    public interface IGridApi
    {
        /// <summary>
        /// https://www.datatables.net/reference/option/  Chapter 'DataTables - Options'
        /// </summary>
        /// <param name="action">配置委托</param>
        /// <returns>IGridApi</returns>
        IGridApi GridOptions(Action<GridOptions> action);

        /// <summary>
        /// https://www.datatables.net/reference/option/  Chapter 'DataTables - Callbacks'
        /// </summary>
        /// <param name="action">配置委托</param>
        /// <returns>IGridApi</returns>
        IGridApi Callbacks(Action<GridCallbacksOptions> action);

        /// <summary>
        /// https://www.datatables.net/reference/option/  Chapter 'DataTables - Data'
        /// </summary>
        /// <param name="action">配置委托</param>
        /// <returns>IGridApi</returns>
        IGridApi Data(Action<GridDataOptions> action);

        /// <summary>
        /// https://www.datatables.net/reference/option/  Chapter 'DataTables - Features'
        /// </summary>
        /// <param name="action">配置委托</param>
        /// <returns>IGridApi</returns>
        IGridApi Features(Action<GridFeaturesOptions> action);

        /// <summary>
        /// 列配置(列配置于数据库中，也许你应该慎重调用此方法，它会覆盖其他读取方式！)
        /// </summary>
        /// <param name="columnBuilder">列配置</param>
        /// <returns>IGridApi</returns>
        IGridApi Columns(System.Action<GridColumnBuilder> columnBuilder);
    }
}
