var TyApp = {

    /**
     * 初始化应用程序
     */
    start: function () {
        var self = this;
        //初始化滚动条
        $('.slimscrollleft').slimScroll({
            height: 'auto',
            position: 'right',
            size: "5px",
            color: '#000',
            opacity: .4,
            wheelStep: 5
        });

        //初始化菜单
        $("#sidebar-menu").smartMenu();

        /* Set the defaults for DataTables initialisation */
        $.extend(true, $.fn.dataTable.defaults, {
            dom:
                "<'row'<'col-sm-6'l><'col-sm-6 text-right'B>>" +
                    "<'row'<'col-sm-12'tr>>" +
                    "<'row'<'col-sm-5'i><'col-sm-7'p>>",
            renderer: 'bootstrap',
            language: {
                "url": "Scripts/i18n/datatable.lang.chinese.json"
            }
        });

        self.initIframe();
    },

    initIframe: function () {
        var mainFrame = $("#mainFrame")[0];
        if (mainFrame.attachEvent) {
            iframe.attachEvent("onload", function () {
                iframeLoaded();
            });
        }
        else {
            mainFrame.onload = function () {
                iframeLoaded();
            };
        }

        function iframeLoaded() {
            //$("#wrapper").removeClass("blur");
            layer.closeAll('loading');
        }
    }
};


//do some initialization
(function ($) {

    $(function () {
        TyApp.start();
    });

})(jQuery)