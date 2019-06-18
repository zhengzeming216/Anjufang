var menuWidth; //目录长度数组
var linkindex = 0; //起始
$(function () {
    linkindex = $("#nav li.active").index() + 1;

    var $carousel = document.getElementById('nav'),
    liArray = $carousel.querySelectorAll('a'),
    liNum = liArray.length;
    var navScrollWidth = 0;
    menuWidth = new Array(liNum);
    for (var i = 0; i < liNum ; i++) {
        menuWidth[i] = liArray[i].clientWidth + 25;
        navScrollWidth += liArray[i].clientWidth + 25;
    }

    if (navScrollWidth > 1000) {
        $("#nav").css("width", navScrollWidth * 3 + "px");

        if (linkindex > 1) {
            var leftwidth = 0;
            for (var i = 0; i < linkindex - 1 ; i++) {
                leftwidth += menuWidth[i];
            }
            //大于整个显示条
            if (leftwidth > 1000) {
                leftwidth = 0;
                for (var i = 0; i < linkindex - 1 ; i++) {
                    leftwidth += menuWidth[i];
                    if (leftwidth >= navScrollWidth - 1000) {
                        linkindex = i + 2;
                        break;
                    }
                }
                $("#nav").css("transform", "translate3d(-" + leftwidth + "px, 0px, 0px)");
            }
            else {
                linkindex = 1;
            }
        }

        $('.pre').on('click', function () {
            if (linkindex > 1) {
                linkindex--;
                var leftwidth = 0;
                for (var i = 0; i < linkindex - 1; i++) {
                    leftwidth += menuWidth[i];
                }
                $("#nav").css("transform", "translate3d(-" + leftwidth + "px, 0px, 0px)");

            }
        });
        $('.next').on('click', function () {
            if (linkindex <= menuWidth.length - 1) {
                var leftwidth = 0;
                for (var i = 0; i < linkindex ; i++) {
                    leftwidth += menuWidth[i];
                }
                $("#nav").css("transform", "translate3d(-" + leftwidth + "px, 0px, 0px)");
                linkindex++;
            }
        });
    }
});