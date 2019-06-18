//初始化加载
$(function () {    
    $(".lpinfo").click(function () {
        var oLink = $(this).find(".imgbox").attr("href");
        window.open(oLink);
    })
    $(".lpinfo").find("a").click(function (event) {
        event.stopPropagation();
    });
});
