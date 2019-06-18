//返回项目列表
function BackToProjectList(cityId) {
    window.location.href = '/Admin/Project/List/' + cityId;
}

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


//切换背景颜色
function TranleteBack() {
    $("#tablist tr").each(function (back) {
        //alert(1);
        $(this).mouseover(function () {
            // alert($(this));
            back = $(this).css("background-color");
            $(this).css("background-color", "#DBE0CC");
        });
        $(this).mouseout(function () {
            $(this).css("background-color", back);
        });
    });
}

//先提示后跳转
//content为提示的内容，callback为回调函数(可选)，time为等待多久跳转（默认2s）
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
        //文字实现，使用:layerLoading({ type: 2, target: ".bbstags" });取消:layerLoading({ type: 2, target: ".bbstags", close:true });
    else if (options.type == 2) { //文字实现
        var $target;
        if (options.target) {
            $target = $(options.target);
            if (options.close === true) {
                $target.html("");
            }
            else {
                $target.html("加载中......");
            }
        }
    }
}

//截取指定长度的字符串
function subStr(input, num) {
    if (input == "" || input.length <= num) {
        return input;
    }
    var subString = input.substring(0, num) + "...";
    return subString;
}

function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}

//id补全4位方法
GetFullId = function () {
    var tbl = [];
    return function (num, n) {
        var len = n - num.toString().length;
        if (len <= 0) return num;
        if (!tbl[len]) tbl[len] = (new Array(len + 1)).join('0');
        return tbl[len] + num;
    }
}();

//写cookies
function setCookie(name, value, day) {
    var Days = day;
    var exp = new Date();
    exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
    document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString();
}
//读取cookies 
function getCookie(name) {
    var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
    if (arr = document.cookie.match(reg))
        return unescape(arr[2]);
    else
        return null;
}
//删除cookie
function delCookie(name) {
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval = getCookie(name);
    if (cval != null) document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString();
}


//选择城市弹出窗
function SelectCity() {
    //页面层
    layer.open({
        type: 1,
        title: false,
        closeBtn: [0, true],
        area: '640px',
        skin: 'layui-layer-nobg', //没有背景色
        shadeClose: true,
        content: $('#divSelectCity')
    });
}