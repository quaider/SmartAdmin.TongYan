using System.Collections.Generic;

namespace TongYan.Web.Controls.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// 设置字典键值(有key则更新，无则添加)
        /// </summary>
        /// <param name="source">待设定的字典</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns>新的字典</returns>
        public static IDictionary<TKey, TValue> SetKeyValue<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue value)
        {
            source = source ?? new Dictionary<TKey, TValue>();
            if (source.ContainsKey(key))
                source[key] = value;
            else
                source.Add(key, value);

            return source;
        }
    }
}