$(document).ready(function () {
    webAbc.bindPageImage(4, function (results) {
        $('.ban')[0].style.backgroundImage = 'url(' + results[0].Url + ')';
    })
    window.parent.$('#ContentFrame').css({
        height: 2570
    });

    $.ajax({
        url: $.url + '/Team/GetForeignTearcher',
        type: 'post',
        dataType: 'json',
        success: function (teams) {
            if (!teams) return;
            var pageSize = 9;
            var pageCount = teams.length;
            webAbc.getPageSetting($('.page'), teams, 9, function (items) {
                while ($(".team_box").length > 0) { $(".team_box")[0].remove(); }
                var i = 0;
                var sourceContainer = $('.team2_con');
                items.forEach(function (item) {
                    sourceContainer.append(
                        $('<div class="team_box bg_gray" >'
                        + '<div class="teacher" data="' + (item.Video || '') + '" style="width:300px;height:198px;cursor:pointer; "><img style="position:fixed;z-index:1" src="' + (item.Logo || $.url + '/Images/foreignteacher.png') + '" alt=""/>'
                        + (item.Video ? '<img class="play" src="../../images/play_teacher.png" style="position:fixed;z-index:2;display:none;" /></div>' : '</div>')
                        + '<div class="team_in"><p style="padding-top:3px;">' + (item.Signature || '') + '</p></div>'
                        + '</div>'));
                    i++;
                })
                for (; i < 9; i++) {
                    sourceContainer.append($('<div class="team_box" style="border:0px;"></div>'));
                }
                $('.team_box .teacher').mouseover(function () {
                    $(this).find(".play").css({ display: 'block' });
                }).mouseout(function () {
                    $(this).find(".play").css({ display: 'none' });
                }).click(function () {
                    if (!$(this).attr('data')) return;
                    webAbc.OpenPage($(this).attr('data'), '');
                })
            });
        }
    });

})