(function ($) {

    /**
     * 配置解析
     */
    $.TongYan.parser = {

        /**
         * 参考easyui源代码: jquery.parse.js
         * parse options, including standard 'data-options' attribute.
         * @param {object | string} target jquery object or selector
         * @param {string} optionAttr  配置的Html属性名
         * 
         * calling examples:
         * $.TongYan.parser.parseOptions(target);
         * $.TongYan.parser.parseOptions(target, 'data-tree-async');
         */
        parseOptions: function (target, optionAttr) {
            var t = $(target);
            var options = {};

            var s = $.trim(t.attr(optionAttr || 'data-options'));
            if (s) {
                if (s.substring(0, 1) != '{') {
                    s = '{' + s + '}';
                }
                options = (new Function('return ' + s))();
            }

            //递归嵌套检查并设置js对象或js函数
            checkAndSetJsString(options);

            return options;
        }
    }

    /* 
    * 递归嵌套检查并设置js对象或js函数
    * obj 需要遍历的对象 
    */
    function checkAndSetJsString(obj) {

        if (typeof (obj) == "string") {
            return parseJsString(obj);
        }

        for (var p in obj) {
            // 方法 
            if (typeof (obj[p]) == "object") {
                if (obj[p] instanceof Array) {
                    var a = new Array();
                    for (var i = 0; i < obj[p].length; i++) {
                        a[i] = checkAndSetJsString(obj[p][i]);
                    }
                    obj[p] = a;
                }
                else {
                    checkAndSetJsString(obj[p]);
                }
            }
            else if (typeof (obj[p]) == "string") {
                if (!obj[p]) continue;

                obj[p] = parseJsString(obj[p]);
            }
        }
    }

    function parseJsString(source) {
        if (!source || typeof source != "string") return source;

        if (/^fn:/.test(source)) {
            //函数申明
            return new Function('return ' + source.substring(3) + '.apply(this, arguments)');
        }
        if (/^fr:/.test(source)) {
            //函数执行
            return new Function('return ' + source.substring(3) + '.apply(this, arguments)')();
        }
        else if (/^jo:/.test(source)) {
            //js对象
            return new Function('return ' + source.substring(3))();
        }

        return source;
    }

})(jQuery)