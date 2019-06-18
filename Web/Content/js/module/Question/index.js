
//初始化加载
$(function () {   
    var pCount = parseInt($("#hidTotalCount").val());  
    if (pCount > 0) {
        GetAnserList();
      //  SearchDivClick();
    }

    layer.cornerRadius = 8;  // 将图层的边框设置为圆脚

    $(".tagS,.col-box a").each(function () {
        var selectTagId = $("#hidTagId").val();//标签id
        var tagId = $(this).attr("data-tagid");
        if (tagId == selectTagId)
        {
            $(this).addClass("active");
        }
     
    });


    $("#keyword").keydown(function (e) {
        if (e.keyCode == "13") {
            $("#searchBtn").click();
        }
    });

    $("#searchBtn").click(function () {
        var key = $.trim($("#keyword").val());
        if (key == '') {
            layermsg("请输入关键字");
            return;
        }
        var sort = $("#hidSort").val();//排序
        var link = "/question.html?key=" + encodeURIComponent(key)+"&sort="+sort;
        window.location.href = link;
    });

    $(".tagS,.col-box a").click(function () {
        var tagId = $(this).attr("data-tagid");
        var sort = $("#hidSort").val();//排序
        var link = "/question.html?tagId=" + tagId + "&sort=" + sort;
        window.location.href = link;
    });

    $(".tagS").click(function () {
        $("#keyword").val($(this).text());
        $("#searchBtn").click();
    });


});


//搜索
function Search() {
    window.location.href = GetLink();
}

//获取问问回答列表
function GetAnserList() {
    $.ajax({
        url: "/Question/GetAnserList/",
        type: "POST",
        data: {
            questionIds: $("#hidQuestionIds").val()
        },
        beforeSend: function () {
        },
        success: function (data) {
            var html = ""
            $(data.Data).each(function (i, item) {
                var temp = "tempList1";
                if (item.ImageUrl != '')//有图片
                {
                    temp = "tempList2";
                }
                html= _.template($("#" + temp).html())({
                    item: item
                });
                $("#q" + item.QuestionId).html(html);
            });
           
        },
        complete: function () {

        }
    });
}

//显示全部
function ShowAll(obj, type, event)
{
    event.stopPropagation();//阻止冒泡
    event.preventDefault();//阻止默认

    var $parents = $(obj).parent();
    $parents.hide();
    if (type == 1) {//显示全部
        $parents.next().show();
    }
    else {
        $parents.prev().show();
    }
    
}

//用于房源、小区搜索页面点击空白时跳转页面用
function SearchDivClick() {
    $(".bkmian").click(function () {
        var oLink = $(this).attr("data-href");
        window.open(oLink);
    })
    //$(".bkmian").find("a").click(function (event) {
    //    event.stopPropagation();
    //    event.preventDefault();
    //});
}

function showAnJu() {
    layer.closeAll();
    layer.open({
        type: 2,
        title:false,
        area: ['680px', '756px'],
        fixed: false, //不固定
        maxmin: false,
        closeBtn: false,
        content: ['/QA/AnJuQA/' ,'no']
    });
}


function showGongZu() {
    layer.closeAll();
    layer.open({
        type: 2,
        title: false,
        area: ['680px', '756px'],
        fixed: false, //不固定
        maxmin: false,
        closeBtn: false,
        content: ['/QA/GongZuQA/' ,'no']
    });
}

