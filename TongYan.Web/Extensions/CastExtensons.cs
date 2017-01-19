using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using TongYan.Web.Models;

namespace TongYan.Web.Extensions
{
    public static class CastExtensons
    {
        //查询条件类不允许类的嵌套
        public static T CastToQueryModel<T>(this GridQuery query, T target = null) where T : class, new()
        {
            target = target ?? new T();

            if (query == null || query.Columns == null || !query.Columns.Any()) return target;

            var typeOfEntity = target.GetType();
            //todo: 建立反射的统一缓存机制！
            var properties = typeOfEntity.GetProperties();

            foreach (var column in query.Columns)
            {
                var property = properties.SingleOrDefault(f => f.Name.Equals(column.Name, StringComparison.OrdinalIgnoreCase));
                if (property == null || string.IsNullOrWhiteSpace(column.Search.Value)) continue;

                try
                {
                    property.SetValue(target, column.Search.Value);
                }
                catch (Exception ex)
                {
                    throw new InvalidCastException(
                        string.Format("属性 `{0}` 无法从类型 `{1}` 转换为 类型 `{2}`！",
                            column.Name, column.Search.Value.GetType(), property.PropertyType), ex);
                }
            }

            return target;
        }
    }
}