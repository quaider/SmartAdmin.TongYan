using System.Collections.Generic;

namespace TongYan.Web.Controls
{
    public interface IOptionKey
    {
        string OptionKey { get; }

        IDictionary<string, object> ConvertToDic();
    }
}