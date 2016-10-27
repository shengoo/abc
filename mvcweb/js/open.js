$(document).ready(function () {
    
    window.parent.$('#ContentFrame').css({
        height: 2500
    });
    //webAbc.ajax({
    //    url: '/Open/GetOpenClass',
    //    success: function (sourceCourse) {
            
    //        webAbc.getPageSetting($('.free-course'), sourceCourse, 4, function (datas) {
    //            $(".course").remove();
    //            for (var i = 0; i < datas.length; i++) {
    //                var course = datas[i];
    //                //var now = new Date(), 
    //                    //startTime = new Date(course.FreeStartTime.replace('-', '/').replace('-', '/')),
    //                   // endTime = new Date(course.FreeEndTime.replace('-', '/').replace('-', '/'));
    //               // course.state = startTime > new Date();
    //                var row = $('<div class="' + (i % 2 ? 'course  bg_gray' : 'course') +
    //                    '"><div class="each-media" style="background-color: #efefef;margin-bottom: 14px;margin-top: 27px;display: table;clear: left;"><div class="media-img" style="position: relative;float: left;width: 299px; height: 191px;overflow: hidden;"><img style="width:100%;height:100%;" src="' + course.ImgUrl + '"></div><div class="media-text" style="position: relative;float: right;width: 685px;height: 191px;padding: 15px 30px 0 20px;"><i class="caret" style="top: 10px;left: -18px;border-right-color: #efefef;"></i><h5 style="color: #282828;font-size: 14px;line-height: 20px; margin-bottom: 14px;">' + course.Title +
    //                    '</h5><p style="padding-left: 2px;font-size: 12px;line-height: 18px;">' + course.About +
    //                    '</p><div class="tool" style="height: 31px;line-height: 31px;margin-top: 44px;overflow: hidden;">
    //<div class="like" style="float: left;line-height: 31px;padding-left: 2px;"><span>' + course.Num + '</span>
    //<i style=" background-position: right -56px;"></i></div>
    //<div class="play-btn" style=" float: right;width: 109px;height: 31px;text-align: center;color: #fff; background: url(../../image/sprite.png) no-repeat -218px -195px;">视频回放</div></div></div>');
    //                row.find('button').click(function () {
    //                    var e = $(this),
    //                        type = e.attr('type'),
    //                        classId = e.attr('data'),
    //                        numObj = e.prev().find("font");

    //                    var p = window.parent;
    //                    if (!p.CurrentUser) {
    //                        p.showLogin();
    //                        return;
    //                    }
    //                    if (!type) return;
    //                    if (type === "play") {
    //                        webAbc.PlayGenSee({ CplId: classId, CourseType: 1 });
    //                        return;
    //                    }
    //                    if (type === 'hold') {
    //                        webAbc.ajax({
    //                            url: '/Open/HoldOpenClass',
    //                            data: { classId: classId },
    //                            success: function (rel) {
    //                                window.parent.showMessage(1, '占座成功！');
    //                                e.html('已加入');
    //                                e.attr('data', '');
    //                                numObj.html(parseInt(numObj.text()) + 1);
    //                            }
    //                        });
    //                    }
    //                });
    //                row.insertBefore($(".free-course"));
    //            };
    //        });
    //    }
    //});

    //webAbc.ajax({
    //    url: $.url + '/Open/GetArticle',
    //    success: function (sourceRecord) {
    //        webAbc.getPageSetting($('.sentence'), sourceRecord, 10, function (datas) {
    //            //$(".course").remove();
    //            for (var i = 0; i < datas.length; i++) {
    //                //var course = datas[i];
    //                var row = ""
    //                if (datas[i].WeiXinUrl) {
    //                    row = $('<li class="each-sentence" style="height:80px;line-height:80px;background:#eee;padding: 0 30px 0 20px;overflow: hidden;margin-top: 29px;"><div class="sen-left" style="float: left;font-size: 0;"><i style="display: inline-block;width: 28px; height: 28px;text-align: center;line-height: 28px; background: url(../../image/sprite.png) no-repeat right -28px; color: #fff;font-size: 14px;font-style: normal;">' + i + '</i><a style="margin-left: 22px;font-size: 14px;" href="' + datas[i].WeiXinUrl + '" target=_blank>"' + datas[i].Title + '"</a></div><div class="like" style="float: right;"><span>' + datas[i].Id + '</span><i style="background-position: right -56px"></i></div></li>');
    //                } else {
    //                    row = $('<li class="each-sentence" style="padding: 0 30px 0 20px;overflow: hidden;margin-top: 29px;"><div class="sen-left" style="float: left;font-size: 0;"><i style="display: inline-block;width: 28px; height: 28px;text-align: center;line-height: 28px; background: url(../../image/sprite.png) no-repeat right -28px; color: #fff;font-size: 14px;font-style: normal;">' + i + '</i><a style="margin-left: 22px;font-size: 14px;" href="' + $.url + "/Open/DayWord?id=" + datas[i].Id + '">' + datas[i].Title + '</a></div><div class="like" style="float: right;"><span>' + datas[i].Id + '</span><i style="background-position: right -56px"></i></div></li>');
    //                }
    //                row.insertBefore($(".sentence"));
    //            }
    //        },true);
    //    }
    //});
});