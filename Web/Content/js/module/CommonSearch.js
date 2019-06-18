//智能提示
$("#txtKey").bind('input', function () {
    if ( $("#spanType").attr("val")=="1") {
        AutoGetProject();
    }    
})
$("#txtKey").bind('click', function () {
    var kval = $(this).val();
    if (kval != "") {
        return;
    }
    $("#searchList").hide();
    ShowOldSearch();
})
function ShowAutoDiv() {
    setTimeout(function () {
        $("#searchHistory").hide();
        $("#searchList").hide();
    }, 200)
}

$(function () {
    $("#txtKey").val($("#hidKwd").val());
})
//得到安居、公租、人才标识
var source = $("#hidProt").val();
if (source == null || source == undefined) {
    source = 0;
}
//楼盘智能提示
function AutoGetProject() {
    var key = $("#txtKey").val();
    if (key == "") {
        $("#searchList").hide().html("");
        return;
    }
    $.ajax({
        url: "/Project/AutoGetProject/",
        type: "POST",
        data: {
            key: key,
            source: source
        },
        beforeSend: function () {
            $("#searchHistory").hide();
        },
        success: function (data) {
            var html = "";
            var result = data;
            if (result.StatsCode == 200) {
                if (result.Data.length > 0) {
                    $(result.Data).each(function (i, item) {
                        html += '<li><a href="javascript:void(0);" onclick="SelectProject('+ item.Source+',\'' + item.TGMC + '\')">' + item.TGMC + '</a><span></span></li>';
                    });
                    $("#searchList").show().html(html);
                } else {
                    $("#searchHistory").hide();
                    $("#searchList").hide();
                }
            }
            else {
                layerHelp.msg(data.Message);
            }
        },
        error: function (data) {
            var a = data;
        },
        complete: function () {
        }
    });
}

//选择楼盘/搜索
function SelectProject(source,projectName) {
    
    if (projectName == "") {
        projectName = $("#txtKey").val();
    }
    $("#txtKey").val(projectName);

    var oldSearch = getCookie("anjufangsearch");
    if (oldSearch == null) {
        oldSearch = "";
    }
    if ($("#spanType").attr("val") == "1") {
        var cookieVal = source + ";" + projectName;
        if (oldSearch.indexOf(cookieVal) == -1) {
            oldSearch = cookieVal + "|" + oldSearch;
            setCookie("anjufangsearch", oldSearch);
        }
    }
    var url = '/project.html?prot=' + source + '&kwd=' + projectName;
    if (source == 0) {
        if ($("#spanType").attr("val") == "1") {
            url = '/project.html?kwd=' + projectName;
        }
        if ($("#spanType").attr("val") == "2") {
            url = 'http://news.szhome.com/search.html?key=' + projectName;
        }
    }
    window.open(url);
}

//显示历史搜索
function ShowOldSearch() {
    if ($("#spanType").attr("val") == "2") {
        return false;
    }
    var html = '';
    var dd = getCookie("anjufangsearch");
    if (dd != null) {
        html = '<li style="line-height:37px; background:#fafafa"><i class="icon06"></i>历史搜索 <a href="#" style="float:right; display:inline-block" onclick="DeleteSearchHistory()">清除</a></li>';
        var oldSearchArr = dd.split("|");
        var len = oldSearchArr.length;
        if (len > 1) {
            $("#searchHistory").show();
            len = len > 6 ? 6 : len;//只显示最新的6条
            for (var i = 0; i < len; i++) {
                var pArr = oldSearchArr[i].split(";");
                if (pArr.length != 2) {
                    continue;
                }
                var pSource = pArr[0];
                var pName = pArr[1];
                html += '<li><a href="javascript:void(0);" onclick="SelectProject(' + pSource + ',\'' + pName + '\')">' + pName + '</a></li>';
            }
        }
    }
    $("#searchHistory").html(html);
}

//清空搜索历史
function DeleteSearchHistory() {
    setCookie("anjufangsearch", "");
    $("#searchHistory").hide();
}

function setCookie(name, value) {
    var Days = 30;
    var exp = new Date();
    exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
    document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString();
}

function getCookie(name) {
    var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)"); //正则匹配
    if (arr = document.cookie.match(reg)) {
        return unescape(arr[2]);
    }
    else {
        return null;
    }
}

//显示搜索下拉框
function ShowSelect() {
    $("#ulSel").show();
}

//选择
function Select(type, obj) {
    $("#ulSel").hide();
    $("#spanType").attr("val", type);
    $("#spanType").text($(obj).text());
    var placeholder = "";
    switch (type) {
        case 1:
            placeholder = "楼盘名称";
            break;
        case 2:
            placeholder = "输入关键字";
            break;
        default:

    }
    $("#txtKey").attr("placeholder", placeholder);
}