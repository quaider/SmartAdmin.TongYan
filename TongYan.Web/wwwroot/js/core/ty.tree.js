TyApp.Tree = {

    /**
     * 返回zTree异步树的配置
     * @param {object} options 需自定义的zTree异步树的配置 
     * @returns {object} 最终zTree异步树的配置 
     */
    enableAsync: function (options) {
        var defaults = {
            enable: true,
            autoParam: ["id=pId"],
            dataType: "json",
            type: "post"
        };

        return options ? defaults : $.extend(defaults, options);
    },

    /**
     * 返回zTree callback配置
     * @param {object} options callback配置
     * @returns {object} 最终callback配置
     */
    callback: function (options) {

    }
}