using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace TongYan.Web.SmartSearch
{
    /// <summary>
    /// 对IQueryable的扩展方法
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// 使IQueryable支持QueryModel
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="table">IQueryable的查询对象</param>
        /// <param name="model">QueryModel对象</param>
        /// <param name="prefix">使用前缀区分查询条件</param>
        /// <returns></returns>
        public static IQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> table, SearchModel model, string prefix) where TEntity : class
        {
            Contract.Requires(table != null);
            if (table == null)
                throw new ArgumentNullException("table");
            if (model == null)
                throw new ArgumentNullException("model");
            return Where(table, model.Items, prefix);
        }

        public static IQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> table, SearchModel model) where TEntity : class
        {
            Contract.Requires(table != null);
            if (table == null)
                throw new ArgumentNullException("table");
            if (model == null)
                throw new ArgumentNullException("model");
            return Where(table, model.Items, string.Empty);
        }

        private static IQueryable<TEntity> Where<TEntity>(IQueryable<TEntity> table, IEnumerable<ConditionItem> items, string prefix = "")
        {
            Contract.Requires(table != null);
            if (table == null)
                throw new ArgumentNullException("table");
            ICollection<ConditionItem> filterItems =
                (string.IsNullOrWhiteSpace(prefix)
                    ? items.Where(c => string.IsNullOrEmpty(c.Prefix))
                    : items.Where(c => c.Prefix == prefix)).ToList();
            if (!filterItems.Any()) return table;
            return new QueryableSearcher<TEntity>(table, filterItems).Search();
        }


        #region 分页扩展

        /*
        public static PagedList<TEntity> SmartPager<TEntity>(this IQueryable<TEntity> table, SearchModel model,
                                                              PageComponent pager = null) where TEntity : class
        {
            if (model == null)
                return table.ToPagedList(pager);

            return table.Where(model).ToPagedList(pager);
        }

        /// <summary>
        /// 不带分页，一次性获取全部数据 导出用
        /// </summary>
        public static IList<TEntity> SmartList<TEntity>(this IQueryable<TEntity> table, SearchModel model,
                                                              PageComponent pager = null) where TEntity : class
        {
            pager = pager ?? new PageComponent { Direction = SortingDirection.Up, Page = 0, SortField = "Id" };
            var sortExpression = "{0} {1}".With(pager.SortField ?? "Id", pager.Direction == SortingDirection.Up ? "ASC" : "DESC");

            if (model == null)
                return table.OrderUsingSortExpression(sortExpression).ToList();

            return table.Where(model).OrderUsingSortExpression(sortExpression).ToList();
        }
        */
        #endregion
    }
}