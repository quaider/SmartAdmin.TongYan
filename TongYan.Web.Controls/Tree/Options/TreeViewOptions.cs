using System;
using System.Collections.Generic;

namespace TongYan.Web.Controls.Tree.Options
{
    public class TreeViewOptions : IOptionKey
    {
        public string OptionKey
        {
            get { return "data-tree-view"; }
        }

        IDictionary<string, object> IOptionKey.ConvertToDic()
        {
            throw new NotImplementedException();
        }
    }
}