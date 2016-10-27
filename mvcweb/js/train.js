$(document).ready(function () {
    //webAbc.bindPageImage(4, function (results) {
    //    $('.ban')[0].style.backgroundImage = 'url(' + results[0].Url + ')';
    //})
    window.parent.$('#ContentFrame').css({
        height: 3151
    });
    $(".margintop_img img").slice(0,3).css("cursor", "pointer").click(function () {
        var p = window.parent;
        if (!p.CurrentUser) {
            p.showLogin();
            return;
        }
    })
})