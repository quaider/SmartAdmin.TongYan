(function (factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD
        define(['jquery', 'datatables.net'], function ($) {
            return factory($, window, document);
        });
    }
    else if (typeof exports === 'object') {
        // CommonJS
        module.exports = function (root, $) {
            if (!root) {
                root = window;
            }

            if (!$ || !$.fn.dataTable) {
                $ = require('datatables.net')(root, $).$;
            }

            return factory($, root, root.document);
        };
    }
    else {
        // Browser
        factory(jQuery, window, document);
    }
}(function ($, window, document, undefined) {
    'use strict';
    var DataTable = $.fn.dataTable;

    var Check = function (dt, config) {
        if (config === true) {
            config = {};
        }

        dt = new DataTable.Api(dt);

        this.c = $.extend(true, {}, Check.defaults, config);

        this.s = {
            dt: dt
        };

        this.dom = {
            thead: $(dt.table().header()),
            tbody: $(dt.table().body())
        }

        var dtSettings = dt.settings()[0];
        if (dtSettings._check) {
            throw "Check already initialised on table " + dtSettings.nTable.id;
        }

        dtSettings._check = this;

        this._constructor();
    }

    $.extend(Check.prototype, {

        _constructor: function () {
            var that = this;
            var dt = this.s.dt,
                table = $(dt.table().node()),
                container = $(dt.table().container());

            var ctx = dt.settings()[0];

            //首列插入checkbox
            var rowspan = that.dom.thead.find(" > tr").length,
                firstRow = that.dom.thead.find(" > tr").first(),
                ckAllId = ctx.sTableId + "_ckbox_all",
                headCkRow = $(getTemplate(that.c.template, true).replace(/{{id}}/g, ckAllId));

            //thead checkbox
            if (rowspan > 1)
                headCkRow.attr("rowspan", rowspan).addClass("ckbox-cell");

            headCkRow.insertBefore(firstRow.find("th:eq(0)"));

            //tbody checkbox in each row should inserted in RowCreatedCallback, we use a hack
            ctx.aoRowCreatedCallback.push({
                fn: function (row, data, index) {
                    //var d = ctx.aoData[index];
                    var id = ctx.sTableId + "_ckbox_" + index;
                    var bodyCkRow = $(getTemplate(that.c.template).replace(/{{id}}/g, id));
                    bodyCkRow.addClass("ckbox-cell");
                    bodyCkRow.insertBefore($(row).find(" > td:eq(0)"));
                }
            });

            //check
            container.on('change.check', that.c.selector, function (e) {
                if (!e.target || !e.target.id) return;
                if (e.target.id === ckAllId) {
                    $("tbody .ckbox > :checkbox", table).prop("checked", this.checked);
                    dt.rows().check(this.checked);
                }
                else {
                    var checkbox = $("tbody .ckbox > :checkbox", table);
                    $("#" + ckAllId, table).prop('checked', checkbox.length === checkbox.filter(':checked').length);

                    //dt.row($(e.target).closest('tr')).check();
                    that._checkItem($(e.target).closest('tr').index(), this.checked);
                }
            })
        },

        _emitEvent: function (name, args) {
            this.s.dt.iterator('table', function (ctx, i) {
                $(ctx.nTable).triggerHandler(name + '.dt', args);
            });
        },

        /**
	     * 选中单个节点
	     * @rowIdx {number} 行索引
	     * @check {boolean} 是否勾选
	     */
        _checkItem: function (rowIdx, check) {
            var that = this,
                dt = this.s.dt,
                ctx = dt.settings()[0],
                d = ctx.aoData[rowIdx];

            d._check_checked = check;
        },

        /**
	     * 获取所有选中的行的原数据
	     */
        _getCheckedItems: function () {
            var that = this,
                dt = this.s.dt,
                ctx = dt.settings()[0];

            return ctx.aoData.filter(function (ad, idx) {
                return ad._check_checked === true;
            }).map(function (d) {
                return d._aData;
            });
        }

    });


    /**
	 * Defaults
	 * @type {Object}
	 * @static
	 */
    Check.defaults = {
        className: 'ckbox-default',
        template: '<div class="ckbox"><input type="checkbox" id="{{id}}"><label for="{{id}}"></label></div>',
        selector: 'td:first-child .ckbox > :checkbox, th:first-child .ckbox > :checkbox',
    };

    function getTemplate(template, isHead) {
        if (isHead === true) {
            return '<th>' + template + '</th>'
        }

        return '<td>' + template + '</td>';
    }

    /*
     * API
     */
    var apiRegister = DataTable.Api.register;
    var apiRegisterPlural = DataTable.Api.registerPlural;

    //获取勾选的元素
    apiRegister("rows().getChecked()", function () {
        return this.context[0]._check._getCheckedItems();
    });

    //勾选指定行中的checkbox
    apiRegisterPlural("rows().check()", "row().check()", function (check) {
        check = check === false ? false : true;
        this.iterator('row', function (ctx, idx) {
            ctx._check._checkItem(idx, check);
        })

        return this;
    });

    /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
	 * DataTables interfaces
	 */

    // Attach for constructor access
    $.fn.dataTable.Check = Check;
    $.fn.DataTable.Check = Check;

    //init check plugin
    $(document).on('preInit.dt.dtCheck', function (e, ctx, json) {
        if (e.namespace !== 'dt') {
            return;
        }

        var init = ctx.oInit.check;
        var defaults = DataTable.defaults.check;

        if ((init || defaults) && !ctx._check) {
            var opts = $.extend({}, defaults, init);
            if (init !== false) {
                new Check(ctx, opts);
            }
        }
    });

    return Check;
}))