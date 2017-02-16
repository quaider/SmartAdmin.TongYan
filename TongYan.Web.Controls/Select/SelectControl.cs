using System;
using System.IO;
using System.Web.Mvc;
using TongYan.Web.Controls.Extensions;
using TongYan.Web.Controls.Select.Options;

namespace TongYan.Web.Controls.Select
{
    public class SelectControl<TEntity> : WebControlBase<TEntity>, ISelectApi
    {
        private readonly HtmlHelper<TEntity> _helper;

        public SelectControl(string name, object value, HtmlHelper<TEntity> helper) : base(new SelectControlOptions<TEntity>())
        {
            SelectCtrlOptions.Attributes.SetKeyValue("name", name);

            var id = TagBuilder.CreateSanitizedId(name);
            SelectCtrlOptions.Attributes.SetKeyValue("id", id);

            _helper = helper;
            SelectCtrlOptions.SelectedValues = value;
        }

        protected SelectControlOptions<TEntity> SelectCtrlOptions
        {
            get { return Options as SelectControlOptions<TEntity>; }
        }

        public override string ToHtmlString()
        {
            var writer = new StringWriter();
            SelectCtrlOptions.Render.Render(SelectCtrlOptions, writer, _helper.ViewContext);
            return writer.ToString();
        }

        ISelectApi ISelectApi.SetOptions(Action<SelectOptions> action)
        {
            var opt = new SelectOptions();
            if (action != null)
            {
                action(opt);
            }

            SelectCtrlOptions.SetItemOptions(opt);
            return this;
        }

        public ISelectApi Linkage(Action<SelectLinkageOptions> options)
        {
            var opt = new SelectLinkageOptions();
            if (options != null)
            {
                options(opt);
            }

            SelectCtrlOptions.SetItemOptions(opt);
            return this;
        }
    }
}