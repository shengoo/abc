$(document).ready(function () {
    webAbc.bindPageImage(2, function (results) {
        $('.ban')[0].style.backgroundImage = 'url(' + results[0].Url + ')';
    })
    window.parent.$('#ContentFrame').css({
        height: 1500
    });

    var nav = $(".top_title ul");
    var navLi = nav.find("li");
    var focuLi = navLi.eq(0);
    focuLi.addClass("li_b");
    navLi.click(function () {
        if (focuLi) focuLi.removeClass('li_b');
        focuLi = $(this);
        focuLi.addClass('li_b');
    });

    webAbc.ajax({
        url: '/Open/GetOpenClass',
        success: function (sourceCourse) {
            webAbc.getPageSetting($('.page'), sourceCourse, 4, function (datas) {
                $(".course").remove();
                for (var i = 0; i < datas.length; i++) {
                    var course = datas[i];
                    var now = new Date(),
                        startTime = new Date(course.FreeStartTime.replace('-', '/').replace('-', '/')),
                        endTime = new Date(course.FreeEndTime.replace('-', '/').replace('-', '/'));
                    course.state = startTime > new Date();
                    var row = $('<div class="' + (i % 2 ? 'course  bg_gray' : 'course') +
                        '"><div class="cur_l"><img style="width:218px;height:165px;"  src="' + course.ImgUrl + '">'
                        + (now < startTime ? '<span class="start">未开始</span>' : now < endTime ? '<span class="start">直播中</span>' : '<span class="finish">已结束</span>')
                        + '</div><div class="cur_r"><div style="height:130px;"><h4>' + course.Title +
                        '</h4><p>' + (course.About || "") +
                        '</p></div><div class="course_btn"><div class="c_btn_left"><span>' + course.Teacher +
                        '</span><span style="width: 250px;" >' + course.FreeStartTime.substr(0, 16) + ' ~ ' + course.FreeEndTime.substr(11, 5) +
                        '</span></div><div class="c_btn_rig"><span class="coursenum">已有<font color="red">' + course.Num +
                        '</font>人参加</span>'
                        + (now < endTime ? course.Exist ? '<button>已加入</button>' : '<button type="hold" data="' + course.Id + '" >我要占座</button>' : '<button type="play" data="' + course.Id + '">视频回放</button>')
                        + '</div></div></div></div>');
                    row.find('button').click(function () {
                        var e = $(this),
                            type = e.attr('type'),
                            classId = e.attr('data'),
                            numObj = e.prev().find("font");

                        var p = window.parent;
                        if (!p.CurrentUser) {
                            p.showLogin();
                            return;
                        }
                        if (!type) return;
                        if (type === "play") {
                            webAbc.PlayGenSee({ CplId: classId, CourseType: 1 });
                            return;
                        }
                        if (type === 'hold') {
                            webAbc.ajax({
                                url: '/Open/HoldOpenClass',
                                data: { classId: classId },
                                success: function (rel) {
                                    window.parent.showMessage(1, '占座成功！');
                                    e.html('已加入');
                                    e.attr('data', '');
                                    numObj.html(parseInt(numObj.text()) + 1);
                                }
                            });
                        }
                    });
                    row.insertBefore($(".page"));
                };
            });
        }
    });

    webAbc.ajax({
        url: $.url + '/Open/GetArticle',
        success: function (sourceRecord) {
            var m = 0;
            webAbc.getPageSetting($('#word'), sourceRecord, 10, function (datas) {
                var ul = $('.open_r_con ul');
                m++;
                if (m > 1) {
                    $(ul).find("li").remove();
                }
                for (var i = 0; i < datas.length; i++) {
                    var shtml = "<li><span " + (i < 3 ? "class='span_g' " : '') + ">" + (i + 1) + "</span>";
                    if (datas[i].WeiXinUrl) {
                        shtml += "<a href='" + datas[i].WeiXinUrl + "'  target=_blank>" + datas[i].Title + "</a></li>";
                    } else {
                        shtml += "<a href='" + $.url + "/Open/DayWord?id=" + datas[i].Id + "'>" + datas[i].Title + "</a></li>";
                    }
                    ul.append($(shtml));
                }
            },true);
        }
    });
});