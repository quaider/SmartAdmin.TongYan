(function ($) {

    /* Set the defaults for DataTables initialisation */
    $.extend(true, $.fn.dataTable.defaults, {
        dom:
            "<'row'<'col-sm-6'l><'col-sm-6 text-right'B>>" +
                "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        renderer: 'bootstrap',
        language: {
            "url": "/wwwroot/lib/jquery-datatable/js/i18n/datatable.lang.chinese.json"
        },
        buttons: []
    });



})(jQuery)