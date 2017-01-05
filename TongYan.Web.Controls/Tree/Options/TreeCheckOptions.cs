using System;
using System.Collections.Generic;

namespace TongYan.Web.Controls.Tree.Options
{
    public class TreeCheckOptions : IOptionKey
    {
        public string OptionKey
        {
            get { return "data-tree-check"; }
        }

        IDictionary<string, object> IOptionKey.ConvertToDic()
        {
            throw new NotImplementedException();
        }
    }
}