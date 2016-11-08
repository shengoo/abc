$(document).ready(function () {
    //webAbc.bindPageImage(4, function (results) {
    //    $('.ban')[0].style.backgroundImage = 'url(' + results[0].Url + ')';
    //})
    window.parent.$('#ContentFrame').css({
        height: 2330
    });

    debugger;
    $("[name='learnmore']").parent().mouseover(function () {
        $(".play").css("display", "block");
    }).mouseout(function () {
        $(".play").css("display", "none");
    })


    $("img[name='learnmore']").parent().click(function () {
        webAbc.OpenPage($(this).attr('data'), '');
    }).css("cursor", "pointer");
})