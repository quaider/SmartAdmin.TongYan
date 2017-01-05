using System;
using System.Collections.Generic;

namespace TongYan.Web.Controls.Tree.Options
{
    public class TreeCallbackOptions : IOptionKey
    {
        public string OptionKey
        {
            get { return "data-tree-callback"; }
        }

        IDictionary<string, object> IOptionKey.ConvertToDic()
        {
            throw new NotImplementedException();
        }
    }
}