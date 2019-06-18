var click = 0;
$(function () {
    var a = $("#lpphotos > a").length;
    if (parseInt(a) > 5) {
        $('#lpphotos').owlCarousel({
            items: 5.34,
            pagination: false,
            autoPlay: true,
            navigation: true
        });
    }
    else {
        $('#lpphotos').owlCarousel({
            items: 5.34,
            pagination: false,
            autoPlay: false,
            navigation: false
        });
    }
});
 

function showAnJu() {
    click = 1;
    layer.closeAll();
    layer.open({
        type: 2,
        title: false,
        area: ['680px', '756px'],
        fixed: false, //不固定
        maxmin: false,
        closeBtn: false,
        content: ['/QA/AnJuQA/', 'no']
    });
}

function showGongZu() {
    click = 1;
    layer.closeAll();
    layer.open({
        type: 2,
        title: false,
        area: ['680px', '756px'],
        fixed: false, //不固定
        maxmin: false,
        closeBtn: false,
        content: ['/QA/GongZuQA/', 'no']
    });
}

function backClick(url) {
    setTimeout("stoBackClick('" + url + "')", 200);
    return false;
}

function stoBackClick(url) {
    if (click == 1) {
        click = 0;
    }
    else {
        if (url != "") {
            window.open(url);
        }
    }
}

//发布委托弹窗
function ReleaseEntrust() {
    click = 1;
    layer.closeAll();
    layer.open({
        type: 2,
        title: false,
        area: ['680px', '650px'],
        fixed: false, //不固定
        maxmin: false,
        closeBtn: false,
        content: ['/QA/ReleaseEntrust/', 'no']
    });
}

