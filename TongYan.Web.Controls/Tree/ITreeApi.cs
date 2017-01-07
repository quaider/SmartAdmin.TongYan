using System;
using TongYan.Web.Controls.Tree.Options;

namespace TongYan.Web.Controls.Tree
{
    /// <summary>
    /// 对外可调用Api
    /// </summary>
    public interface ITreeApi
    {
        /// <summary>
        /// 设置zTree 异步配置信息
        /// </summary>
        /// <param name="options">ztree async settins</param>
        /// <returns>ITreeApi</returns>
        ITreeApi Async(Action<TreeAsyncOptions> options);

        /// <summary>
        /// 设置zTree callback配置信息
        /// </summary>
        /// <param name="options">ztree callback settins</param>
        /// <returns>ITreeApi</returns>
        ITreeApi Callback(Action<TreeCallbackOptions> options);

        /// <summary>
        /// 设置zTree 勾选配置信息
        /// </summary>
        /// <param name="options">ztree check settins</param>
        /// <returns>ITreeApi</returns>
        ITreeApi Check(Action<TreeCheckOptions> options);

        /// <summary>
        /// 设置zTree 编辑配置信息
        /// </summary>
        /// <param name="options">ztree edit settins</param>
        /// <returns>ITreeApi</returns>
        ITreeApi Edit(Action<TreeEditOptions> options);

        /// <summary>
        /// 设置zTree 查看时配置信息
        /// </summary>
        /// <param name="options">ztree view settins</param>
        /// <returns>ITreeApi</returns>
        ITreeApi View(Action<TreeViewOptions> options);

        ITreeApi Data();

        /// <summary>
        /// 立即执行初始化脚本
        /// </summary>
        /// <returns>ITreeApi</returns>
        ITreeApi RunScriptForMe();
    }
}