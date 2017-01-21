using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TongYan.Web.Extensions
{
    public static class TempExtensions
    {
        /// <summary>
        /// 获取可空类型的实际类型
        /// </summary>
        /// <param name="conversionType"></param>
        /// <returns></returns>
        public static Type GetUnNullableType(this Type conversionType)
        {
            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                //如果是泛型方法，且泛型类型为Nullable<>则视为可空类型
                //并使用NullableConverter转换器进行转换
                var nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }
            return conversionType;
        }
    }
}