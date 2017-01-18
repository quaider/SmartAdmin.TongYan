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
            var dt = this.s.dt;

            //首列插入checkbox
            var rowspan = that.dom.thead.find(" > tr").length,
                firstRow = that.dom.thead.find(" > tr").first(),
                ckRow = $(that.c.template);

            if (rowspan > 1)
                ckRow.attr("rowspan", rowspan);

            ckRow.insertBefore(firstRow.find("th:eq(0)"));
        }

    });


    /**
	 * Defaults
	 * @type {Object}
	 * @static
	 */
    Check.defaults = {
        className: 'ckbox-default',
        template: '<th><div class="ckbox"><input type="checkbox"><label></label></div></th>'
    };


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