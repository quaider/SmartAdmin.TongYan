using System.Collections.Generic;
using TongYan.Web.Controls.Extensions;

namespace TongYan.Web.Controls
{
    /// <summary>
    /// 默认配置
    /// </summary>
    public class DefaultWebControlOptions<T> : IWebControlOptions<T>
    {
        readonly string OptionsKey = "data-options";

        public DefaultWebControlOptions()
        {
            Attributes = new Dictionary<string, object>();
            Render = new DefaultWebControlRender<T>();
        }

        public DefaultWebControlOptions(string optionsKey)
            : this()
        {
            OptionsKey = optionsKey;
        }

        public string Id
        {
            get { return Attributes["id"] == null ? null : Attributes["id"].ToString(); }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    Attributes.SetKeyValue("id", value.Trim());
            }
        }

        public IDictionary<string, object> Attributes { get; set; }

        public virtual IDictionary<string, object> Options
        {
            get
            {
                if (!Attributes.Keys.Contains(OptionsKey))
                    Attributes.SetKeyValue(OptionsKey, new Dictionary<string, object>());

                return Attributes[OptionsKey] as IDictionary<string, object>;
            }
        }

        public IWebControlRender<T> Render { get; set; }
    }
}