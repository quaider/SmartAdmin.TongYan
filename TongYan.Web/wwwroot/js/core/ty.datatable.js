(function ($) {

    /* Set the defaults for DataTables initialisation */
    $.extend(true, $.fn.dataTable.defaults, {
        dom:
            "<'row'<'col-sm-6'l><'col-sm-6 text-right'f>>" +
                "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-5'i><'col-sm-7'p>>",
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
            tableId = $table.attr('id'),
            defaults = $.fn.tyDataTable.parseOptions(this);

        var option = $.extend({}, defaults, {
            drawCallback: function (settings) {
                //渲染完毕后的回调
                //清空全选状态
                $("#" + tableId + "_check_all", $table).prop('checked', false);

                //自定义drawCallback
                if (defaults.drawCallback && typeof (defaults.drawCallback) == "function") {
                    defaults.drawCallback(settings);
                }
            }
        });

        var dataApi = $table.DataTable(option);

        //全部勾选与全部取消
        $table.on('change', '.ckbox > :checkbox', function () {

            if ($(this).is("[id='" + tableId + "_check_all']")) {
                $(".ckbox > :checkbox", $table).prop("checked", this.checked);
            }
            else {
                //一般复选
                var checkbox = $("tbody .ckbox > :checkbox", $table);
                $("#" + tableId + "_check_all", $table).prop('checked', checkbox.length === checkbox.filter(':checked').length);
            }
        });

        return dataApi;
    }

    /**
     * 解析 option
     */
    $.fn.tyDataTable.parseOptions = function (target) {
        var options = {},
            opt = {},
            t = $(target);

        if (t.attr('data-grid-features')) {
            opt = $.TongYan.parser.parseOptions(target, 'data-grid-features');
            options = $.extend({}, options, opt);
        }

        if (t.attr('data-grid-option')) {
            opt = $.TongYan.parser.parseOptions(target, 'data-grid-option');
            options = $.extend({}, options, opt);
        }

        if (t.attr('data-grid-callbacks')) {
            opt = $.TongYan.parser.parseOptions(target, 'data-grid-callbacks');
            options = $.extend({}, options, opt);
        }

        if (t.attr('data-grid-data')) {
            opt = $.TongYan.parser.parseOptions(target, 'data-grid-data');
            options = $.extend({}, options, opt);
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

        //复选框列配置
        if (t.find("thead > tr:eq(0) > th:eq(0) .ckbox").length > 0) {
            options["columns"].push({
                orderable: false,
                className: 'text-center',
                width: '30px',
                render: function (data, type, row, meta) {
                    var id = meta.settings.sTableId + '_check_' + meta.row;
                    return '<div class="ckbox ckbox-default">' +
                                '<input id="' + id + '" type="checkbox">' +
                                '<label for="' + id + '"></label>' +
                            '</div>';
                }
            });
        }

        //parse columns
        domColumns.each(function (i, tr) {
            var columnOpt = $.TongYan.parser.parseOptions($(tr), 'data-grid-column');
            if (columnOpt && columnOpt.data && columnOpt.name) {
                options["columns"].push(columnOpt);
            }
        });

        return options;
    }

})(jQuery)

(function ($, window, document, undefined) {
    DataTable.checkbox = {};
    DataTable.checkbox.init = function (dt) {
        alert(0);
    }

    // Local variables to improve compression
    var apiRegister = DataTable.Api.register;
    var apiRegisterPlural = DataTable.Api.registerPlural;

    apiRegister('checkbox()', function () {
        return this.iterator('table', function (ctx) {
            DataTable.checkbox.init(new DataTable.Api(ctx));
        });
    });

   
})(jQuery)