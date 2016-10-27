"use strict";

$(function () {
    $('.buy-lesson').click(function () {
        if (window.top.CurrentUser) {
            location.href = $.url + "/Purchase/Buy";
        } else {
            window.top.showLogin();
        }
    });
});

