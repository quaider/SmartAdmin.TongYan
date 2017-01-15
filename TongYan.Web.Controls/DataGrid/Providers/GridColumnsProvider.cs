using System;
using System.Collections.Generic;

namespace TongYan.Web.Controls.DataGrid.Providers
{
    /// <summary>
    /// 数据库列提供器
    /// </summary>
    public abstract class GridColumnsProvider
    {
        public IList<GridColumnsBuilder> Builders { get; }

        protected GridColumnsProvider()
        {
            Builders = new List<GridColumnsBuilder>();
        }

        /// <summary>
        /// 组装列
        /// </summary>
        /// <param name="group">列组键值</param>
        public void BuildColumns(string group)
        {
            InitColumns(group);
        }

        /// <summary>
        /// 获取列，请按顺序指定(实现类需填充好各列的具体属性)
        /// </summary>
        protected abstract IList<IList<IGridColumn>> GetGridColumns(string group);

        protected virtual void InitColumns(string group)
        {
            foreach (var builderColumns in GetGridColumns(group))
            {
                var builder = new GridColumnsBuilder();
                foreach (var c in builderColumns)
                {
                    builder.Add(c as GridColumn);
                }

                Builders.Add(builder);
            }
        }
    }
}
