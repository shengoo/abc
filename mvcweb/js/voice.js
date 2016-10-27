$(document).ready(function () {
    window.parent.$('#ContentFrame').css({
        height: '2300px'
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
              
                var voiceContainer = $('.row');
                var shtml = "";
                rel.Result.forEach(function (voice) {
                    shtml += '<div class="each-feedback" data="' + (voice.VideoUrl || '') + '" style="float: left;width: 192px;margin-right: 54px;margin-bottom:50px;">' +
                        '<div class="photo" style="width: 149px;height: 159px;margin: 0 auto;border-bottom: 10px solid #0C3E83">' +
                        '<img style="width:100%;height:100%;border-top-left-radius: 15px;border-top-right-radius: 15px;" src="' + (voice.Logo || '../Images/member_default.png') + '" alt=""></div>' +
                        '<div class="name" style="margin: 14px 0 17px;line-height: 20px;font-size: 13px;color: #0C3E83;text-align: center;">@' + (voice.Name || '')
                        + '</div><p class="feedback" style="line-height: 26px;">' + (voice.Content || '') + '</p></div>';
                });
                voiceContainer.append(shtml);
            }
        }
    });
});