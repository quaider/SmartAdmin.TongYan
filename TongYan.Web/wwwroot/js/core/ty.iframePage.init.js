(function ($) {

    //设置全局tooltips
    $('body').tooltip({
        selector: '[data-toggle="tooltip"]',
        trigger: 'hover'
    });

    $.fn.select2.defaults.language = "zh-CN";

})(jQuery)