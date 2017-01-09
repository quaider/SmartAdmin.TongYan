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

        self.initIframe();
    },

    initIframe: function () {
        var mainFrame = $("#mainFrame")[0];
        if (mainFrame.attachEvent) {
            mainFrame.attachEvent("onload", function () {
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