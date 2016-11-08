$(document).ready(function () {
    var nav = $(".nav ul");
    var navLi = nav.find("li");
    var hover = $(".nav .hover");
    var focus = $(".nav .focus");
    var index, left, mythis, width = 90;
    var focuLi = navLi.eq(0);
    focuLi.addClass("color-white");
    navLi.hover(function () {
        index = $(this).index();
        left = width * index;
        hover.show();
        hover.stop().animate({ "left": left + "px" }, 100);
    });
    navLi.click(function () {
        index = $(this).index();
        left = width * index;
        if (focuLi) focuLi.removeClass('color-white');
        //focuLi.find("a").css("color", "#666");
        focuLi = $(this);
        focuLi.addClass('color-white');
        //focuLi.find("a").css("color", "#FFF");
        focus.stop().animate({ "left": left + "px" }, 100);
    });
    navLi.mouseout(function () {
        hover.hide();
    });
    window.changeTab = function (index) {
        navLi.eq(index).click();
    }
    window.backHome = function () {
        navLi.eq(0).click();
        //$("#ContentFrame").css("height", "2900px");
        alert("ss");
    }
});