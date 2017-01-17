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

    DataTable.check = {};
    DataTable.check.init = function (dt) {
        var ctx = dt.settings()[0];
        //初始配置
        var init = ctx.oInit.check;
        var defaults = DataTable.defaults.check;
        var opts = init === undefined ?
            defaults :
            init;

        var items = 'row';
        var style = 'api';
        var setStyle = false;

        if (opts === true) {
            style = 'os';
            setStyle = true;
        }
        else if (typeof opts === 'string') {
            style = opts;
            setStyle = true;
        }

        ctx._check = {};

        dt.check.items(items);
        dt.check.style(style);
    }

    function eventTrigger(api, type, args, any) {
        if (any && !api.flatten().length) {
            return;
        }

        if (typeof type === 'string') {
            type = type + '.dt';
        }

        args.unshift(api);

        $(api.table().node()).triggerHandler(type, args);
    }

    function enableCheck(dt) {
        var container = $(dt.table().container());
        var ctx = dt.settings()[0];
        var selector = ctx._check.selector;

        container
            .on('click.dtCheck', selector, function (e) {
                var items = dt.check.items();
                var idx;

                // If text was selected (click and drag), then we shouldn't change
                // the row's checked state
                if (window.getSelection && window.getSelection().toString()) {
                    return;
                }

                var ctx = dt.settings()[0];

                // Ignore clicks inside a sub-table
                if ($(e.target).closest('div.dataTables_wrapper')[0] != dt.table().container()) {
                    return;
                }

                //数据项单元格(不含thead的部分) quaider注
                var cell = dt.cell($(e.target).closest('td, th'));

                // Check the cell actually belongs to the host DataTable (so child
                // rows, etc, are ignored)
                if (!cell.any()) {
                    return;
                }

                var event = $.Event('user-check.dt');
                eventTrigger(dt, event, [items, cell, e]);

                if (event.isDefaultPrevented()) {
                    return;
                }

                var cellIndex = cell.index();
                if (items === 'row') {
                    idx = cellIndex.row;
                    //typeSelect(e, dt, ctx, 'row', idx);
                }
                else if (items === 'column') {
                    idx = cell.index().column;
                    //typeSelect(e, dt, ctx, 'column', idx);
                }
                else if (items === 'cell') {
                    idx = cell.index();
                    //typeSelect(e, dt, ctx, 'cell', idx);
                }

                ctx._check_lastCell = cellIndex;
            });
    }

    function init(ctx) {
        var api = new DataTable.Api(ctx);
        api.on('preXhr.dt.dtCheck', function () {
            
        });

        api.one('draw.dt.dtCheck', function () {
            
        });

        // Update the table information element with selected item summary
        api.on('draw.dtCheck.dt check.dtCheck.dt decheck.dtCheck.dt info.dt', function () {
            //info(api);
            
        });
    }

    // Common events with suitable namespaces
    function namespacedEvents(config) {
        var unique = config._eventNamespace;
        return 'draw.dt.DT' + unique + ' check.dt.DT' + unique + ' decheck.dt.DT' + unique;
    }


    // Local variables to improve compression
    var apiRegister = DataTable.Api.register;
    var apiRegisterPlural = DataTable.Api.registerPlural;

    apiRegister('check()', function () {
        return this.iterator('table', function (ctx) {
            DataTable.check.init(new DataTable.Api(ctx));
        });
    });

    apiRegister('check.items()', function (items) {
        if (items === undefined) {
            return this.context[0]._check.items;
        }

        return this.iterator('table', function (ctx) {
            ctx._check.items = items;
            eventTrigger(new DataTable.Api(ctx), 'checkItems', [items]);
        });
    });

    apiRegister('check.style()', function (style) {
        if (style === undefined) {
            return this.context[0]._select.style;
        }

        return this.iterator('table', function (ctx) {
            ctx._check.style = style;

            if (!ctx._check_init) {
                init(ctx);
            }

            // Add / remove mouse event handlers. They aren't required when only
            // API selection is available
            var dt = new DataTable.Api(ctx);
            //disableMouseSelection(dt);

            if (style !== 'api') {
                enableCheck(dt);
            }

            //eventTrigger(new DataTable.Api(ctx), 'selectStyle', [style]);
        });
    });

    apiRegisterPlural("rows().check()", "row().check()", function (select) {
        var api = this;
        alert(0);
        this.iterator('row', function (ctx, idx) {
            //clear(ctx);
            ctx.aoData[idx]._check_checked = true;
        })

        this.iterator('table', function (ctx, i) {
            eventTrigger(api, 'check', ['row', api[i]], true);
        });

        return this;
    });

    /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
     * Initialisation
     */
    $(document).on('preInit.dt.dtCheck', function (e, ctx) {
        if (e.namespace !== 'dt') {
            return;
        }

        DataTable.check.init(new DataTable.Api(ctx));
    });


    return DataTable.check;

}))