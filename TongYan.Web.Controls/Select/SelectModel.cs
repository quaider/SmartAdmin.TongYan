namespace TongYan.Web.Controls.Select
{
    /// <summary>
    /// select2所需的数据项模型
    /// </summary>
    public class SelectModel
    {
        public SelectModel(string id, string text, bool? selected = null)
        {
            this.id = id;
            this.text = text == null ? null : text.Trim();
            if (selected.HasValue)
                this.selected = selected;
        }
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