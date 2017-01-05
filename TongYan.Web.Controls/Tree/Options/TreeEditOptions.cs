using System;
using System.Collections.Generic;

namespace TongYan.Web.Controls.Tree.Options
{
    public class TreeEditOptions : IOptionKey
    {
        public string OptionKey
        {
            get { return "data-tree-edit"; }
        }

        IDictionary<string, object> IOptionKey.ConvertToDic()
        {
            throw new NotImplementedException();
        }
    }
}