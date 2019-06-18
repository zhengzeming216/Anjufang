var pageIndex = 2;


$(function () {
    
});

//查询数据
function GetList() {
    var Loading;
    $.ajax({
        url: "/News/GetArticles/",
        type: "POST",
        data: {
            projectId: $("#hdBolId").val(),
            page: pageIndex
        },
        beforeSend: function () {
            $("#getmore").remove();
            Loading = layer.load(1, {
                shade: [0.1, '#fff'] //0.1透明度的白色背景
            });
        },
        success: function (data) {
            layer.close(Loading);
            var result = JsonEval(data);
            //判断是否报错
            if (parseInt(result.StatsCode) == 500) {
                layermsg(result.Message);
                return;
            }

            if (pageIndex == 1) {
                $("#divList").html("");                
            }

            if (result.Data.ArticleList.length > 0) {
                createHTML(result.Data.ArticleList);
                pageIndex++;
            }

            if (pageIndex == 1 && result.Data.ArticleList.length == 0)
            {
                $("#divList").append("暂无资讯");
                return;
            }

            if (result.Data.PageSize == result.Data.ArticleList.length) {
                var getmoreHtml = "<a id=\"getmore\" href=\"javascript:GetList();\" title=\"点击加载更多\" class=\"morelink\" style=\"margin:20px 0 20px 0\">点击加载更多</a>";
                $("#divList").append(getmoreHtml);
            }
            else {
                var nomoreHtml = "<a id=\"getmore\"  href=\"javascript:void(0);\" title=\"没有更多资讯了\" class=\"morelink\" style=\"margin:20px 0 20px 0\">没有更多资讯了</a>";
                $("#divList").append(nomoreHtml);
            }
        },
        complate: function () {
            layer.close(Loading);
        }
    });
}


//文章
function createHTML(data) {
    var itemHtml = "";
    for (var i = 0; i < data.length; i++) {
        itemHtml += _.template($("#tmpArticleList").html())({ datas: data[i] });
    }
    $("#divList").append(itemHtml);
}

////最新动态
//function createSituationHTML(data) {
//    var itemHtml = "";
//    for (var i = 0; i < data.length; i++) {
//        itemHtml += _.template($("#tmpSituationList").html())({ datas: data[i] });
//    }
//    $("#divSituation").append(itemHtml);
//}