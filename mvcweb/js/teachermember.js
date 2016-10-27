//弹出层位置调整
function OpenLayer(obj) {
    //layer.closeAll();
    layer.open(obj);
    var win = $('#layui-layer' + layer.index);
    win.css({
        //top: parseFloat(win[0].style.top) - 105 + (window.parent.scrollY ? window.parent.scrollY > 275 ? 275 : window.parent.scrollY : 30) + 'px'
        top: ($(window.top).height() - win.height()) / 2 + window.top.scrollY - 71
    });
}

//获取英文课程类型
function getEnCourseType(code) {
    return code == '1' ? 'one to one' : code == '6' ? 'one to six' : code >= 100 ? 'test class' : 'one to many'
}

//打开课表课次信息
var scheduleLesson, lessonLayer;
function initLesson(lesson) {
    var form = $('.courseform');
    form.find('#kclx').html(getEnCourseType(lesson.CategoryCode));
    form.find('#kcmc').html(lesson.CourseName);
    form.find('#skls').html(lesson.CategoryCode == '1' ? lesson.MemberCNName + (lesson.MemberEnName ? "(" + lesson.MemberEnName + ")" : "") : '/');
    form.find('#skms').html(lesson.ClassModel ? '自约上课' : '固定上课');
    form.find('#sksj').html(lesson.ClassDate + ' ' + lesson.BeginTime);
    //form.find('#sksj').html(lesson.ClassDate + ' ' + lesson.BeginTime + '~' + lesson.EndTime);
    form.find('#sksc').html(lesson.Clength + 'min');
    form.find('#kcjb').html(lesson.LevelName);
    form.find('#kc').html(lesson.LessonNo);
    form.find('.oper').addClass('hidden');
    if (lesson.CategoryCode >= 100) {
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

    form.find('.oper').removeClass('hidden');
    lesson.ClassModel ? form.find('#cancelyuyue').removeClass('hidden') : form.find('#cancelyuyue').addClass('hidden');
    var btn = form.find('.btn');
    if (!lessonLayer) {
        $('.courseform .btn').on('click', function () {
            var el = $(this),
                type = el.attr('type');

            switch (type) {
                case '1':
                    inClassRoom(scheduleLesson);
                    break;
                case '2':
                    cancelYuyue(scheduleLesson.CplId, scheduleLesson.CategoryCode, function () {
                        layer.closeAll();
                        initSchedule(new Date());
                    });
                    break;
                case '3'://review
                    webAbc.PlayGenSee(scheduleLesson);
                    //window.open('/Gensee/Gensee?CplId=' + cplId, '_blank');
                    break;
                case '4'://down
                    searchLessonAccess(scheduleLesson.CplId);
                    break;
            }
        })
    }
    var now = Date.parse(new Date()),
        ds = webAbc.stringParseDate(lesson.ClassDate + ' ' + lesson.BeginTime + ':00'),
        de = webAbc.stringParseDate(lesson.ClassDate + ' ' + lesson.EndTime + ':00');

    btn.addClass('hidden');
    if (de > now && now > ds - 1800000) {
        btn.eq(0).removeClass('hidden');
    }
    //取消预约
    //if (ds > now + 7200000 && lesson.ClassModel && window.parent.CurrentUser.Type == '1') {
    //    btn.eq(1).removeClass('hidden');
    //}
    if (de < now) {
        //视频回放
        //if (window.parent.CurrentUser.Type == '1') {
        //    btn.eq(2).removeClass('hidden');
        //}
       
    }
    if (lesson.CategoryCode < 100) {
        btn.eq(3).removeClass('hidden');
    }
    layer.closeAll();
    form.css({
        display: '',
        position: '',
        border: '',
        backgroundColor: '#fff'
    });
    OpenLayer({
        type: 1,
        title: 'Class Information',
        closeBtn: 1,
        shadeClose: true,
        shade: 0.1,
        area: ['360px', '330px'],
        content: form
    });
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

//取消预约
function cancelYuyue(planId, categoryCode, fn) {
    //询问框
    layer.confirm('您确定要取消该课程的预约？', {
        btn: ['确定', '取消'] //按钮
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
};

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
            OpenLayer({
                type: 1,
                title: '查看课件',
                closeBtn: 1,
                shadeClose: true,
                shade: 0.1,
                area: ['600px', 'auto'],
                content: lessonaccess //iframe的url
            });
        }
    })
}

//设置个人信息
function setSingleForm(obj) {
    var cls = $('.single input');
    cls[0].value = obj.CNName;
    cls[1].value = obj.ENName;
    $('.single input[name="sex"]')[obj.Sex == 0 ? 1 : 0].checked = true;
    cls[4].value = webAbc.dateParseString(obj.Birthday ? new Date(parseInt(obj.Birthday.substr(6, 12))) : new Date(), true, false);
    cls[5].value = obj.Email;
    $('#myphone').html(obj.Mobile);
    $('.single textarea')[0].value = obj.Voice;
    $('.single textarea')[1].value = obj.Address;
}

//进入教室
function inClassRoom(lesson) {
    ajax_({
        url: $.url + '/Gensee/ValidGensee',
        data: { CplId: lesson.CplId, CourseType: lesson.CourseType },
        success: function () {
            var height = 640, width = 1020;
           
            window.open($.url + '/Gensee/Gensee?CplId=' + lesson.CplId + '&CourseType=' + lesson.CourseType, 'coursewindow', 'height=' + height + ', width=' + width + ', top=' + ($(window).height - height) / 2 + ', left=' + ($(window).width - width) / 2 + ', toolbar=no, menubar=no, scrollbars=no, resizable=no, location=no, status=no');
        }
    });
   
    function ajax_(obj) {
        var fn = obj.success;
        obj.dataType = 'JSON';
        obj.type = obj.type || 'post';
        obj.url += (obj.url.indexOf('?') > 0 ? '&' : '?') + 'random=' + Math.random();
        obj.success = function (rel) {
            debugger;
            if (rel.IsSuccess) {
                if (typeof fn == 'function') {
                    fn(rel.Result);
                }
            } else if (rel.ErrCode == '1002') {
                window.parent.CurrentUser = null;
                window.parent.showLogin();
            }
            else {
                if (rel.ErrMsg.indexOf("开始前30") > 0)
                    webAbc.showMessage(2, "Live course not started yet! Please enter 30 minutes before the start of the course!");
                else {
                    webAbc.showMessage(2, " Live not generated！");
                }
            }
        }
        $.ajax(obj);
    }


};

var index = 1;
//更新课表
function initSchedule(date) {
    var calendar = $('.coursetable .fullcalender');
    calendar.html('');
    var div = $('<div class="temp"></div>')
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
                var today = $('<div class="play-btn">today</div>');
                var prev = $('<div class="play-btn btn_a"><</div>');
                var next = $('<div class="play-btn btn_b">></div>');
                today.click(function() {
                    div.fullCalendar('today');
                });
                prev.click(function () {
                    div.fullCalendar('prev');
                });
                next.click(function () {
                    div.fullCalendar('next');
                });
                $('.fc-center', div).prepend(prev);
                $('.fc-center', div).prepend(today);
                $('.fc-center', div).append(next);

                addButtons = true;
            }
        }
    });
}

$(document).ready(function () {
    var menu_a = $('.side-menu a');
    if (window.parent.$('iframe')[0]) {
        window.parent.$('iframe')[0].style.height = '860px';
        window.parent.scrollTo(0, 0);
    }

    var memberType = 3;
    $('.hide3').addClass('hidden');
    $('.studyvoice').addClass('hidden');

    $('#mycourse').click(function () {
        member.setActiveTab('courselist');
    })

    //修改手机号
    var uPhone = $('.phone');
    $('button', uPhone).click(function () {
        var el = $(this),
            els = $('input', uPhone),
            mobile = els[0].value,
            method = el.attr('method'), uuid;

        if (method == 'sendValid') {
            if (!mobile || mobile.length != 11) {
                webAbc.showMessage(2, '请输入正确的电话号码！');
                return;
            }
            webAbc.ajax({
                url: '/Home/SendValid',
                data: { mobile: mobile },
                success: function (rel) {
                    webAbc.showMessage(1, '短信发送成功，请注意查收！');
                }
            });
        } else {
            webAbc.ajax({
                url: $.url + '/Member/UpdatePhone',
                data: { phone: mobile, code: els[1].value },
                type: 'post',
                dataType: 'json',
                success: function (rel) {
                    webAbc.showMessage(1, '修改绑定手机号成功！');
                    $('#myphone').html(mobile);
                    els[0].value = '';
                    els[1].value = '';
                }
            });
        }
    });

    //获取课表数据
    window.GetScheduleData = function (month) {
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
                    title: item.BeginTime + ' ' + getEnCourseType(item.CategoryCode),
                    start: item.ClassDate + ' ' + item.BeginTime,
                    end: item.ClassDate + ' ' + item.EndTime
                });
            }
        });
        return data;
    }

    //获取课程 课次
    var GetClassPlan = function (obj, fn) {
        webAbc.ajax({
            url: $.url + '/Member/getclassplan',
            data: obj,
            success: function (result) {
                fn(obj, result);
            }
        });
    }

    var member = {
        //个人信息
        singleReady: function () {
            if (this.singleReadyStatu) return;
            var sig = $('.single');
            webAbc.ajax({
                url: $.url + '/Member/GetMember',
                type: 'post',
                dataType: 'json',
                success: function (rel) {
                    setSingleForm(rel);
                }
            });
            sig.find('input').keyup(function () {
                var el = $(this),
                    err = $(this.nextSibling),
                    name = el.attr('name'), value = el.val();

                el.removeClass('error');
                err.removeClass('error');
                if (value != '') {
                    if (name == 'name' && (!/^[\u4e00-\u9fa5]+$/.test(value) || value.length < 2 || value.length > 6)) {
                        err.addClass('error');
                        el.addClass('error');
                    } else if (name == 'sign' && (!/^[a-zA-Z.]+$/.test(value) || value.length < 2 || value.length > 20)) {
                        err.addClass('error');
                        el.addClass('error');
                    } else if (name == 'nick' && (!/^[\u4e00-\u9fa5\w]+$/.test(value) || value.length < 1 || value.length > 20)) {
                        err.addClass('error');
                        el.addClass('error');
                    } else if (name == 'email' && (!/^\w{1,16}@\w{1,10}[.]+\w{1,5}$/.test(value))) {
                        err.addClass('error');
                        el.addClass('error');
                    }
                }
            });
            sig.find('.btn').click(function () {
                var els = sig.find('input');
                if (els.hasClass('error')) return;
                if (!els[4].value) {
                    webAbc.showMessage(2, '生日不能为空！'); return;
                }
                if (!els[0].value) {
                    webAbc.showMessage(2, '中文名不能为空！'); return;
                }
                if (!els[1].value) {
                    webAbc.showMessage(2, '英文名不能为空！'); return;
                }

                $("iframe").contents().find("input[type='submit']").click();
                webAbc.ajax({
                    url: $.url + '/Member/SaveMember',
                    data: { CNName: els[0].value, ENName: els[1].value, Voice: $('.single textarea').eq(0).val(), Sex: $('.single input[name="sex"]')[0].checked ? 1 : 0, Birthday: els[4].value, Email: els[5].value, Address: $('.single textarea').eq(1).val() },
                    type: 'post',
                    dataType: 'json',
                    success: function (rel) {
                        //debugger;

                        window.parent.updateUser(els[1].value);
                        webAbc.showMessage(1, '个人信息修改成功！');
                        $("iframe").height("119px");
                    }
                });
            });
            this.singleReadyStatu = true;
        },
        singleReadyStatu: false,
        //修改密码
        safeReady: function () {
            if (this.safeReadyStatu) return;
            $('.safe input').keyup(function () {
                var el = $(this);
                el.removeClass('error');
                if (this.value && /^\w{6,20}$/.test(this.value)) {
                    var sInput = $('.safe input');
                    switch (this.name) {
                        case 'pwd':
                            return;
                        case 'newpwd':
                            if (this.value == sInput.eq(2).val()) {
                                sInput.eq(2).removeClass('error');
                                $('.safe .descibe').eq(1).removeClass('error');
                            } else {
                                sInput.eq(2).addClass('error');
                                $('.safe .descibe').eq(1).addClass('error');
                            }
                            return;
                        case 'confirmpwd':
                            if (this.value == sInput.eq(1).val()) {
                                $('.safe .descibe').eq(1).removeClass('error');
                                return;
                            } else {
                                $('.safe .descibe').eq(1).addClass('error');
                            }
                            break;
                    }
                }
                if (this.value) {
                    el.addClass('error');
                }
            });

            $('.safe button').click(function () {
                var el = this,
                    method = el.attributes.method.value,
                    data = '{';

                if (method == "updatePassword") {
                    var els = $('.safe input');
                    for (var i = 0; i < els.length; i++) {
                        if (els.eq(i).hasClass('error') || !els.eq(i).val())
                            return;
                    }
                    webAbc.ajax({
                        url: $.url + '/Member/UpdatePassword',
                        data: { pwd: els[0].value, newpwd: els[1].value },
                        type: 'post',
                        dataType: 'json',
                        success: function (rel) {
                            webAbc.showMessage(1, 'Password reset complete！');
                            els[0].value = '';
                            els[1].value = '';
                            els[2].value = '';
                        }
                    });
                }
            });
            this.safeReadyStatu = true;
        },
        safeReadyStatu: false,
        //修改绑定手机号
        phoneReady: function () {
        },
        //我的课程
        myCourseReady: function () {
            if (this.myCourseReadyStatu) return;
            var course, lesson, oldEl = null,
                container = $('.courselist'),
                mark = $('.classEvaluate .remark');


            if (memberType == 1) {
                webAbc.markStar({
                    container: mark, title: '教学质量', fn: function (mark) {
                        remark[0] = mark;
                    }
                })
                webAbc.markStar({
                    container: mark, title: '教师态度', fn: function (mark) {
                        remark[1] = mark;
                    }
                })
                webAbc.markStar({
                    container: mark, title: '课堂气氛', fn: function (mark) {
                        remark[2] = mark;
                    }
                })
            }
            else if (memberType == 3) {
                webAbc.markStar({
                    container: mark, title: 'Ability', fn: function (mark) {
                        remark[0] = mark;
                    }
                })
                webAbc.markStar({
                    container: mark, title: 'Attitude', fn: function (mark) {
                        remark[1] = mark;
                    }
                })
                webAbc.markStar({
                    container: mark, title: 'Mastery', fn: function (mark) {
                        remark[2] = mark;
                    }
                })
            }

            $('.classEvaluate .btntiny').on('click', function () {
                var action = $(this).attr('action'),
                    content = $('.evaluatecontent').val();
                if (action == 'close') {
                    $('.layui-layer-close').click();
                    return;
                }
                if (remark[0] == 0 || remark[1] == 0 || remark[2] == 0) {
                    webAbc.showMessage(2, "Please Rate！");
                    return;
                }
                if (!content) {
                    webAbc.showMessage(2, "Please write your review！");
                    return;
                }
                webAbc.ajax({
                    url: '/Member/CreateClassComment',
                    data: {
                        ClassId: course.ClassId, CplId: lesson.CplId, Content: $('.evaluatecontent').val(),
                        Rate1: remark[0], Rate2: remark[1], Rate3: remark[2], CommentType: course.CategoryCode
                    },
                    success: function () {
                        webAbc.showMessage(1, "Evaluation of Success！");
                        setTimeout(function () {
                            layer.closeAll();
                        }, 2000);
                    }
                })
            });
            var SetLessonComment = function (cplId, isPublic) {
                var container = $('.classEvaluate');
                $.ajax({
                    url: $.url + '/Member/GetLessonComment',
                    type: 'post',
                    data: { cplId: cplId, isPublic: isPublic },
                    dataType: 'json',
                    success: function (rel) {
                        if (rel.IsSuccess) {
                            if (rel.Result) {
                                remark = [rel.Result.Rate1, rel.Result.Rate2, rel.Result.Rate3];
                                $('.evaluatecontent').val(rel.Result.Content);
                                $('.btntiny', container).html('close');
                                $('.btntiny', container).attr('action', 'close');
                            } else {
                                $('.evaluatecontent').val('');
                                remark = [0, 0, 0];
                                $('.btntiny', container).html('submit');
                                $('.btntiny', container).attr('action', 'submit');
                            }
                            var imgArrray = $('.rate img');
                            $.each(remark, function (index, mark) {
                                for (var i = 0; i < 5; i++) {
                                    imgArrray[i + index * 5].src = i < mark ? $.url + '/Images/star-on.png' : $.url + '/Images/star-off.png';
                                }
                            })
                        }
                        else {
                            webAbc.showMessage(2, rel.ErrMsg);
                        }
                    }
                });
            }

            var getRowHtml = function (item, type) {
                //debugger;
                var teacherName = item.TeacherEnName || item.TeacherCNName || '暂无分配',
                    classtime = teacherName == '暂无分配' ? '-' : item.ClassDate + ' ' + item.BeginTime + '~' + item.EndTime;
                //var html = '<tr><td>' + item.LessonNo + '</td><td>' + teacherName + '</td><td title="' + item.ManagerName + '">' + (webAbc.getCharLength(item.ManagerName) < 18 ? (item.ManagerName || "") : item.ManagerName.substr(0, 14) + '..') + '</td><td>' + item.CurrStudentNum + '/' + item.MaxStudentNum + '</td><td>' + classtime + '</td><td>' + item.Clength + '</td><td>' + (item.LessonStatusName=="已完成"?("done"):("undone")) + '</td>';
                var html = '<tr><td>' + item.LessonNo + '</td><td>' + teacherName + '</td></td><td>' + item.CurrStudentNum + '/' + item.MaxStudentNum + '</td><td>' + classtime + '</td><td>' + item.Clength + '</td><td>' + (item.LessonStatusName == "已完成" ? ("done") : ("undone")) + '</td>';

                if (teacherName != '暂无分配')
                    switch (type) {
                        case '0':
                            html += '<td>';
                            if (memberType == '1' && course.ClassModel == 1 && course.CategoryCode != '1')
                                html += '<a class="btntiny" action="Yuyue">立即预约</a>';
                            html += '</td></tr>'
                            break;
                        case '1':
                            html += '<td><a class="btntiny" action="InClassRoom">Enter</a>';
                            if (memberType == '1' && course.ClassModel == 1)
                                html += '<a class="btntiny" action="Cancel">Cancel</a>';
                            if (course.CategoryCode < 100) {
                                html += '<a class="btntiny" action="LessonAccess" >File</a></td></tr>'
                            }
                            break;
                        case '2':
                            html += '<td>';
                            //if (course.CategoryCode < 100) {
                            //    html += '<a class="btntiny" action="LessonAccess" >file</a>';
                            //}
                            debugger;
                            if (memberType == '1' || (memberType == '3' && course.CategoryCode === 1)) {
                                html += '<a class="btntiny" action="Evaluate">Remark</a>'
                            }
                            html += '</td></tr>';
                            break;
                        default:
                            html += '</tr>';
                    }
                else {
                    html += (type == '3' ? '</tr>' : '<td></td></tr>');
                }
                return html;
            }

            var InitClassLesson = function (obj, lessons) { 
                if (obj.queryType == '3') {
                    $('.classhour th').eq(7).addClass('hidden');
                } else {
                    $('.classhour th').eq(7).removeClass('hidden');
                }
                webAbc.getPageSetting($('.classhour .page'), lessons, 10, function (items) {
                    var tb = $($('.classhour tbody')[0]);
                    $('tr', tb).remove();
                    items.forEach(function (item) {
                        var row = $(getRowHtml(item, obj.queryType));
                        tb.append(row);
                        row.find('.btntiny').click(function () {
                            var action = $(this).attr('action');
                            lesson = item;
                            switch (action) {
                                case 'InClassRoom':
                                    inClassRoom(item);
                                    break;
                                case 'LessonAccess':
                                    searchLessonAccess(item.CplId);
                                    break;
                                case 'Evaluate': {
                                    SetLessonComment(item.CplId, item.CategoryCode >= 100);
                                    debugger;
                                    OpenLayer({
                                        type: 1,
                                        title: '课程评价',
                                        closeBtn: 1,
                                        shadeClose: true,
                                        shade: 0.1,
                                        area: ['480px', '360px'],
                                        content: $('.classEvaluate')
                                    });
                                    break;
                                }
                            }
                        })
                    });
                    OpenLayer({
                        type: 1,
                        title: ' ',
                        area: '900px',
                        shadeClose: true,
                        //content: table
                        content: $('.classhour')
                    });
                }
                );

            }
            var searchClassLesson = function (type) {
                $('.classhour li').remove();
                $('#coursedetail').html("&nbsp;&gt;&nbsp;" + course.CourseName);
                GetClassPlan({ classType: 1, queryType: type, courseType: course.CourseType, classId: course.ClassId }, InitClassLesson);
            }
            var InitClassPlan = function (obj, courses) {
                webAbc.getPageSetting($('.page', container), courses, 10, function (items) {
                    var tb = $('tbody', container);
                    $('tr', tb).remove();
                    items.forEach(function (item) {
                        var row = $('<tr><td>' + item.CategoryName + '</td><td>' + item.LevelName + '</td><td>' + item.CourseName + '</td><td>' + (item.ClassModel ? '自约上课' : '固定开课') + '</td><td>'
                            + (item.ClassProgress * item.LessonCount) + '/' + item.LessonCount + '</td><td>'
                            + (obj.queryType == '0' && item.CategoryCode == 1 ? '<div class="btntiny" action="yuyue">发起预约</div>' : '')
                            + (item.CourseType == -1 ? '' : '<div class="btntiny" action="search">View Details</div>') + '</td></tr>');
                        tb.append(row);
                        row.find('.btntiny')
                            .click(function() {
                                var action = $(this).attr('action');
                                course = item;
                                //debugger;
                                switch (action) {
                                case 'search':
                                    searchClassLesson(obj.queryType);

                                    //otab.addClass('hidden');
                                    //otab = $('.classlesson');
                                    //otab.removeClass('hidden');
                                    break;
                                }
                            });
                    });

                });
            }
            if (this.myCourseReadyStatu) {
                $('.nav-tabs li', container).eq(3).click();
                return;
            }
            $('.nav-tabs li', container).click(function (queryType) {
                var je = $(this),
                    type = je.attr('data');

                oldEl && oldEl.removeClass('focus');
                oldEl = je;
                oldEl.addClass('focus');
                GetClassPlan({ classType: 0, queryType: type, courseType: 2 }, InitClassPlan);
            });
            $('.nav-tabs li', container).eq(2).click();
            this.myCourseReadyStatu = true;
        },
        myCourseReadyStatu: false,
        //我的课表
        myCourseListReady: function () {
            initSchedule(new Date());
        },
        //我的评价
        myEvaluateReady: function () {
            var container = $('.myevaluate'),
                li = $('.nav-tabs li', container),
                dataType = '0',
                course, vlesson,
                oldEvaluate = null;

            if (this.myEvaluateReadyStatu) {
                li.eq(0).click();
                return;
            }
            var getMarkHtml = function (remark) {
                var html = '';
                for (var i = 0; i < remark; i++) {
                    html += "<img src='" + $.url + "/Images/star-on.png'>";
                }
                var off = 5 - remark;
                for (var j = 0; j < off; j++) {
                    html += "<img src='" + $.url + "/Images/star-off.png'>";
                }
                return html;
            };

            var getEvaluate = function (cplid, coursetype, dataType) {
                webAbc.ajax({
                    url: '/Member/GetClassComment',
                    type: 'post',
                    dataType: 'json',
                    data: { type: dataType },
                    success: function (datas) {
                        var html = '';
                        webAbc.getPageSetting($('.page', container), datas.filter(function (item) {
                            return item.CourseType == coursetype && item.CplId == cplid;
                        }), 3, function (items) {
                            var html = '';
                            items.forEach(function (item) {
                                html += '<div class="evaluate_item">' +
                                    '<table><tr><td rowspan=2 class="evaluate_photo">' + (item.Logo ? '<img src="' + item.Logo + '" />' : '<img src="../../Images/member_default.png" />') + '</td><td>授课老师:' + item.Teacher + '</td><td>课程名称:' + item.CourseName + '</td></tr><tr><td colspan="2">' + (item.About || "") + '</td></tr><tr><td colspan=2>评价时间:' + webAbc.dateParseString(new Date(parseInt(item.CreateTime.substr(6)))) + '</td><td>评分:' + getMarkHtml(item.Remark) + '</td></tr><tr><td colspan=3 rowspan=2>' + item.Content + '</td></tr></table></div>';
                            })
                            html = html || '<div style="width:100%;height:80px;margin-top:100px;font-weight:bold;text-align:center;"><div style="margin-top:10px;">No Comment</div></div>';
                            $('.order-list', container).html(html);
                        });
                    }
                });

            };

            var couseContainer = $('.courselist_table_container', container);
            var lessonContainer = $('.classhour', container);
            var orderContainer = $('.orderlist', container);
            var title = $('.content_title', container);
            //订单、课程详情返回上一级
            title.on('click', function () {
                var aim = event.target;
                if (aim.localName != "label") {
                    return;
                }
                var num = $(aim).index();
                var text = title.find("label");
                debugger;
                switch (num) {
                    case 0: {
                        title.html(text.eq(0)[0].outerHTML);
                        if (couseContainer.hasClass('hidden')) {
                            couseContainer.removeClass('hidden');
                            orderContainer.addClass('hidden');
                            lessonContainer.addClass('hidden');
                        }
                        break;
                    }
                    case 1: {
                        title.html(text.eq(0)[0].outerHTML + " &gt; " + text.eq(1)[0].outerHTML);
                        if (lessonContainer.hasClass('hidden')) {
                            lessonContainer.removeClass('hidden');
                            orderContainer.addClass('hidden');
                        }
                        break;
                    }
                    default: break;
                }
               
               
                //title.html(text.length > 2 ? text[0] + '&gt;' + text[1] : text[0]);
                //if (orderContainer.hasClass('hidden')) {
                //    couseContainer.removeClass('hidden');
                //    lessonContainer.addClass('hidden');
                //} else {
                //    lessonContainer.removeClass('hidden');
                //    orderContainer.addClass('hidden');
                //}
            })
            //title.on('click', function () {
            //    var text = title.html().split('&gt;');
            //    title.html(text.length > 2 ? text[0] + '&gt;' + text[1] : text[0]);
            //    if (orderContainer.hasClass('hidden')) {
            //        couseContainer.removeClass('hidden');
            //        lessonContainer.addClass('hidden');
            //    } else {
            //        lessonContainer.removeClass('hidden');
            //        orderContainer.addClass('hidden');
            //    }
            //})
            GetClassPlan({ classType: 0, queryType: 2, courseType: 2 }, function (obj, courses) {
                courses = courses.filter(function (item) { return item.CourseType != -1 });
                webAbc.getPageSetting($('.page', couseContainer), courses, 10, function (items) {
                    var tb = $('tbody', couseContainer);
                    $('tr', tb).remove();
                    items.forEach(function (item) {
                        var row = $('<tr><td>' + item.CategoryName + '</td><td>' + item.LevelName + '</td><td>' + item.CourseName + '</td><td>' + (item.ClassModel ? '自约上课' : '固定开课') + '</td><td>'
                            + (item.ClassProgress * item.LessonCount) + '/' + item.LessonCount + '</td><td>'
                            + '<div class="btntiny" action="search">View Details</div></td></tr>');
                        tb.append(row);



                        row.find('.btntiny').click(function () {
                            couseContainer.addClass('hidden');
                            title.html('<label>Score</label> &gt; ' + '<label>'+ item.CourseName+'</label> ' );
                            course = item;
                            GetClassPlan({ classType: 1, queryType: 2, courseType: item.CourseType, classId: item.ClassId },
                                function (obj, lessons) {
                                    webAbc.getPageSetting($('.page', lessonContainer), lessons, 10, function (items) {
                                        var tb = $('tbody', lessonContainer);
                                        $('tr', tb).remove();
                                        //debugger;
                                        items.forEach(function (lesson) {
                                            var teacherName = lesson.TeacherEnName || lesson.TeacherCNName || '暂无分配',
                                                classtime = teacherName == '暂无分配' ? '-' : lesson.ClassDate + ' ' + lesson.BeginTime + '~' + lesson.EndTime;
                                            var html = '<tr><td>' + lesson.LessonNo + '</td><td>' + teacherName + '</td></td><td>' + lesson.CurrStudentNum + '/' + lesson.MaxStudentNum + '</td><td>' + classtime + '</td><td>' + lesson.Clength + '</td><td>' + lesson.LessonStatusName + '</td>';
                                            //var html = '<tr><td>' + lesson.LessonNo + '</td><td>' + teacherName + '</td><td title="' + lesson.ManagerName + '">' + (webAbc.getCharLength(lesson.ManagerName) < 18 ? (lesson.ManagerName || "") : lesson.ManagerName.substr(0, 14) + '..') + '</td><td>' + lesson.CurrStudentNum + '/' + lesson.MaxStudentNum + '</td><td>' + classtime + '</td><td>' + lesson.Clength + '</td><td>' + lesson.LessonStatusName + '</td>';
                                            if (dataType == '0' || (dataType == '1' && course.CategoryCode === 1)) {
                                                html += '<td><a class="btntiny" action="Evaluate">View score</a></td>'
                                            } else {
                                                html += '<td></td>'
                                            }
                                            html += '</td></tr>';
                                            var row = $(html);
                                            tb.append(row);
                                            row.find('.btntiny').click(function () {
                                                title.html('<label>Score</label> &gt; ' + '<label>' + item.CourseName + '</label> &gt; ' + '<label>' + 'lesson' + +lesson.LessonNo+ '</label> ');
                                                var action = $(this).attr('action');
                                                lessonContainer.addClass('hidden');
                                                vlesson = lesson;
                                                li.eq(0).click();
                                                orderContainer.removeClass('hidden');
                                                //OpenLayer({
                                                //    type: 1,
                                                //    title: item.CourseName,
                                                //    area: '600px',
                                                //    shadeClose: true,
                                                //    content: orderContainer
                                                //});
                                            })
                                        });
                                    })
                                    lessonContainer.removeClass('hidden');
                                });
                            //OpenLayer({
                            //    type: 1,
                            //    title: item.CourseName,
                            //    area: '900px',
                            //    shadeClose: true,
                            //    content: lessonContainer
                            //});
                        })
                        //row.find('.btntiny').click(function () {
                        //    couseContainer.addClass('hidden');
                        //    title.html('Score &gt; ' + item.CourseName);
                        //    course = item;
                        //    GetClassPlan({ classType: 1, queryType: 2, courseType: item.CourseType, classId: item.ClassId },
                        //        function (obj, lessons) {
                        //            webAbc.getPageSetting($('.page', lessonContainer), lessons, 10, function (items) {
                        //                var tb = $('tbody', lessonContainer);
                        //                $('tr', tb).remove();
                        //                items.forEach(function (lesson) {
                        //                    var teacherName = lesson.TeacherEnName || lesson.TeacherCNName || '暂无分配',
                        //                        classtime = teacherName == '暂无分配' ? '-' : lesson.ClassDate + ' ' + lesson.BeginTime + '~' + lesson.EndTime;
                        //                    var html = '<tr><td>' + lesson.LessonNo + '</td><td>' + teacherName + '</td><td title="' + lesson.ManagerName + '">' + (webAbc.getCharLength(lesson.ManagerName) < 18 ? (lesson.ManagerName || "") : lesson.ManagerName.substr(0, 14) + '..') + '</td><td>' + lesson.CurrStudentNum + '/' + lesson.MaxStudentNum + '</td><td>' + classtime + '</td><td>' + lesson.Clength + '</td><td>' + lesson.LessonStatusName + '</td>';
                        //                    if (dataType == '0' || (dataType == '1' && course.CategoryCode === 1)) {
                        //                        html += '<td><a class="btntiny" action="Evaluate">View score</a></td>'
                        //                    }
                        //                    html += '</td></tr>';
                        //                    var row = $(html);
                        //                    tb.append(row);
                        //                    row.find('.btntiny').click(function () {
                        //                        title.html('Score &gt; ' + course.CourseName + '&gt; lesson' + lesson.LessonNo);
                        //                        var action = $(this).attr('action');
                        //                        lessonContainer.addClass('hidden');
                        //                        vlesson = lesson;
                        //                        li.eq(0).click();
                        //                        orderContainer.removeClass('hidden');
                        //                    })
                        //                });
                        //            })
                        //            lessonContainer.removeClass('hidden');
                        //        });

                        //})
                    });
                });
            });

            li.on('click', function () {
                //debugger;
                oldEvaluate && oldEvaluate.removeClass('focus');
                oldEvaluate = $(this);
                oldEvaluate.addClass('focus');
                dataType = $(this).attr('data');
                getEvaluate(vlesson.CplId, course.CourseType, dataType);
            })
            this.myEvaluateReadyStatu = true;
        },
        myEvaluateReadyStatu: false,
        setActiveTab: function (action) {
            var tab = $('a[action="' + action + '"]'),
                li = tab.parent();

            if (oli) {
                oli.removeClass('user-info-nav');
                oli.removeClass('current-sub-nav');
                oli.addClass('message-center-nav');
                otab.addClass('hidden');
            }

            li.removeClass('message-center-nav');
            li.addClass('user-info-nav');
            li.addClass('current-sub-nav');

            oli = li;
            otab = $('.' + action);
            otab.removeClass('hidden');
            action == 'single' && member.singleReady();
            action == 'safe' && member.safeReady();
            action == 'phone' && member.phoneReady();//coursecard
            action == 'coursecard' && member.myCourseCardReady();
            action == 'courselist' && member.myCourseReady();
            action == 'coursetable' && member.myCourseListReady();
            action == 'orderform' && member.myOrderReady();
            action == 'myevaluate' && member.myEvaluateReady();
            action == 'myquestion' && member.myQuestionReady();
            action == 'myanswer' && member.myAnswerReady();
        }
    }

    var oli = null, otab = null, query = webAbc.getUrlQuery(window.location.search);
    menu_a.click(function () {
        var action = $(this).attr('action');
        member.setActiveTab(action);
    });

    //member.setActiveTab(query ? query['action'] : 'single');

    window.member = member;

})
