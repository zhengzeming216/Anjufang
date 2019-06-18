$(function () {
    GetPushProject();
    GetHxList();

    //$("#detailNav ul li").click(function () {
    //    $("#detailNav ul li").each(function () {
    //        $(this).removeClass("current");
    //    });
    //    $(this).addClass("current");
    //})
})
//圈子与资讯的切换
function ShowTab(type) {
    if (type == 1) {
        $("#quanzidiv").show();
        $("#zixundiv").hide();
        $("#tab1").addClass("active");
        $("#tab2").removeClass("active");
        $("#linkQuanZi").show();
        $("#linkZiXu").hide();
        return;
    }
    $("#tab1").removeClass("active");
    $("#tab2").addClass("active");
    $("#quanzidiv").hide();
    $("#zixundiv").show();
    $("#linkQuanZi").hide();
    $("#linkZiXu").show();
}

//获取你可能感兴趣的楼盘
function GetPushProject() {
    var source = $("#hidProt").val();
    $.ajax({
        url: "/Project/GetPushProject/",
        type: "POST",
        dataType: 'json',
        data: {
            source: source,
            id: $("#hidDCId").val()
        },
        beforeSend: function () {
        },
        success: function (data) {
            if (data != "") {
                var html = "";
                var handleResult = JsonEval(data);
                if (handleResult.StatsCode == 200) {
                    var list = handleResult.Data;
                    if (list.length > 0) {
                        for (var i = 0; i < list.length; i++) {
                            var item = list[i];
                            var cla = "blue";
                            if (item.XMZT != "正在申请") {
                                cla = "gray";
                            }
                            html += '<a class="item" href="/house/' + item.Id + '.html" target="_blank" title="' + item.TGMC + '"><p class="anjuSatu ' + cla + '">' + item.XMZT + '</p><img src="' + item.ImagePath + '" alt="' + item.TGMC + '"><p><span class="f14 mr5 ml10">' + item.TGMC + '</span>[' + item.Area + ']</p></a>';
                        }
                        $("#lpphotos").html(html);
                        $('#photos').owlCarousel({
                            items: 4,
                            pagination: false,
                            autoPlay: true,
                            navigation: true
                        });
                        $('#lpphotos').owlCarousel({
                            items: 4.32,
                            pagination: false,
                            autoPlay: true,
                            navigation: true
                        });
                    }
                    else {
                        $("#pushprojectdiv").hide();
                    }
                }
            }
        },
        error: function (data) {
            var a = data;
        },
        complete: function () {
        }
    });
}

//获取户型
var pageIndex = 0;
function GetHxList() {
    var source = $("#hidProt").val();
    var txtPrice = "万";
    var txtFlag = "售";
    if (source == 1) {
        txtFlag = "租";
        txtPrice = "万";
    }
    pageIndex = pageIndex + 1;
    var dcId = $("#hidDcId").val();
    var tgmc = $("#hidTgmc").val();
    $.ajax({
        url: "/Project/GetHxList/",
        type: "POST",
        dataType: 'json',
        data: { dcId: dcId, tgmc: tgmc, pageIndex: pageIndex },
        beforeSend: function () {
        },
        success: function (data) {
            if (data != "") {
                var html = "";
                var handleResult = JsonEval(data);
                if (handleResult.StatsCode == 200) {
                    var list = handleResult.Data;
                    if (list.length > 0) {
                        for (var i = 0; i < list.length; i++) {
                            var item = list[i];
                            html += '<div class="lpinfo" onclick="showPhoto(' + item.Id + ',' + dcId + ')"><a href="javascript:void(0);" class="imgbox" title="' + tgmc + '"><img src="' + item.ImgPath + '" alt="' + tgmc + '"><p class="t-icon">' + item.SampleImgCount + '张</p></a>';
                            html += '<div class=" mianbox mt10">';
                            html += '<a href="javascript:void(0);" title="' + tgmc + '" class="tit left" target="_blank">' + item.Title + '</a><div class="tagbox left"><a href="#" class="blue-14">样板间（' + item.SampleImgCount + '张）</a></div>';
                            html += '<div class="fix"><div class="address">';                            
                            html += '<p class="mt8">户型解读：' + item.Comment + '</p>';
                            html += '</div></div></div></div>';
                        }
                        $("#hxlist").append(html);
                    }
                    else {
                        if (pageIndex == 1) {                            
                            $("#hxtab").remove();
                            $("#hxtop").remove();                           
                        } else {
                            $("#hxshowmore").html("没有更多了...")
                        }
                    }
                }
            }
        },
        error: function (data) {
            var a = data;
        },
        complete: function () {
        }
    });
}
