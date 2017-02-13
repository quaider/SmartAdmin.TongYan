namespace TongYan.Web.Controls.Select
{
    /// <summary>
    /// select2所需的数据项模型
    /// </summary>
    public class SelectModel
    {
        /// <summary>
        /// 选择项的value
        /// </summary>
        public string id { get; set; }
        
        /// <summary>
        /// 选择项的文本
        /// </summary>
        public string text { get; set; }
        
        /// <summary>
        /// 是否选中选择项
        /// </summary>
        public bool? selected { get; set; } 
    }
}