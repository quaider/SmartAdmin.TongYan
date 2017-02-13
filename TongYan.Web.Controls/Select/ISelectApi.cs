using System;
using TongYan.Web.Controls.Select.Options;

namespace TongYan.Web.Controls.Select
{
    public interface ISelectApi
    {
        ISelectApi SetOptions(Action<SelectOptions> action);
    }
}