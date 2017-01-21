using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TongYan.Web.Models
{
    public class EmployeeQueryModel: GridQuery
    {
        public string UserName { get; set; }

        public string DptName { get; set; }

        public string FullName { get; set; }
    }
}