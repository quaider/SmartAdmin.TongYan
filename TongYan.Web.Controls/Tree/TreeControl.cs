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
            var asyncOpt = new TreeAsyncOptions();

            if (options != null)
                options(asyncOpt);

            TreeOptions.SetItemOptions(asyncOpt);

            return this;
        }

        ITreeApi ITreeApi.Callback(Action<TreeCallbackOptions> options)
        {
            throw new NotImplementedException();
        }

        ITreeApi ITreeApi.Check(Action<TreeCheckOptions> options)
        {
            throw new NotImplementedException();
        }

        ITreeApi ITreeApi.Data()
        {
            throw new NotImplementedException();
        }

        ITreeApi ITreeApi.Edit(Action<TreeEditOptions> options)
        {
            throw new NotImplementedException();
        }

        ITreeApi ITreeApi.View(Action<TreeViewOptions> options)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}