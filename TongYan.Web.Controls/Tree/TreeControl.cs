using System;
using System.IO;
using System.Reflection;
using System.Web.Mvc;
using TongYan.Web.Controls.Tree.Options;

namespace TongYan.Web.Controls.Tree
{
    /// <summary>
    /// 树控件最外层包装
    /// </summary>
    public class TreeControl : WebControlBase<object>, ITreeApi
    {
        private readonly ViewContext _context;

        public TreeControl(string id, ViewContext context) : base(new TreeControlOptions())
        {
            Options.Id = id;
            _context = context;

            SetDefault();
        }

        protected TreeControlOptions TreeOptions
        {
            get { return Options as TreeControlOptions; }
        }

        public override string ToHtmlString()
        {
            var writer = new StringWriter();
            TreeOptions.Render.Render(TreeOptions, writer, _context);
            return writer.ToString();
        }

        #region ITreeApi 对外操作

        ITreeApi ITreeApi.Async(Action<TreeAsyncOptions> options)
        {
            return SetOptions(options);
        }

        ITreeApi ITreeApi.Callback(Action<TreeCallbackOptions> options)
        {
            return SetOptions(options);
        }

        ITreeApi ITreeApi.Check(Action<TreeCheckOptions> options)
        {
            return SetOptions(options);
        }

        ITreeApi ITreeApi.Data()
        {
            return this;
        }

        ITreeApi ITreeApi.Edit(Action<TreeEditOptions> options)
        {
            return SetOptions(options);
        }

        ITreeApi ITreeApi.View(Action<TreeViewOptions> options)
        {
            return SetOptions(options);
        }

        ITreeApi ITreeApi.RunScriptForMe()
        {
            TreeOptions.EnableClientScript();

            return this;
        }

        ITreeApi SetOptions<T>(Action<T> action) where T : class, IOptionKey
        {
            //为了不暴露过多信息， 各配置构造函数设置为internal，因此此处无法使用new()约束，故使用Activator.CreateInstance
            //尽管会带来略微的性能损失， 但是性能瓶颈绝不在此！
            var opt = Activator.CreateInstance(typeof(T), BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { }, null) as T;
            if (action != null)
                action(opt);

            TreeOptions.SetItemOptions(opt);

            return this;
        }

        #endregion

        void SetDefault()
        {
            AddClass("ztree");
        }
    }
}