/**
 * 返回表格操作栏按钮字符串或jquery object，减少字符串拼接
 * @param {object} options 按钮配置
 * @returns {string or jquery object} 
 */
$.TongYan.operateBtn = function (options) {
	var defaults = {
		placement: 'top',
		cls: 'btn-default',
		icon: '',
		title: '',
		btnText: null,
		returnStr: true
	}

	var opt = $.extend({}, defaults, options);
	var a = $('<a href="#" class="btn btn-xs" data-toggle="tooltip"></a>');

	(opt.placement == "" || !opt.placement) && (opt.placement = "auto");
	(opt.cls == "" || !opt.cls) && (opt.placement = "btn-default");

	a.attr("data-original-title", opt.title).attr("data-placement", opt.placement).addClass(opt.cls);
	if (opt.icon && typeof opt.icon == "string" && opt.icon.length) {
		a.append('<i class="fa {0}"></i>'.replace('{0}', opt.icon));
	}

	if (opt.btnText && typeof opt.btnText == "string" && opt.btnText.length) {
		a.append(opt.btnText);
	}

	return opt.returnStr ? (a.prop("outerHTML") + " ") : a;
}