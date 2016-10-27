$(function () {
    if (window.top.CurrentUser) {
        $('#hidTab').html('个人中心');
        if (window.top.CurrentUser.Type != 1) {
            $('#hidTab').html('个人中心');
        }
        if (window.top.CurrentUser.Type == 2 || window.top.CurrentUser.Type == 4) {
            $('#hidTab').attr('href', '/Member/Member?action=myanswer');
        } if (window.top.CurrentUser.Type == 3) {
            $('#hidTab').attr('href', '/Teacher/CourseList');
        }
    } else {
        $('.nav li:last').hide();
    }
})