using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TongYan.Web.Controls.Select.Options;
using TongYan.Web.Controls.Tree.Options;

namespace TongYan.Web.Controls.Select
{
    public class SelectControlRender<TEntity> : DefaultWebControlMultipleOptionsRender<TEntity>
    {
        protected override string BeginTag
        {
            get { return "<select{0}>"; }
        }

        protected override string EndTag
        {
            get { return "</select>"; }
        }

        protected SelectControlOptions<TEntity> SelectOptions
        {
            get { return Options as SelectControlOptions<TEntity>; }
        }

        protected override void RenderBody()
        {
            base.RenderBody();

            //基于建模复杂度考虑， 这里直接输出options
            RenderSelectOptions();
        }

        private void RenderSelectOptions()
        {
            var opt = SelectOptions.ItemOptions.SingleOrDefault(f => f.OptionKey == "data-options") as SelectOptions;
            if (opt == null) return;

            RenderWrapIndent();

            if (opt.Placeholder != null)
                Writer.WriteLine("<option></option>");

            if (opt.Data == null) return;

            foreach (var v in opt.Data)
            {
                var selectedStr = (v.selected.HasValue && v.selected.Value) ? " selected=\"selected\"" : "";
                Writer.WriteLine(string.Format("<option value=\"{0}\"{1}>{2}</option>", v.id, selectedStr, v.text));
            }
        }
    }
}