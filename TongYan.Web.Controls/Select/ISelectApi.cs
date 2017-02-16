using System;
using TongYan.Web.Controls.Select.Options;

namespace TongYan.Web.Controls.Select
{
    public interface ISelectApi
    {
        ISelectApi SetOptions(Action<SelectOptions> options);

        /// <summary>
        /// 设置联动(单个时也可设置下拉项的来源)
        /// </summary>
        /// <param name="options">联动配置</param>
        /// <returns>ISelectApi</returns>
        ISelectApi Linkage(Action<SelectLinkageOptions> options);
    }
}