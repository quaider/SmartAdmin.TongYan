using System.Collections.Generic;
using TongYan.Web.Controls.Tree;

namespace TongYan.Web.Controls.Select.Options
{
    public class SelectControlOptions<TEntity> : DefaultWebControlMultipleOptions<TEntity>
    {
        public SelectControlOptions()
        {
            ItemOptions = new List<IOptionKey>();
            Render = new SelectControlRender<TEntity>();
        }
    }
}