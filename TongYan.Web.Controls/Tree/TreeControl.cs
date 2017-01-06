using System;
using System.IO;
using TongYan.Web.Controls.Tree.Options;

namespace TongYan.Web.Controls.Tree
{
    /// <summary>
    /// 树控件最外层包装
    /// </summary>
    public class TreeControl : WebControlBase<object>, ITreeApi
    {
        public TreeControl(string id) : base(new TreeControlOptions())
        {
            Options.Id = id;

            SetDefault();
        }

        protected TreeControlOptions TreeOptions
        {
            get { return Options as TreeControlOptions; }
        }

        public override string ToHtmlString()
        {
            var writer = new StringWriter();
            TreeOptions.Render.Render(TreeOptions, writer, null);
            return writer.ToString();
        }

        #region ITreeApi 对外操作

        ITreeApi ITreeApi.Async(Action<TreeAsyncOptions> options)
        {
            var opts = new TreeAsyncOptions();

            if (options != null)
                options(opts);

            TreeOptions.SetItemOptions(opts);

            return this;
        }

        ITreeApi ITreeApi.Callback(Action<TreeCallbackOptions> options)
        {
            var opts = new TreeCallbackOptions();

            if (options != null)
                options(opts);

            TreeOptions.SetItemOptions(opts);

            return this;
        }

        ITreeApi ITreeApi.Check(Action<TreeCheckOptions> options)
        {
            var opts = new TreeCheckOptions();

            if (options != null)
                options(opts);

            TreeOptions.SetItemOptions(opts);

            return this;
        }

        ITreeApi ITreeApi.Data()
        {
            return this;
        }

        ITreeApi ITreeApi.Edit(Action<TreeEditOptions> options)
        {
            var opts = new TreeEditOptions();

            if (options != null)
                options(opts);

            TreeOptions.SetItemOptions(opts);

            return this;
        }

        ITreeApi ITreeApi.View(Action<TreeViewOptions> options)
        {
            var opts = new TreeViewOptions();

            if (options != null)
                options(opts);

            TreeOptions.SetItemOptions(opts);

            return this;
        }

        #endregion

        void SetDefault()
        {
            AddClass("ztree");
        }
    }
}