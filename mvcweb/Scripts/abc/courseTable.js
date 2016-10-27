var scheduleLesson, lessonLayer;
function initLesson(lesson) {
    var form = $('.courseform');
    form.find('#kclx').html(lesson.CategoryName);
    form.find('#kcmc').html(lesson.CourseName);
    form.find('#skls').html(lesson.TeacherCNName + (lesson.TeacherEnName ? "(" + lesson.TeacherEnName + ")" : ""));
    form.find('#skms').html(lesson.ClassModel ? '自约上课' : '固定上课');
    form.find('#sksj').html(lesson.ClassDate + ' ' + lesson.BeginTime + '~' + lesson.EndTime);
    form.find('#sksc').html(lesson.Clength + '分钟');
    form.find('#kcjb').html(lesson.LevelName);
    form.find('#kc').html(lesson.LessonNo);
    form.find('.oper').addClass('hidden');
    if (lesson.CategoryCode >= 100) {//如果是一对多的话，则隐藏，其他情况显示
        form.find('tr').eq(1).addClass('hidden');
        form.find('tr').eq(7).addClass('hidden');
    } else {
        form.find('tr').eq(1).removeClass('hidden');
        form.find('tr').eq(7).removeClass('hidden');
    }
}
function openCourseLesson(e) {
    var cplId = $(e).attr('data_id');
    var lesson = scheduleLesson = window.courseLesson.filter(function (item) { return item.CplId == cplId; })[0];
    if (!lesson) {
        webAbc.showMessage(2, '课次已取消！')
        return;
    }
    if (scheduleLesson.CategoryCode >= 100) {
        scheduleLesson.CourseType = 1;
    }
    var form = $('.courseform');
    initLesson(lesson);
    //debugger;
    form.find('.oper').removeClass('hidden');
    lesson.ClassModel ? form.find('#cancelyuyue').removeClass('hidden') : form.find('#cancelyuyue').addClass('hidden');
    var btn = form.find('.btn');
    if (!lessonLayer) {
        $('.courseform .btn').on('click', function () {
            var el = $(this),
                type = el.attr('type');

            switch (type) {
                case '1'://进入教室
                    inClassRoom(scheduleLesson);
                    break;
                case '2'://取消预约
                    cancelYuyue(scheduleLesson.CplId, scheduleLesson.CategoryCode, function () {
                        layer.closeAll();
                        initSchedule(new Date());
                    });
                    break;
                case '3'://视频回放
                    //  debugger;
                    //  webAbc.PlayGenSee(scheduleLesson);
                    searchVideoAccess(scheduleLesson.CplId, scheduleLesson.CourseType);
                    break;
                case '4'://下载课件
                    searchLessonAccess(scheduleLesson.CplId);
                    break;
            }
        })
    }
    var now = Date.parse(new Date()),
        ds = webAbc.stringParseDate(lesson.ClassDate + ' ' + lesson.BeginTime + ':00'),//课程的开始时间
        de = webAbc.stringParseDate(lesson.ClassDate + ' ' + lesson.EndTime + ':00');//课程的结束时间

    btn.addClass('hidden');//课程开始前半小时课程结束后半小时都可以进入教室
    if (de + 1800000 > now && now > ds - 1800000) {//进入教室
        btn.eq(0).removeClass('hidden');
    }
    //取消预约 ，
    if (ds > now + 7200000 && lesson.ClassModel && window.parent.CurrentUser.Type == '1') {//取消预约
        btn.eq(1).removeClass('hidden');
    }
    if (de < now) {
        btn.eq(2).removeClass('hidden');//视频回放
        if (lesson.CategoryCode < 100) {
            btn.eq(3).removeClass('hidden');//下载课件
        }
    }
    layer.closeAll();
    form.css({
        display: '',
        position: '',
        border: '',
        backgroundColor: '#fff'
    });
    webAbc.openDom(form, '500px');
    lessonLayer = layer.index;
}
function overschedule(e, evt) {
    return;
    if (window.parent.CurrentUser.Type == 1 || $('#layui-layer' + lessonLayer)[0]) return;
    var cplId = $(e).attr('data_id');
    var lesson = window.courseLesson.filter(function (item) { return item.CplId == cplId; })[0];
    initLesson(lesson);
    $('.courseform').css({
        'display': 'block',
        'position': 'absolute',
        'border': '1px solid #edc',
        'z-index': 1,
        'background-color': '#F1F1F1',
        'left': (window.event ? event.x : evt.clientX) + 5,
        'top': (window.event ? event.y : evt.clientY) + 3
    });
}
function outschedule(e) {
    return;
    if ($('#layui-layer' + lessonLayer)[0]) return;
    $('.courseform').css({
        'display': 'none'
    });
}


function initSchedule(date) {
    var calendar = $('.coursetable .fullcalender');
    calendar.html('');
    var div = $('<div class="temp"></div>');
    calendar.append(div);
    window.courseLesson = [];
    var addButtons = false;
    div.fullCalendar({
        locale: 'zh-cn',
        header: {
            left: '',
            center: 'title',
            right: ''
        },
        defaultDate: webAbc.dateParseString(date, true, false),
        editable: false,
        eventLimit: 10,
        events: GetScheduleData(0),
        eventAfterAllRender: function () {
            if (!addButtons) {
                //$('.fc-right', div).hide();
                var prev = $('<div class="play-btn btn_a">上一月</div>');
                var next = $('<div class="play-btn btn_b">下一月</div>');
                prev.click(function () {
                    div.fullCalendar('prev');
                });
                next.click(function () {
                    div.fullCalendar('next');
                });
                $('.fc-center', div).prepend(prev);
                $('.fc-center', div).append(next);

                addButtons = true;
                webAbc.autoAjustIframeHeight();
            }
        }
    });
}

//进入教室
function inClassRoom(lesson) {
    //debugger;
    webAbc.ajax({
        url: $.url + '/Gensee/ValidGensee',
        data: { CplId: lesson.CplId, CourseType: lesson.CourseType },
        success: function () {
            var height = 640, width = 1020;
            window.open($.url + '/Gensee/Gensee?CplId=' + lesson.CplId + '&CourseType=' + lesson.CourseType, 'coursewindow', 'height=' + height + ', width=' + width + ', top=' + ($(window).height - height) / 2 + ', left=' + ($(window).width - width) / 2 + ', toolbar=no, menubar=no, scrollbars=no, resizable=no, location=no, status=no');
        }
    });
};

//取消预约
function cancelYuyue(planId, categoryCode, fn) {
    //询问框
    //debugger;
    layer.confirm('您确定要取消该课程的预约？', {
        btn: ['确定', '取消'], //按钮
        offset: ['100px']
    }, function (index) {
        $.ajax({
            url: $.url + '/Member/CancelYuyue',
            dataType: 'json',
            type: 'post',
            data: { planId: planId, categoryCode: categoryCode },
            success: function (rel) {
                if (rel.Result[0].Code > 0) {
                    webAbc.showMessage(1, rel.Result[0].Message);
                    fn();
                } else {
                    webAbc.showMessage(2, rel.Result[0].Message);
                }
                layer.close(index);
            }
        });
    }, function () {
        layer.close(index);
    });
    var win = $('#layui-layer' + layer.index);
    if (win.length) {
        win.css({
            //top: parseFloat(win[0].style.top) - 105 + (window.parent.scrollY ? window.parent.scrollY > 275 ? 275 : window.parent.scrollY : 30) + 'px'
            top: window.top.scrollY + 'px'
        });
    }
};

//查看视频列表
function searchVideoAccess(cplId, coursetype) {
    $.ajax({
        url: $.url + '/Member/GetVideoAccess',
        data: { cplId: cplId, courseType: coursetype },
        dataType: 'JSON',
        type: 'post',
        success: function (res) {
            //debugger;
            if (res.Result == "") {
                webAbc.showMessage(1, '视频正在上传中，敬请期待！');
                return;
            }
            if (coursetype == "1") {
                layer.open({
                    type: 2,
                    title: '<img src="../../Content/img/logo_new.png"  style="float:left;" height="36px" />',
                    shadeClose: true,
                    shade: 0.5,
                    area: ['900px', '543px'],
                    content: [res.Result, 'no']//iframe的url
                });
            } else {
                var html = '', videoaccess = $('.videoaccess');
                var count = res.Result.length;
                if (count == 0) {
                    webAbc.showMessage(1, '视频正在上传中，敬请期待！');
                    return;
                }
                for (var i = 0; i < count ; i++) {
                    //   html += '<tr height="30px"><td>' + (i + 1) + '</td><td>' + res.Data[i].RecordStartTime + '</td><td><a href="' + $.url + res.Data[i].FilePath + '" target="_blank">' + res.Data[i].FileName + '</a></td></tr>';
                    html += '<tr height="30px"><td>' + (i + 1) + '</td><td><a class="playvideo" href="#" data-url="' + $.url + res.Result[i].DataUrl + '" >' + res.Result[i].RecordStartTime + '</a></td></tr>';
                }
                videoaccess.find('tbody tr').remove();
                videoaccess.find('tbody').append($(html));
                webAbc.openDom(videoaccess, '600px');
                videoaccess.find('tbody tr').find(".playvideo").click(function () {
                    var url = $(this).attr("data-url");
                    webAbc.OpenPage(url);
                });
            }
        }
    })
}

//查看课件
function searchLessonAccess(planId, lessonNo) {
    $.ajax({
        url: $.url + '/Member/GetLessonAccess',
        data: { CplId: planId },
        dataType: 'JSON',
        type: 'post',
        success: function (res) {
            var html = '',
                lessonaccess = $('.lessonaccess');
            for (var i = 0; i < res.TotalCount; i++) {
                html += '<tr height="30px"><td>' + (i + 1) + '</td><td>' + res.Data[i].LessonNo + '</td><td>' + res.Data[i].LessonName + '</td><td><a href="' + $.url + res.Data[i].FilePath + '" target="_blank">' + res.Data[i].FileName + '</a></td></tr>';
            }
            lessonaccess.find('tbody tr').remove();
            lessonaccess.find('tbody').append($(html));
            webAbc.openDom(lessonaccess,'600px');
        }
    })
}


$(() => {

    var memberType = window.parent.CurrentUser.Type;
    switch (memberType) {
        case 1:
            $('.courseform .btn').eq(1).removeClass('hidden');
            $('.hide1').addClass('hidden');
            break;
        case 3:
            $('.hide3').addClass('hidden');
            $('.studyvoice').addClass('hidden');
            break;
        default:
            $('.hide4').addClass('hidden');
            $('.studyvoice').addClass('hidden');
            break;
    }
    window.GetScheduleData =  function(month) {
        var data = [];
        var http = new XMLHttpRequest();
        http.open('get', $.url + '/Member/GetScheduleByMonth?month=' + month, false);
        http.send(null);
        var text = http.responseText;
        window.courseLesson = window.courseLesson || [];
        JSON.parse(text).Result.forEach(function (item) {
            if (item.CourseCount > 0) {
                if (window.courseLesson.filter(function (lesson) {
                    return lesson.CplId == item.CplId && lesson.CourseType == item.CourseType;
                }).length > 0) {
                    return;
                }
                window.courseLesson.push(item);
                data.push({
                    id: item.CplId,
                    title: item.BeginTime + (memberType == '3' ? ' ' + item.CategoryName : '~' + item.EndTime),
                    start: item.ClassDate + ' ' + item.BeginTime,
                    end: item.ClassDate + ' ' + item.EndTime
                });
            }
        });
        return data;
    }

    initSchedule(new Date());

});