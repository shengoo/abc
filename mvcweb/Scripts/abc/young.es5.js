'use strict';

$(function () {
    $('.course-feature .btn,.know-more').click(function () {
        webAbc.OpenPage('http://video.abc.com.cn/zxyy.mp4');
    });

    new ScrollPic({
        containerId: "pic",
        prevButtonId: "left",
        nextButtonId: "right",
        containerWidth: 985,
        pageWidth: 197,
        speed: 10,
        space: 10,
        autoPlay: true,
        autoPlayInterval: 3000
    }).initialize();
    window.top.$('.fixed-register').show();
    window.onunload = function () {
        window.top.$('.fixed-register').hide();
    };
});

