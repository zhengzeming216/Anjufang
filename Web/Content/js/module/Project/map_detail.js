
var map = null;
var markPoint = null;
$(function () {
    //右浮标
    var screen_width = parseInt($(window).width())
   , setWidth = (screen_width - 1190) / 2;
    $(".indexseach").css("left", setWidth + "px");

    if (screen_width > 1190) {
        $(".ad-r").css("right", setWidth - 85 + "px");

    }
    else {
        $(".ad-r").css("display", "none");
    }

	function mark_tip(element)
	{
		var _title=$(element).attr("title");
		var div_obj=$(element)[0];
		alert(div_obj.offsetHeight);
		alert(div_obj.offsetWidth);
		var _body_html="<div class='tipsy'>"+_title+"</div>";
		$("body").append(_body_html);	
		var pend_obj=$(".tipsy")[0];
		var top=parseInt(pend_obj.offsetHeight +pend_obj.offsetWidth/2-div_obj.offsetHeight/2);
		var left= parseInt(pend_obj.offsetLeft+pend_obj.offsetWidth);
		$(".tipsy").css({"top":top+"px","left":left+"px"});
	}
    //地图
    var startZoom = 15;
    map = new BMap.Map("map_canvas");
    markPoint = new BMap.Point(p_maplng, p_maplat);
    map.centerAndZoom(markPoint, startZoom);
//    var myDis = new BMapLib.DistanceTool(map);
    map.addControl(new BMap.NavigationControl());
    map.addControl(new BMap.ScaleControl());
    map.addControl(new BMap.OverviewMapControl());
    map.enableScrollWheelZoom();
    map.enableContinuousZoom();
    MarkerPointByClass("traffic");
});

function myDisopen() {
    var myDis = new BMapLib.DistanceTool(map);
    myDis.open()
}

function MarkerPointByType(className, type) {
    $("#tabs2 li").each(function(){
        $(this).removeClass('active');
    })

    $('#ptList_1').hide();
    $('#ptList_2').hide();
    $('#ptList_3').hide();
    $('#ptList_4').hide();

    $('#ptList_' + type).show();
    $('#ptTab_' + type).addClass('active');

    map.clearOverlays();
    MarkerPointByClass(className);

}
function MarkerPointByClass(className) {
    var pointsArr = [];
    $("." + className).each(function() {
        var x = $(this).attr('location').split(",")[0];
        var y = $(this).attr('location').split(",")[1];
        var point = new BMap.Point(x, y);
        pointsArr.push(point);


        var title = $(this).attr('title');
        var myCompOverlay = new ComplexCustomOverlay(point, title);
        map.addOverlay(myCompOverlay);

        $(this).hover(function() {
            map.setCenter(point);
            myCompOverlay.onmouseover();
        }, function() {
            myCompOverlay.onmouseout();
        });
    });

    var content = '<div class="mask_default"><table border="0" cellpadding="0" cellspacing="0"><tbody><tr><td><div class="map_bol_project"><label>' + BolName + '</label><span class="close" style="display: none;"><a onclick="">&nbsp;&nbsp;&nbsp;&nbsp;</a></span></div></td><td><div class="maskright"></div></td></tr></tbody></table></div>'
    var myLabel = new BMap.Label(content, { position: markPoint });
    myLabel.setStyle({ border: "0px" });
    map.addOverlay(myLabel);

    pointsArr.push(markPoint);
    map.setViewport(pointsArr);
}

// 复杂的自定义覆盖物
function ComplexCustomOverlay(point, text) {
    this._point = point;
    this._text = text;
}
ComplexCustomOverlay.prototype = new BMap.Overlay();
ComplexCustomOverlay.prototype.initialize = function(mymap) {
    this._map = mymap;
    var div = this._div = document.createElement("div");
    div.className = "mask_default";
    div.style.position = "absolute";
    div.style.zIndex = BMap.Overlay.getZIndex(this._point.lat);
    div.innerHTML = '<table border="0" cellpadding="0" cellspacing="0"><tbody><tr><td><div class="bolmaskleft"><label>' + this._text + '</label><span class="close" style="display: none;"><a>&nbsp;&nbsp;&nbsp;&nbsp;</a></span></div></td><td><div class="bolmaskright"></div></td></tr></tbody></table>';
    div.onmouseover = function() {
        DivOnMouseOver(this);
    }

    div.onmouseout = function() {
        DivOnMouseOut(this);
    }

    map.getPanes().labelPane.appendChild(div);
    return div;
}
ComplexCustomOverlay.prototype.draw = function() {
    var mymap = this._map;
    var pixel = mymap.pointToOverlayPixel(this._point);
    this._div.style.left = pixel.x + "px";
    this._div.style.top = pixel.y + "px";
}
ComplexCustomOverlay.prototype.onmouseover = function() {
    DivOnMouseOver(this._div);
}
ComplexCustomOverlay.prototype.onmouseout = function() {
    DivOnMouseOut(this._div);
}

function DivOnMouseOver(obj) {
    $(obj).show();
    $(obj).css("z-index", "10000");
    $(obj).find(".bolmaskleft").attr("class", "bolleft_hover");
    $(obj).find(".bolmaskright").attr("class", "right_hover");
    $(obj).find(".markercount").css({
        display: "inline"
    });
    $(obj).find(".markerclose").css({
        display: "inline"
    });
    $(obj).find(".close").css({
        display: "inline"
    });
    $(obj).find(".close").bind("click", function() {
        $(this).parents('.mask_default').css({ display: "none" });
    });
    $(obj).addClass("hover");
}

function DivOnMouseOut(obj) {
    $(obj).css("z-index", "");
    $(obj).find(".bolleft_hover").attr("class", "bolmaskleft");
    $(obj).find(".right_hover").attr("class", "bolmaskright");
    $(obj).find(".markercount").css({
        display: "none"
    });
    $(obj).find(".markerclose").css({
        display: "none"
    });
    $(obj).find(".close").css({
        display: "none"
    });
    $(obj).removeClass("hover");
}
//同位显示效果
function showSame(value) {
    if (value == 1)
    {
        $("#lpphotos").show();
        $("#lpphotos2").hide();
        $("#zb1").addClass("active");
        $("#zb2").removeClass("active");
    } else {
        $("#lpphotos").hide();
        $("#lpphotos2").show();
        $('#lpphotos2').owlCarousel({
            items: 3.32,
            pagination: false,
            autoPlay: true,
            navigation: true
        });
        $("#zb2").addClass("active");
        $("#zb1").removeClass("active");
    }
}
//楼评显示
function ShowLP(value) {
    $(".nhsLeft li").each(function () {
        $(this).removeClass('active');
    })
    $(".nhsRight").each(function () {
        $(this).hide();
    })
    $("#lpLi" + value).addClass("active");
    $("#lpDetail" + value).show();
}

//显示相册
function showPhoto(id,dcId) {
    //iframe层
    layer.open({
        type: 2,
        title: false,
        closeBtn: 0,
        shadeClose: false,
        shade: 0.3,
        area: ['1200px', '90%'],
        content: ['/Image/HXPhoto/' + projectId + '-' + dcId + '-' + id, 'no']
    });
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

//配套信息页面
function ShowPTMap() {
    $("#maskPTMap").show();
    $("#PTMapDiv").show();
    $("#detailNav").hide();
    //地图
    var startZoom = 15;
    map = new BMap.Map("map_canvas");
    markPoint = new BMap.Point(p_maplng, p_maplat);
    map.centerAndZoom(markPoint, startZoom);
    //    var myDis = new BMapLib.DistanceTool(map);
    map.addControl(new BMap.NavigationControl());
    map.addControl(new BMap.ScaleControl());
    map.addControl(new BMap.OverviewMapControl());
    map.enableScrollWheelZoom();
    map.enableContinuousZoom();
    MarkerPointByClass("traffic");
}

function HideMap() {
    $("#maskPTMap").hide();
    $("#PTMapDiv").hide();
    $("#detailNav").show();
}