using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TongYan.Web.Controls.Extensions;
using TongYan.Web.Controls.Select.Options;

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
            //处理多选
            var opt = SelectOptions.ItemOptions.SingleOrDefault(f => f.OptionKey == "data-options") as SelectOptions;
            if (opt != null && opt.Multiple)
            {
                SelectOptions.Attributes.SetKeyValue("multiple", "multiple");
            }

            base.RenderBody();

            //基于建模复杂度考虑， 这里直接输出options
            RenderSelectOptions();
        }

        /// <summary>
        /// 输出选择项
        /// </summary>
        private void RenderSelectOptions()
        {
            var opt = SelectOptions.ItemOptions.SingleOrDefault(f => f.OptionKey == "data-options") as SelectOptions;
            if (opt == null) return;

            RenderWrapIndent();

            //在单选时，要使placeholder生效，select2需要一个空的option
            if (opt.Placeholder != null && !opt.Multiple)
                Writer.WriteLine("<option></option>");

            if (opt.Data == null) return;

            var values = GetValues();
            foreach (var v in opt.Data)
            {
                var selectedStr = (v.selected.HasValue && v.selected.Value) || values.Contains(v.id)
                    ? " selected=\"selected\""
                    : "";

                Writer.WriteLine("<option value=\"{0}\"{1}>{2}</option>", v.id, selectedStr, v.text);
            }
        }

        /// <summary>
        /// 获取需要选中项的值的字符串形式
        /// </summary>
        /// <returns>选中项列表</returns>
        private List<string> GetValues()
        {
            var values = new List<string>();
            if (SelectOptions.SelectedValues == null) return values;

            var arr = SelectOptions.SelectedValues as IEnumerable<object>;
            if (arr != null)
            {
                values.AddRange(arr.Select(v => v.ToString()));
            }
            else
            {
                //尝试解析字符串中的多个值序列
                var vArr = SelectOptions.SelectedValues.ToString().Split(',');
                values.AddRange(vArr.Select(v => v.Trim()));
            }

            return values;
        }
    }
}