'use strict';

$(function () {

    //播放视频
    $('.course-intro .btn,.know-more').click(function () {
        webAbc.OpenPage('http://video.abc.com.cn/zxyy.mp4');
    });

    //打开注册窗口
    $('.reg').click(function () {
        window.top.showRegister();
    });

    //剩余名额
    (function () {
        var count = 400 + Math.floor(Math.random() * 100);
        var $span = $('#count');
        $span.text(count);
        var interval = setInterval(function () {
            if (count <= 50) {
                clearInterval(interval);
            } else {
                count--;
                $span.text(count);
                console.log(count);
            }
        }, 90000);
    })();

    window.parent.$('#ContentFrame').css({
        height: document.body.clientHeight
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

