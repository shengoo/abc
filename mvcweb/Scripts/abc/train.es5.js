﻿'use strict';

$(function () {
    window.top.$('.footer').css('background-color', 'green');
    window.top.$('.footer .footer-icon').css('background-position-y', '-522px');
    window.onunload = function () {
        window.top.$('.footer').css('background-color', '');
        window.top.$('.footer .footer-icon').css('background-position-y', '-443px');
    };
    $('.course-intro .btn').click(function () {
        webAbc.OpenPage('http://video.abc.com.cn/zxyy.mp4');
    });
});

