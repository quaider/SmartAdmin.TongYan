(function ($) {

    $.fn.tyTree = function () {
        var opt = $.fn.tyTree.parseOptions(this);
        $.fn.zTree.init($(this), opt);
        return this;
    }

    $.fn.tyTree.parseOptions = function (target) {
        var options = {},
            t = $(target);

        if (t.attr('data-tree-edit')) {
            options["edit"] = $.TongYan.parser.parseOptions(target, 'data-tree-edit');
        }

        if (t.attr('data-tree-view')) {
            options["view"] = $.TongYan.parser.parseOptions(target, 'data-tree-view');
        }

        if (t.attr('data-tree-async')) {
            options["async"] = $.TongYan.parser.parseOptions(target, 'data-tree-async');
        }

        if (t.attr('data-tree-callback')) {
            options["callback"] = $.TongYan.parser.parseOptions(target, 'data-tree-callback');
        }

        if (t.attr('data-tree-check')) {
            options["check"] = $.TongYan.parser.parseOptions(target, 'data-tree-check');
        }

        return options;
    }

})(jQuery)