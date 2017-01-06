(function ($) {

    /**
     * 配置解析
     */
    $.TongYan.parser = {

        /**
         * 参考easyui代码: jquery.parse.js
         * parse options, including standard 'data-options' attribute.
         * @param {object | string} target jquery object or selector
         * @param {string} optionAttr  配置的Html属性名
         * 
         * calling examples:
         * $.parser.parseOptions(target);
         * $.parser.parseOptions(target, ['id','title','width',{fit:'boolean',border:'boolean'},{min:'number'}]);
         */
        parseOptions: function (target, optionAttr, properties) {
            var t = $(target);
            var options = {};

            var s = $.trim(t.attr(optionAttr || 'data-options'));
            if (s) {
                if (s.substring(0, 1) != '{') {
                    s = '{' + s + '}';
                }
                options = (new Function('return ' + s))();
            }

            allPrpos(options);

            console.log(options);

            return options;
        }
    }

    /* 
    * 用来遍历指定对象所有的属性名称和值 
    * obj 需要遍历的对象 
    * author: Jet Mah 
    */
    function allPrpos(obj) {
        for (var p in obj) {
            // 方法 
            if (typeof (obj[p]) == "object") {
                allPrpos(obj[p]);
            }
            else if (typeof (obj[p]) == "string") {
                if (!obj[p]) continue;
                if (/^js:/.test(obj[p])) {
                    obj[p] = new Function('return ' + obj[p].substring(3));
                }
            }
        }
    }

})(jQuery)