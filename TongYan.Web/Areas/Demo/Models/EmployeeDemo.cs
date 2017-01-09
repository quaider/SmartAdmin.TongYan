namespace TongYan.Web.Areas.Demo.Models
{
    public class EmployeeDemo
    {
        public EmployeeDemo(string uName, string name, string dname, string tel, string gender, string suffix = "")
        {
            suffix = string.IsNullOrEmpty(suffix) ? "" : suffix;

            UserName = uName + suffix;
            FullName = name + suffix;
            DptName = dname;
            Tel = tel;
            Gender = gender;
        }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string DptName { get; set; }

        public string Gender { get; set; }

        public string Tel { get; set; }
    }
}