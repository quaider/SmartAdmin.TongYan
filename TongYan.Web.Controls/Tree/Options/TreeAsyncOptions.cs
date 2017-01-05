using System;
using System.Collections.Generic;

namespace TongYan.Web.Controls.Tree.Options
{
    public class TreeAsyncOptions : IOptionKey
    {
        public TreeAsyncOptions()
        {
            //设置默认值
            AutoParam = "[\"id\"]";
        }

        public string OptionKey
        {
            get { return "data-tree-async"; }
        }

        public string AutoParam { get; set; }

        public string ContentType { get; set; }

        public string DataFilter { get; set; }

        public string DataType { get; set; }

        public string OtherParam { get; set; }

        public string Type { get; set; }

        public string Url { get; set; }

        IDictionary<string, object> IOptionKey.ConvertToDic()
        {
            return new Dictionary<string, object>
            {
                {"autoParam", AutoParam},
                {
                    "nestedDic", new Dictionary<string, object>
                    {
                        {"a", 1},
                        {"b", "bb"},
                        {
                            "c", new Dictionary<string, object>
                            {
                                {"j1", 1},
                                {"j5", new[] {"a","b","c"}}
                            }
                        }
                    }
                }
            };
        }
    }
}