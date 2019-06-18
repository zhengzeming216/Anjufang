$(document).ready(function () {
    //右浮标
    var screen_width = parseInt($(window).width())
   , setWidth = (screen_width - 1190) / 2;
    if (screen_width > 1190) {
        $(".ad-r").css("right", setWidth - 85 + "px");
    }
    else {
        $(".ad-r").css("display", "none");
    }
});

//把string转化为json数据
function JsonEval(jsonObj) {
    var str = "";
    try {
        str = eval(jsonObj);
    } catch (err) {
        str = eval("(" + jsonObj + ")");
    }
    return str;
}

//layer提示处理
function layermsg(content, callback, time) {
    if (typeof (time) == 'undefined' || time == "") {
        time = 2000;
    }
    if (typeof (callback) == 'undefined' || time == null) {
        layer.msg(content, {
            // icon: type,
            time: time //几秒关闭
        });
    }
    else {
        layer.msg(content, {
            // icon: type,
            time: time //几秒关闭
        }, callback);
    }
}

//警告层
function layerAlert(message) {
    layer.alert(message, { icon: 5 });
}

//验证层
//positionType 方向,1-4对应上右下左，默认右边
//eg. layerTip("请输入标题", "#title", 1) {
function layerTip(message, target, positionType, color) {
    layer.tips(message, target, {
        tips: [positionType || 2, color || '#78BA32']
    });
}

//询问层
function layerConfirm(title, btn1, btn2, event1, event2) {
    if (btn1 == null) {
        btn1 = "是";
    }
    if (btn2 == null) {
        btn2 = "否";
    }
    //询问框
    layer.confirm(title, {
        btn: [btn1, btn2] //按钮
    }, event1, event2);
}

//加载函数，可以扩展，默认调layer插件
function layerLoading(vOptions) {
    var options = {
        type: 0
    };
    if (typeof vOptions == 'object') {
        options = $.extend(options, vOptions);
    }
    //调用layer插件，使用:layerLoading();layerLoading(1);取消:layerLoading({ close:true });
    if (options.type == 0) {
        if (options.close === true) {
            layer.closeAll();
        }
        else {
            layer.load(vOptions);
        }
    }
        //背景图片实现，使用:layerLoading({ type: 1, target: "#myAttnList" });取消:layerLoading({ type: 1, target: "#myAttnList", close:true });
    else if (options.type == 1) {
        var $target;
        if (options.target) {
            $target = $(options.target);
            if (options.close === true) {
                $target.removeClass("loading");
            }
            else {
                $target.addClass("loading");
            }
        }
    }
        //文字实现，使用:layerLoading({ type: 2, target: ".bbstags",msg:"加载中..." });取消:layerLoading({ type: 2, target: ".bbstags", close:true });
    else if (options.type == 2) { //文字实现
        var $target;
        if (options.target) {
            $target = $(options.target);
            if (options.close === true) {
                $target.html("");
            }
            else {
                options.msg = options.msg ? options.msg : '加载中...';
                $target.html(options.msg);
            }
        }
    }
}

//检验手机号
function CheckPhone(phone) {
    var myreg = /^(((1[0-9]{1}[0-9]{1})|(18[0-9]{1}))+\d{8})$/;
    if (!myreg.test(phone)) {
        return false;
    }
    return true;
}


//滚动到目标元素位置
function RollToTarget(targetId) {
    $('html, body').animate({
        scrollTop: $("#" + targetId).offset().top
    }, 200);
}

//返回顶部
function RollToTop() {
    $('html, body').animate({
        scrollTop: 0
    }, 200);
}