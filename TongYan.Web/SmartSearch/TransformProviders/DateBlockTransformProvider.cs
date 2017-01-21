using System;
using System.Collections.Generic;

namespace TongYan.Web.SmartSearch.TransformProviders
{
    /// <summary>
    /// 时间范围适配器
    /// </summary>
    internal class DateBlockTransformProvider : ITransformProvider
    {
        public bool Match(ConditionItem item, Type type)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            return item.Method == QueryMethod.DateBlock;
        }

        public IEnumerable<ConditionItem> Transform(ConditionItem item, Type type)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            return new[]
                       {
                           new ConditionItem(item.Field, QueryMethod.GreaterThanOrEqual, item.Value),
                           new ConditionItem(item.Field, QueryMethod.LessThan, item.Value)
                       };
        }
    }
}