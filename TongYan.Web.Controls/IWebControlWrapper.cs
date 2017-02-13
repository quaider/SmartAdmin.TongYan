using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TongYan.Web.Controls.DataGrid;
using TongYan.Web.Controls.Select;
using TongYan.Web.Controls.Tree;

namespace TongYan.Web.Controls
{
    public interface IWebControlWrapper<TEntity>
    {
        /// <summary>
        /// 生成Tree
        /// </summary>
        /// <param name="id">Tree id</param>
        /// <returns>ITreeApi</returns>
        ITreeApi Tree(string id);

        /// <summary>
        /// 生成datatable
        /// </summary>
        /// <param name="id">table id</param>
        /// <returns>IGridApi</returns>
        IGridApi Grid(string id);

        ISelectApi Select<TProperty>(Expression<Func<TEntity, TProperty>> expression);
    }
}
