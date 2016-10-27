'use strict';

$(document).ready(function () {

    $.ajax({
        url: $.url + '/Team/GetForeignTearcher',
        type: 'post',
        dataType: 'json',
        success: function success(teams) {
            if (!teams) return;
            var pageSize = 9;
            var pageCount = teams.length;
            webAbc.getPageSetting($('.col'), teams, 9, function (items) {
                while ($(".each-teacher").length > 0) {
                    $(".each-teacher")[0].remove();
                }
                var i = 0;
                var sourceContainer = $('.col');
                //todo: 外教从哪来，接口里没有提供
                //todo: 有些视频无法播放
                items.forEach(function (item) {
                    sourceContainer.append($('<div class="each-teacher" >' + '<div class="photo" style="background-image: url(' + (item.Logo || $.url + '/image/foreign_teacher/teacher_1.png') + ');" data="' + (item.Video || '') + '">' + (item.Video ? '<img class="play" src="../../images/play_teacher.png" /></div>' : '</div>') + '<div class="teacher-intro" >' + '<p class="name">' + '<i></i>' + '外教：<span id="">' + item.Name + '</span></p><p class="hometown">来自纽约州</p><p class="intro-text">' + (item.Signature || '') + '</p></div>' + '</div>'));
                    i++;
                });
                for (; i < 9; i++) {
                    sourceContainer.append($('<div class="each-teacher" style="border:0px;"></div>'));
                }
                $('.each-teacher .photo').mouseover(function () {
                    $(this).find(".play").css({ display: 'block' });
                }).mouseout(function () {
                    $(this).find(".play").css({ display: 'none' });
                }).click(function () {
                    if (!$(this).attr('data')) return;
                    window.top.webAbc.OpenPage($(this).attr('data'), '');
                });
            });
            $('.col a').remove();
            webAbc.autoAjustIframeHeight();
        }
    });
});

