using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TongYan.Web.Controls.DataGrid;
using TongYan.Web.Controls.Select;
using TongYan.Web.Controls.Tree;

namespace TongYan.Web.Controls
{
    public class WebControlWrapper<TEntity> : IWebControlWrapper<TEntity>
    {
        private readonly HtmlHelper<TEntity> _helper;

        public WebControlWrapper(HtmlHelper<TEntity> helper)
        {
            _helper = helper;
        }

        public ITreeApi Tree(string id)
        {
            return new TreeControl(id, _helper.ViewContext);
        }

        public IGridApi Grid(string id)
        {
            return new GridControl(id, _helper.ViewContext);
        }

        public ISelectApi Select<TProperty>(Expression<Func<TEntity, TProperty>> expression)
        {
            var name = _helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression));
            

            var select = new SelectControl<TEntity>(name, _helper);
            return select;
        }

        public ISelectApi Select(string name)
        {
            var select = new SelectControl<TEntity>(name, _helper);
            return select;
        }
    }
}
