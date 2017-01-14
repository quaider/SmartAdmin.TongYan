using System;
using System.IO;
using System.Reflection;
using TongYan.Web.Controls.DataGrid.Options;
using TongYan.Web.Controls.DataGrid.Providers;

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

        /// <summary>
        /// <see cref="IGridApi.GridOptions(Action{Options.GridOptions})"/>
        /// </summary>
        IGridApi IGridApi.GridOptions(Action<GridOptions> action)
        {
            return SetOptions(action);
        }

        /// <summary>
        /// <see cref="IGridApi.Callbacks(Action{GridCallbacksOptions})"/>
        /// </summary>
        IGridApi IGridApi.Callbacks(Action<GridCallbacksOptions> action)
        {
            return SetOptions(action);
        }

        /// <summary>
        /// <see cref="IGridApi.Data(Action{GridDataOptions})"/>
        /// </summary>
        IGridApi IGridApi.Data(Action<GridDataOptions> action)
        {
            return SetOptions(action);
        }

        /// <summary>
        /// <see cref="IGridApi.Features(Action{GridFeaturesOptions})"/>
        /// </summary>
        IGridApi IGridApi.Features(Action<GridFeaturesOptions> action)
        {
            return SetOptions(action);
        }

        IGridApi SetOptions<T>(Action<T> action) where T : class, IOptionKey//, new()
        {
            //为了不暴露过多信息， 各配置构造函数设置为internal，因此此处无法使用new()约束，故使用Activator.CreateInstance
            var opt = Activator.CreateInstance(typeof(T), BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { }, null) as T;
            if (action != null)
                action(opt);

            GridCtrlOptions.SetItemOptions(opt);

            return this;
        }

        /// <summary>
        /// <see cref=IGridApi.Columns(Action{IGridColumnBuilderApi})"/>
        /// </summary>
        IGridApi IGridApi.Columns(Action<IGridColumnBuilderApi> columnBuilder)
        {
            var builder = new GridColumnsBuilder();
            columnBuilder(builder);

            GridCtrlOptions.ColumnBuilders.Add(builder);

            return this;
        }

        protected GridColumnsProvider Provider { get; private set; }

        /// <summary>
        /// <see cref=IGridApi.ColumnsProvider(GridColumnsProvider)"/>
        /// </summary>
        IGridApi IGridApi.ColumnsProvider(GridColumnsProvider provider)
        {
            /*
            Provider = provider;
            foreach (var column in provider.Builder)
            {
                GridCtrlOptions.ColumnBuilder.Add(column);
            }
            */

            return this;
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        private void InitDefault()
        {
            AddClass("table table-hover table-bordered table-striped");
        }
    }
}
