//课程特色
function buyClass(type) {
    var p = window.parent;
    if (!p.CurrentUser) {
        p.showLogin();
        return;
    }
    location.href = $.url + "/BuyClass/BuyClass?action=" + type;
}
$(document).ready(function () {
    window.parent.$('#ContentFrame').css({
        height: 2200
    });
    window.parent.scrollTo(0, 0);
})