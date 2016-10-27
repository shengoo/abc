$(document).ready(function () {

    window.parent.$('#ContentFrame').css({
        height: 3000
    });

    $.ajax({
        url: $.url + '/Team/GetForeignTearcher',
        type: 'post',
        dataType: 'json',
        success: function (teams) {
            if (!teams) return;
            var pageSize = 9;
            var pageCount = teams.length;
            webAbc.getPageSetting($('.col'), teams, 9, function (items) {
                while ($(".each-teacher").length > 0) { $(".each-teacher")[0].remove(); }
                var i = 0;
                var sourceContainer = $('.col');
                //todo: 外教从哪来，接口里没有提供
                //todo: 有些视频无法播放
                items.forEach(function (item) {
                    sourceContainer.append(
                        $('<div class="each-teacher" style="position: relative;margin-bottom: 106px; float: left;margin-right:50px;margin-bottom: 150px;">' +
                            '<div class="photo" style="position: absolute;left: 50%;margin-left: -68.5px;margin-top: -68.5px;width: 137px;height: 137px;cursor:pointer;background-image: url(' +
                            (item.Logo || $.url + '/image/foreign_teacher/teacher_1.png') +
                            ');background-size: cover;background-position: center;border-radius: 50%;" data="' +
                            (item.Video || '') +
                            '">' +
                            (item.Video
                                ? '<img class="play" src="../../images/play_teacher.png" style="position:absolute;z-index:2;display:none;top:-30px;left:-80px;" /></div>'
                                : '</div>') +
                            '<div class="teacher-intro" style="width: 270px;height:360px;padding: 85px 35px 15px;border: 1px solid #e1e1e1; -webkit-border-radius: 5px;-moz-border-radius: 5px;-ms-border-radius: 5px;-o-border-radius: 5px;border-radius: 5px;">' +
                            '<p class="name" style="font-size: 12px;text-align: center;line-height: 18px;color: #d7333f;">' +
                            '<i style="display: inline-block;width: 11px;height: 11px;margin-right: 5px;background: url(../../image/sprite.png) no-repeat right -67px;"></i>' +
                            '外教：<span id="">' +
                            item.Name +
                            '</span></p><p class="hometown" style="font-size: 12px;text-align: center;line-height: 18px;">来自纽约州</p><p class="intro-text" style="margin-top: 13px;line-height: 26px;">' +
                            (item.Signature || '') +
                            '</p></div>' +
                            '</div>'));
                    i++;
                });
                for (; i < 9; i++) {
                    sourceContainer.append($('<div class="each-teacher" style="border:0px;"></div>'));
                }
                $('.each-teacher .photo')
                    .mouseover(function () {
                        $(this).find(".play").css({ display: 'block' });
                    })
                    .mouseout(function () {
                        $(this).find(".play").css({ display: 'none' });
                    })
                    .click(function () {
                        if (!$(this).attr('data')) return;
                        window.top.webAbc.OpenPage($(this).attr('data'), '');
                    });
            });
            $('.col a').remove();
            window.parent.$('#ContentFrame').css({
                height: document.body.clientHeight
            });
        }
    });

})