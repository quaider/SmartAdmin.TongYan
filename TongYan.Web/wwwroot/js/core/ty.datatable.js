(function ($) {

    /* Set the defaults for DataTables initialisation */
    $.extend(true, $.fn.dataTable.defaults, {
        dom:
            "<'row'<'col-sm-6'l><'col-sm-6 text-right'B>>" +
                "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-5 hidden-sm hidden-xs'i><'col-md-7 col-sm-12 col-xs-12'p>>",
        renderer: 'bootstrap',
        //多语言
        language: {
            "url": "/wwwroot/lib/jquery-datatable/js/i18n/datatable.lang.chinese.json"
        },
        //菜单长度
        lengthMenu: [10, 15, 20, 50],
        //给空默认值，防止报错
        buttons: []
    });

    $.fn.tyDataTable = function () {
        var $table = $(this),
            //tableId = $table.attr('id'),
            defaults = $.fn.tyDataTable.parseOptions(this);

        var dataApi = $table.DataTable(defaults);

        return dataApi;
    }

    /**
     * 解析 option
     */
    $.fn.tyDataTable.parseOptions = function (target) {
        var options = {},
            opt = {},
            t = $(target);

        var optKeys = ['data-grid-features', 'data-grid-option', 'data-grid-callbacks'];
        for (var i = 0; i < optKeys.length; i++) {
            if (t.attr(optKeys[i]) == "" || t.attr(optKeys[i]) == undefined) continue;
            opt = $.TongYan.parser.parseOptions(target, optKeys[i]);

            options = $.extend({}, options, opt);
        }

        if (t.attr('data-grid-data')) {
            opt = $.TongYan.parser.parseOptions(target, 'data-grid-data');
            var s = {
                ajax: function (data, callback, settings) {
                    var params = installParameters(data, callback, settings);
                    //ajax参数组装完成后的自定义操作
                    if (opt.ajaxParamsReady && typeof opt.ajaxParamsReady == "function") {
                        params = opt.ajaxParamsReady(data, callback, settings, params);
                    }

                    //自定义参数
                    //ajax请求数据
                    $.ajax({
                        type: opt.ajax.type,
                        url: opt.ajax.url,
                        cache: false,
                        data: params
                    }).done(function (result) {
                        //提供针对ajax数据返回后，对数据的特殊操作
                        if (opt.ajaxDataReady && typeof opt.ajaxDataReady == "function") {
                            result = opt.ajaxDataReady(result);
                        }

                        callback(result);
                    });
                }
            }

            options = $.extend({}, options, s);
        }

        options["columns"] = [];
        var domColumns;

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
            /*
             * 并非所有列都是数据列
            if (columnOpt && columnOpt.data && columnOpt.name) {
                options["columns"].push(columnOpt);
            }
            */
            if (columnOpt) {
                options["columns"].push(columnOpt);
            }
        });

        return options;
    }

    //组装基础查询参数, 如分页信息、排序信息等(限定为单列排序)
    function installParameters(data, callback, settings) {
        var p = {
            page: data.start,
            draw: data.draw,
            pageSize: data.length
        };

        if (data.order && data.order.length) {
            p.order = data.columns[data.order[0].column].data;
            p.orderDir = data.order[0].dir;
        }

        //form[data-form-search] query conditions
        //var form = $('form[data-search-for="' + settings.sTableId + '"]');
        var form = $('form[data-search-for]');
        form.find("[name][data-search-pattern]").each(function (idx, ele) {
            var pattern = $(ele).attr("data-search-pattern"),
                name = $(ele).attr("name"),
                searchName = "[" + pattern + "]" + name,
                val = $(ele).val();

            //todo checkbox & radio 需特殊处理

            if (val && val.replace(/\s+/g, '').length)
                p[searchName] = val;
        });

        return p;
    }

})(jQuery)

