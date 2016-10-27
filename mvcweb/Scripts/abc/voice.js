$(document).ready(() => {
    
    window.parent.scrollTo(0, 0);
    var typesite = window.parent.SiteType == undefined ? "0" : window.parent.SiteType;
    //  debugger;
    $.ajax({
        url: $.url + '/Voice/GetVoice',
        type: 'post',
        data: { siteType: typesite },
        dataType: 'json',
        success: (rel) => {
            if (rel.IsSuccess) {

                var voiceContainer = $('.row');
                var shtml = "";
                rel.Result.forEach((voice) => {
                    shtml += '<div class="each-feedback" data="' + (voice.VideoUrl || '') + '">' +
                        '<div class="photo" style="background-image:url(' + (voice.Logo || '/Images/member_default.png') + ')"></div>' +
                        '<div class="name" >@' + (voice.Name || '') +
                        '</div>' +
                        '<p class="feedback">' + (voice.Content || '') + '</p></div>';
                });
                voiceContainer.append(shtml);
                webAbc.autoAjustIframeHeight();
            }
        }
    });
});