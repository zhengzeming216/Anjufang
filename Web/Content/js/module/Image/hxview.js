
$(function () {
    GetList();
})

//查询数据
function GetList() {
    var hxid = $("#hidHXId").val();
    var Loading;
    $.ajax({
        url: "/Image/GetHXPhotoInfo/",
        type: "POST",
        data: {
            xmid: $("#hidDCID").val(),
            hxid: hxid
        },
        beforeSend: function () {
            Loading = layer.load(1, {
                shade: [0.1, '#fff'] //0.1透明度的白色背景
            });
        },
        success: function (data) {
            layer.close(Loading);
            var result = JsonEval(data);
            //判断是否报错
            if (parseInt(result.StatsCode) == 500) {
                return;
            }

            if (result.Data.listHuxing4.length > 0) {
                createHuxingHTML(result.Data.listHuxing4, result.Data.Huxing);
            }
            if (result.Data.listHXInfo.length > 0) {
                createHTML(result.Data.listHXInfo, hxid);
            }
            if (result.Data.hxDic != null) {
                createHXInfoHTML(result.Data.hxDic);
            }
            //setheight();
        },
        complate: function () {
            layer.close(Loading);
        }
    });
}

//查询几房下所有的户型
function GetHuxingnfo(Huxing) {
    var Loading;
    $.ajax({
        url: "/Image/GetHuxingnfo/",
        type: "POST",
        data: {
            xmid: $("#hidDCID").val(),
            Huxing: Huxing
        },
        beforeSend: function () {
            Loading = layer.load(1, {
                shade: [0.1, '#fff'] //0.1透明度的白色背景
            });
        },
        success: function (data) {
            layer.close(Loading);
            var result = JsonEval(data);
            //判断是否报错
            if (parseInt(result.StatsCode) == 500) {
                return;
            }

            $("#ulHuxing li").removeClass("active");
            $("#liHuxing" + Huxing).addClass("active");
            if (result.Data.listHXInfo.length > 0) {
                createHTML(result.Data.listHXInfo, result.Data.HXId);
            }
            if (result.Data.hxDic != null) {
                createHXInfoHTML(result.Data.hxDic);
            }
            //setheight();
        },
        complate: function () {
            layer.close(Loading);
        }
    });
}

//获得户型信息
function GetHXInfo(hxid) {
    var Loading;
    $.ajax({
        url: "/Image/GetHXInfo/",
        type: "POST",
        data: {
            hxid: hxid
        },
        beforeSend: function () {
            Loading = layer.load(1, {
                shade: [0.1, '#fff'] //0.1透明度的白色背景
            });
        },
        success: function (data) {
            layer.close(Loading);
            var result = JsonEval(data);
            //判断是否报错
            if (parseInt(result.StatsCode) == 500) {
                return;
            }

            $("#ulPhotoInfo li").removeClass("active");
            $("#liHXInfo" + hxid).addClass("active");

            if (result.Data.hxDic != null) {
                createHXInfoHTML(result.Data.hxDic);
            }
            //setheight();
        },
        complate: function () {
            layer.close(Loading);
        }
    });
}

//几房户型数据
function createHuxingHTML(data, Huxing) {
    var itemHtml = "";
    for (var i = 0; i < data.length; i++) {
        itemHtml += _.template($("#tmpHuxingList").html())({ datas: data[i], Huxing: Huxing });
    }
    $("#ulHuxing").html(itemHtml);
}

//相册数据
function createHTML(data, hxid) {
    var itemHtml = "";
    for (var i = 0; i < data.length; i++) {
        itemHtml += _.template($("#tmpPhotoList").html())({ datas: data[i], hxid: hxid });
    }
    $("#ulPhotoInfo").html(itemHtml);
}

function createHXInfoHTML(data) {
    var itemHtml = _.template($("#tmpHXInfo").html())({ datas: data });
    $("#divHXInfo").html(itemHtml);
}

function closeView() {
    parent.layer.closeAll();
}

function setheight() {
    //设置windowrightmian高度      
    $("#divhxContent").css("height", document.body.scrollHeight - $("#divhxTop").height() - 130);
}