$(document).ready(function () {
    window.parent.$('#ContentFrame').css({
        height: '2200px'
    });
    window.parent.scrollTo(0, 0);
    var typesite = window.parent.SiteType == undefined ? "0" : window.parent.SiteType;
    //  debugger;
    $.ajax({
        url: $.url + '/Voice/GetVoice',
        type: 'post',
        data: { siteType: typesite },
        dataType: 'json',
        success: function (rel) {
            if (rel.IsSuccess) {
                var voiceContainer = $('.stu-part1');
                var shtml = "";
                rel.Result.forEach(function (voice) {
                    shtml += '<dl><dt style="width:230px;height:149px;" data="' + (voice.VideoUrl || '') + '">'
                        + '<div style="width:230px;height:149px;">'
                        + '<img class="student" src="' + (voice.Logo || '../Images/member_default.png') + '">'
                        + (voice.VideoUrl ? '<img class="play" src="../../images/play_student.png" /></div>' : '')
                        + '</dt><dd><h2>' + (voice.Name || '') + '</h2><p>' + (voice.Content || '') + '</p></dd></dl>';
                });
                voiceContainer.append(shtml);

                $('dt').mouseover(function () {
                    $(this).find(".play").css({ visibility: 'visible' });
                }).mouseout(function () {
                    $(this).find(".play").css({ visibility: 'hidden' });
                }).click(function () {
                    if ($(this).attr('data'))
                    webAbc.OpenPage($(this).attr('data'), '');
                })
            }
        }
    });
});