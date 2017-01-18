using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using TongYan.Web.Controls.DataGrid.Options;
using TongYan.Web.Controls.DataGrid.Providers;

namespace TongYan.Web.Controls.DataGrid
{
    /// <summary>
    /// Grid最外层包装
    /// </summary>
    public class GridControl : WebControlBase<object>, IGridApi
    {
        private readonly ViewContext _context;

        public GridControl(string id, ViewContext contex) : base(new GridControlOptions())
        {
            Options.Id = id;
            _context = contex;
            InitDefault();
        }

        protected GridControlOptions GridCtrlOptions
        {
            get { return Options as GridControlOptions; }
        }

        public override string ToHtmlString()
        {
            var writer = new StringWriter();
            GridCtrlOptions.Render.Render(GridCtrlOptions, writer, _context);
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
            if (Provider != null) throw new InvalidOperationException("已通过其他途径初始化列，请不要指定多个列初始化方式！");

            var builder = new GridColumnsBuilder();
            columnBuilder(builder);

            GridCtrlOptions.ColumnBuilders.Add(builder);

            return this;
        }

        protected GridColumnsProvider Provider { get; private set; }

        /// <summary>
        /// <see cref=IGridApi.ColumnsProvider(GridColumnsProvider)"/>
        /// </summary>
        IGridApi IGridApi.ColumnsProvider(GridColumnsProvider provider, string group)
        {
            if (GridCtrlOptions.ColumnBuilders.Any()) throw new InvalidOperationException("已通过其他途径初始化列，请不要指定多个列初始化方式！");

            Provider = provider;
            Provider.BuildColumns(group);

            foreach (var builder in provider.Builders)
            {
                GridCtrlOptions.ColumnBuilders.Add(builder);
            }

            return this;
        }

        IGridApi IGridApi.Highlight()
        {
            AddClass("table-sort-bg");
            return this;
        }

        IGridApi IGridApi.ClassName(string cls)
        {
            AddClass(cls);
            return this;
        }

        IGridApi IGridApi.Bordered()
        {
            AddClass("table-bordered");
            return this;
        }

        IGridApi IGridApi.Condensed()
        {
            AddClass("table-condensed");
            return this;
        }

        IGridApi IGridApi.RunScriptForMe()
        {
            GridCtrlOptions.EnableClientScript();
            return this;
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        private void InitDefault()
        {
            AddClass("table table-hover table-striped");
        } 
    }
}
