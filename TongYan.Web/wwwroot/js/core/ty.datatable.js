(function ($) {

    /* Set the defaults for DataTables initialisation */
    $.extend(true, $.fn.dataTable.defaults, {
        dom:
            "<'row'<'col-sm-6'l><'col-sm-6 text-right'f>>" +
                "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        renderer: 'bootstrap',
        language: {
            "url": "/wwwroot/lib/jquery-datatable/js/i18n/datatable.lang.chinese.json"
        },
        //给空默认值，防止报错
        buttons: []
    });

    $.fn.tyDataTable = function () {
        var opt = $.fn.tyDataTable.parseOptions(this);
        return $(this).DataTable(opt);
    }

    $.fn.tyDataTable.parseOptions = function (target) {
        var options = {},
            opt = {},
            t = $(target);

        if (t.attr('data-grid-features')) {
            opt = $.TongYan.parser.parseOptions(target, 'data-grid-features');
            options = $.extend({}, options, opt)
        }

        if (t.attr('data-grid-option')) {
            opt = $.TongYan.parser.parseOptions(target, 'data-grid-option');
            options = $.extend({}, options, opt)
        }

        if (t.attr('data-grid-data')) {
            opt = $.TongYan.parser.parseOptions(target, 'data-grid-data');
            options = $.extend({}, options, opt)
        }

        options["columns"] = [];
        var domColumns = [];

        //多行复杂表头，必须按照解析顺序进行解析
        if (t.find("thead tr").length > 1) {
            domColumns = t.find("thead th[data-grid-column][data-grid-columnOrder]").sort(function (a, b) {
                return $(a).attr("data-grid-columnOrder") - $(b).attr("data-grid-columnOrder");
            });
        }
        else {
            domColumns = t.find("thead th[data-grid-column]");
        }

        //parse columns
        domColumns.each(function (i, tr) {
            var columnOpt = $.TongYan.parser.parseOptions($(tr), 'data-grid-column');
            if (columnOpt && columnOpt.data && columnOpt.name) {
                options["columns"].push(columnOpt)
            }

        });

        return options;
    }

})(jQuery)