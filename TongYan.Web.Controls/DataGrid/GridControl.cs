using System;
using System.IO;
using System.Reflection;
using TongYan.Web.Controls.DataGrid.Options;

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
        //IGridApi IGridApi.GridOptions(Action<GridOptions> action)
        //{
        //return SetOptions(action);
        //}

        public IGridApi GridOptions(Action<GridOptions> action)
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
            //尽管会带来略微的性能损失， 但是性能瓶颈绝不在此！
            var opt = Activator.CreateInstance(typeof(T), BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { }, null) as T;
            if (action != null)
                action(opt);

            GridCtrlOptions.SetItemOptions(opt);

            return this;
        }

        /// <summary>
        /// api隐藏设计
        /// </summary>
        /// <param name="columnBuilder"></param>
        /// <returns></returns>
        IGridApi IGridApi.Columns(Action<GridColumnBuilder> columnBuilder)
        {
            var builder = new GridColumnBuilder();
            columnBuilder(builder);

            foreach (var column in builder)
            {
                GridCtrlOptions.Columns.Add(column);
            }

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
