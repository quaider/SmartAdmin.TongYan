using System;
using System.Collections.Generic;

namespace TongYan.Web.SmartSearch
{
    public interface ITransformProvider
    {
        bool Match(ConditionItem item, Type type);
        IEnumerable<ConditionItem> Transform(ConditionItem item, Type type); 
    }
}