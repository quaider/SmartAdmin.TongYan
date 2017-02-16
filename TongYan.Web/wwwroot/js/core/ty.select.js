(function ($) {

    $.fn.tySelect = function () {
        var opt = $.fn.tySelect.parseOptions(this);
        if (opt.length < 2) {
            $(this).select2(opt);
        } else {
            //联动控制
            linkage($(this), opt);
        }
    }

    $.fn.tySelect.parseOptions = function (target) {
        var options = [],
            t = $(target);

        options.push($.TongYan.parser.parseOptions(target, 'data-options'));
        if (t.attr('data-select-linkage')) {
            options.push($.TongYan.parser.parseOptions(target, 'data-select-linkage'));
        }

        return options;
    }

    function linkage(target, opt) {
        target.select2(opt[0]);

        //ajax提取下拉项
        if (opt[1].url && opt[1].url.length && (!opt[1].parent || opt[1].parent.length < 1)) {
            $.ajax({
                url: opt[1].url,
                type: 'post'
            }).done(function (data) {
                setOptionItems(target, data);
            });
        }
    }

    function setOptionItems(target, data) {

        target.find('option').filter(function (idx, ele) {
            return ($(ele).val() && $(ele).val() != "");
        }).remove();

        $.each(data, function (i, item) {
            var optEle = $('<option value="' + item.id + '">' + item.text + '</option>');
            if (item.selected === true) {
                optEle.attr("selected", "selected");
            }
            optEle.appendTo(target);
        });
    }

})(jQuery)