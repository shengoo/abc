//弹出层位置调整
'use strict';

function OpenLayer(obj) {
    //layer.closeAll();
    var layer = window.top.layer || window.layer;
    layer.open(obj);
    //var win = $('#layui-layer' + layer.index);
    //console.log($(window.top).height(), win.height(), window.top.scrollY)
    //if (win.length) {
    //    win.css({
    //        //top: parseFloat(win[0].style.top) - 105 + (window.parent.scrollY ? window.parent.scrollY > 275 ? 275 : window.parent.scrollY : 30) + 'px'
    //        //top: window.top.scrollY + 'px'
    //        top: ($(window.top).height() - win.height())/2 + window.top.scrollY - 71
    //    });
    //}
}

//打开课表课次信息
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
    if (lesson.CategoryCode >= 100) {
        //如果是一对多的话，则隐藏，其他情况显示
        form.find('tr').eq(1).addClass('hidden');
        form.find('tr').eq(7).addClass('hidden');
    } else {
        form.find('tr').eq(1).removeClass('hidden');
        form.find('tr').eq(7).removeClass('hidden');
    }
}
function openCourseLesson(e) {
    var cplId = $(e).attr('data_id');
    var lesson = scheduleLesson = window.courseLesson.filter(function (item) {
        return item.CplId == cplId;
    })[0];
    if (!lesson) {
        webAbc.showMessage(2, '课次已取消！');
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
                case '1':
                    //进入教室
                    inClassRoom(scheduleLesson);
                    break;
                case '2':
                    //取消预约
                    cancelYuyue(scheduleLesson.CplId, scheduleLesson.CategoryCode, function () {
                        layer.closeAll();
                        initSchedule(new Date());
                    });
                    break;
                case '3':
                    //视频回放
                    //  debugger;
                    //  webAbc.PlayGenSee(scheduleLesson);
                    searchVideoAccess(scheduleLesson.CplId, scheduleLesson.CourseType);
                    break;
                case '4':
                    //下载课件
                    searchLessonAccess(scheduleLesson.CplId);
                    break;
            }
        });
    }
    var now = Date.parse(new Date()),
        ds = webAbc.stringParseDate(lesson.ClassDate + ' ' + lesson.BeginTime + ':00'),
        //课程的开始时间
    de = webAbc.stringParseDate(lesson.ClassDate + ' ' + lesson.EndTime + ':00'); //课程的结束时间

    btn.addClass('hidden'); //课程开始前半小时课程结束后半小时都可以进入教室
    if (de + 1800000 > now && now > ds - 1800000) {
        //进入教室
        btn.eq(0).removeClass('hidden');
    }
    //取消预约 ，
    if (ds > now + 7200000 && lesson.ClassModel && window.parent.CurrentUser.Type == '1') {
        //取消预约
        btn.eq(1).removeClass('hidden');
    }
    if (de < now) {
        btn.eq(2).removeClass('hidden'); //视频回放
        if (lesson.CategoryCode < 100) {
            btn.eq(3).removeClass('hidden'); //下载课件
        }
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
        title: '课次详情',
        closeBtn: 1,
        shadeClose: true,
        shade: 0.1,
        area: ['360px', '330px'],
        offset: ['150px'],
        content: form
    });
    lessonLayer = layer.index;
}
function overschedule(e, evt) {
    return;
    if (window.parent.CurrentUser.Type == 1 || $('#layui-layer' + lessonLayer)[0]) return;
    var cplId = $(e).attr('data_id');
    var lesson = window.courseLesson.filter(function (item) {
        return item.CplId == cplId;
    })[0];
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
            success: function success(rel) {
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
        success: function success(res) {
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
                    content: [res.Result, 'no'] //iframe的url
                });
            } else {
                    var html = '',
                        videoaccess = $('.videoaccess');
                    var count = res.Result.length;
                    if (count == 0) {
                        webAbc.showMessage(1, '视频正在上传中，敬请期待！');
                        return;
                    }
                    for (var i = 0; i < count; i++) {
                        //   html += '<tr height="30px"><td>' + (i + 1) + '</td><td>' + res.Data[i].RecordStartTime + '</td><td><a href="' + $.url + res.Data[i].FilePath + '" target="_blank">' + res.Data[i].FileName + '</a></td></tr>';
                        html += '<tr height="30px"><td>' + (i + 1) + '</td><td><a class="playvideo" href="#" data-url="' + $.url + res.Result[i].DataUrl + '" >' + res.Result[i].RecordStartTime + '</a></td></tr>';
                    }
                    videoaccess.find('tbody tr').remove();
                    videoaccess.find('tbody').append($(html));
                    OpenLayer({
                        type: 1,
                        title: '视频录像',
                        closeBtn: 1,
                        shadeClose: true,
                        shade: 0.1,
                        area: ['600px', 'auto'],
                        content: videoaccess //iframe的url
                    });
                    videoaccess.find('tbody tr').find(".playvideo").click(function () {
                        var url = $(this).attr("data-url");
                        layer.open({
                            type: 2,
                            title: '<img src="../../Content/img/logo_new.png"  style="float:left;" height="36px" />',
                            shadeClose: true,
                            shade: 0.5,
                            area: ['900px', '600px'],
                            content: [url, 'no'] //iframe的url
                        });
                    });
                }
        }
    });
}

//查看课件
function searchLessonAccess(planId, lessonNo) {
    $.ajax({
        url: $.url + '/Member/GetLessonAccess',
        data: { CplId: planId },
        dataType: 'JSON',
        type: 'post',
        success: function success(res) {
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
    });
}

//设置个人信息
function setSingleForm(obj) {
    if (!obj) {
        return;
    }
    if ($('.single').length) {
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
}

//进入教室
function inClassRoom(lesson) {
    //debugger;
    webAbc.ajax({
        url: $.url + '/Gensee/ValidGensee',
        data: { CplId: lesson.CplId, CourseType: lesson.CourseType },
        success: function success() {
            var height = 640,
                width = 1020;
            window.open($.url + '/Gensee/Gensee?CplId=' + lesson.CplId + '&CourseType=' + lesson.CourseType, 'coursewindow', 'height=' + height + ', width=' + width + ', top=' + ($(window).height - height) / 2 + ', left=' + ($(window).width - width) / 2 + ', toolbar=no, menubar=no, scrollbars=no, resizable=no, location=no, status=no');
        }
    });
};

var index = 1;
//更新课表
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
        eventAfterAllRender: function eventAfterAllRender() {
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

$(document).ready(function () {
    var menu_a = $('.side-menu a');
    if (window.parent.$('iframe')[0]) {
        window.parent.$('iframe')[0].style.height = '860px';
        window.parent.scrollTo(0, 0);
    }
    //course table
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

    // course list
    $('#mycourse').find("label").click(function () {
        member.setActiveTab('courselist');
    });

    //修改手机号
    var uPhone = $('.phone');
    $('button', uPhone).click(function () {
        var el = $(this),
            els = $('input', uPhone),
            mobile = els[0].value,
            method = el.attr('method'),
            uuid;

        if (method == 'sendValid') {
            if (!mobile || mobile.length != 11) {
                webAbc.showMessage(2, '请输入正确的电话号码！');
                return;
            }
            //webAbc.ajax({
            //    url: '/Home/SendValid',
            //    data: { mobile: mobile },
            //    success: function (rel) {
            //        webAbc.showMessage(1, '短信发送成功，请注意查收！');
            //    }
            //});
            if (!parseInt(el.html())) {
                webAbc.ajax({
                    url: '/Home/SendValid',
                    data: { mobile: mobile },
                    success: function success(rel) {
                        var times = 60;
                        webAbc.showMessage(1, '短信发送成功，请注意查收！');
                        var siv = setInterval(function () {
                            if (times == 0) {
                                el.html('获取验证码');
                                clearInterval(siv);
                                return;
                            }
                            el.html(times-- + '秒后重新发送');
                        }, 1000);
                    }
                });
            }
        } else {
            webAbc.ajax({
                url: $.url + '/Member/UpdatePhone',
                data: { phone: mobile, code: els[1].value },
                type: 'post',
                dataType: 'json',
                success: function success(rel) {
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
                    title: item.BeginTime + (memberType == '3' ? ' ' + item.CategoryName : '~' + item.EndTime),
                    start: item.ClassDate + ' ' + item.BeginTime,
                    end: item.ClassDate + ' ' + item.EndTime
                });
            }
        });
        return data;
    };

    //我的提问 - 答案
    var setMyAnswer = function setMyAnswer(id) {
        var list = $('.order-list', otab);
        $('.questionanswer_item', list).remove();
        webAbc.ajax({
            url: $.url + '/Member/GetQuestionAnswer',
            data: { Id: id },
            success: function success(results) {
                if (results.length == 0) return;
                var hasAccept = results[0].IsAccept == 1;
                webAbc.getPageSetting($('.page', otab), results, 6, function (answers) {
                    $('.questionanswer_item', list).remove();
                    answers.forEach(function (answer) {
                        var liHtml = '<div class="questionanswer_item"><table><tr><td rowspan="2" style="width:55px"><img width="50" height="50" style="margin:5px;" src="' + ($.url + answer.Logo || $.url + "/Images/member_default.png") + '" /></td><td style="width:120px">' + answer.UserName + '</td><td>' + (hasAccept ? answer == results[0] ? '最佳答案' : '' : '<a class="accept">采纳</a>') + '</td></tr><tr><td colspan="2">' + webAbc.dateParseString(new Date(parseInt(answer.CreateTime.substr(6)))) + '</td></tr><tr><td colspan="3"><div class="content">' + answer.Content + '</div></td></tr></table></div>';
                        var li = $(liHtml);
                        list.append(li);
                        li.find('.accept').click(function () {
                            webAbc.ajax({
                                url: $.url + '/Member/SetQuestionAnswer',
                                data: { Id: answer.AnswerId },
                                success: function success(rel) {
                                    $('.back', otab).click();
                                }
                            });
                        });
                    });
                });
            }
        });
    };

    //提问
    var refreshQuestion = function refreshQuestion() {
        var container = $('.myquestion');
        webAbc.ajax({
            url: '/Member/GetQuestion',
            success: function success(results) {
                var list = $('.order-list', container);
                if (results.length == 0) {
                    list.addClass('hidden');
                    $('#question_sdk').removeClass('hidden');
                } else {
                    $('#question_sdk').addClass('hidden');
                    list.removeClass('hidden');
                    webAbc.getPageSetting($('.page', container), results, 5, function (items) {
                        $('.question_item', list).remove();
                        items.forEach(function (item) {
                            var li = $('<div class="question_item"><table><tr><td rowspan="2" style="width:55px"><img width="50" height="50" style="margin:5px;" src="' + (window.parent.CurrentUser.Logo || $.url + "/Images/member_default.png") + '" /></td><td>' + webAbc.dateParseString(new Date(parseInt(item.CreateTime.substr(6)))) + '</td></tr><tr><td> <a class="searchAnswer">' + item.AnswerNum + '个回复</a></td></tr><tr><td colspan="2"><div class="content">' + item.Content + '</div></td></tr></table></div>');
                            list.append(li);
                            li.find('.searchAnswer').click(function () {
                                otab.addClass('hidden');
                                otab = $('.questionanswer');
                                otab.removeClass('hidden');
                                $('#questionanswer', otab).html(item.Content);
                                setMyAnswer(item.AskId);
                            });
                        });
                    });
                }
            }
        });
    };

    //获取课程 课次
    var GetClassPlan = function GetClassPlan(obj, fn) {
        webAbc.ajax({
            url: $.url + '/Member/getclassplan',
            data: obj,
            success: function success(result) {
                fn(obj, result);
            }
        });
    };

    var member = {
        //个人信息
        singleReady: function singleReady() {
            if (this.singleReadyStatu) return;
            var sig = $('.single');
            webAbc.ajax({
                url: $.url + '/Member/GetMember',
                type: 'post',
                dataType: 'json',
                success: function success(rel) {
                    setSingleForm(rel);
                }
            });
            sig.find('input').keyup(function () {
                var el = $(this),
                    err = $(this.nextSibling),
                    name = el.attr('name'),
                    value = el.val();

                el.removeClass('error');
                err.removeClass('error');
                if (value != '') {
                    //if (name == 'name' && (!/^[\u4e00-\u9fa5]+$/.test(value) || value.length < 2 || value.length > 6)) {
                    if (name == 'name' && (!/^\S[a-zA-Z\s\d\u4e00-\u9fa5]+\S$/.test(value) || value.length < 2 || value.length > 6)) {
                        err.addClass('error');
                        el.addClass('error');
                    } else if (name == 'sign' && (!/^[a-zA-Z.]+$/.test(value) || value.length < 2 || value.length > 20)) {
                        err.addClass('error');
                        el.addClass('error');
                    } else if (name == 'nick' && (!/^[\u4e00-\u9fa5\w]+$/.test(value) || value.length < 1 || value.length > 20)) {
                        err.addClass('error');
                        el.addClass('error');
                    } else if (name == 'email' && !/^\w{1,16}@\w{1,10}[.]+\w{1,5}$/.test(value)) {
                        err.addClass('error');
                        el.addClass('error');
                    }
                }
            });
            sig.find('.btn').click(function () {
                var els = sig.find('input');
                if (els.hasClass('error')) {
                    webAbc.showMessage(2, '请输入正确的用户信息！');
                    return;
                }
                if (!els[4].value) {
                    webAbc.showMessage(2, '生日不能为空！');return;
                }
                if (!els[0].value) {
                    webAbc.showMessage(2, '中文名不能为空！');return;
                }
                if (!els[1].value) {
                    webAbc.showMessage(2, '英文名不能为空！');return;
                }

                $("iframe").contents().find("input[type='submit']").click();
                webAbc.ajax({
                    url: $.url + '/Member/SaveMember',
                    data: { CNName: els[0].value, ENName: els[1].value, Voice: $('.single textarea').eq(0).val(), Sex: $('.single input[name="sex"]')[0].checked ? 1 : 0, Birthday: els[4].value, Email: els[5].value, Address: $('.single textarea').eq(1).val() },
                    type: 'post',
                    dataType: 'json',
                    success: function success(rel) {
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
        safeReady: function safeReady() {
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
                        if (els.eq(i).hasClass('error') || !els.eq(i).val()) return;
                    }
                    webAbc.ajax({
                        url: $.url + '/Member/UpdatePassword',
                        data: { pwd: els[0].value, newpwd: els[1].value },
                        type: 'post',
                        dataType: 'json',
                        success: function success(rel) {
                            webAbc.showMessage(1, '密码修改成功！');
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
        phoneReady: function phoneReady() {},
        //我的卡次
        myCourseCardReady: function myCourseCardReady() {
            var container = $('.coursecard');
            webAbc.ajax({
                url: $.url + '/Member/GetMyCourseCard',
                type: 'post',
                data: Math.random(),
                dataType: 'json',
                success: function success(course) {
                    var html = '';
                    $.each(course, function (i, item) {
                        html += '<tr><td class="opp">' + item.RowNumber + '</td><td>' + item.CardNo + '</td><td>' + item.CategoryName + '</td><td>' + item.CardName + '</td><td>' + item.CourseName + '</td><td>' + item.CourseType + '</td><td>' + item.CardTotalNum + '</td><td>' + item.CardRemainderNum + '</td><td>' + item.ValidPeriod || '' + '</td></tr>';
                    });
                    webAbc.getPageSetting($('.page', container), course, 10, function (items) {
                        var html = '';
                        items.forEach(function (item) {
                            var index = course.indexOf(item);
                            html += '<tr' + (index % 2 ? ' class="odd"' : '') + '><td class="opp">' + item.RowNumber + '</td><td>' + item.CardNo + '</td><td>' + item.CategoryName + '</td><td>' + item.CardName + '</td><td>' + item.CourseName + '</td><td>' + item.CourseType + '</td><td>' + item.CardTotalNum + '</td><td>' + item.CardRemainderNum + '</td><td>' + item.ValidPeriod || '' + '</td></tr>';
                        });
                        $('.coursecardbody').html(html);
                    });
                }
            });
        },
        myCourseReadyStatu: false,
        //我的课程
        myCourseReady: function myCourseReady() {
            console.log('myCourseReady');
            if (this.myCourseReadyStatu) return;
            var course,
                lesson,
                oldEl = null,
                remark = [0, 0, 0],
                container = $('.courselist'),
                mark = $('.classEvaluate .remark');
            var oldbtn = null;

            if (memberType == 1) {
                webAbc.markStar({
                    container: mark, title: '教学质量', fn: function fn(mark) {
                        remark[0] = mark;
                    }
                });
                webAbc.markStar({
                    container: mark, title: '教师态度', fn: function fn(mark) {
                        remark[1] = mark;
                    }
                });
                webAbc.markStar({
                    container: mark, title: '课堂气氛', fn: function fn(mark) {
                        remark[2] = mark;
                    }
                });
            } else if (memberType == 3) {
                webAbc.markStar({
                    container: mark, title: '学习能力', fn: function fn(mark) {
                        remark[0] = mark;
                    }
                });
                webAbc.markStar({
                    container: mark, title: '学习态度', fn: function fn(mark) {
                        remark[1] = mark;
                    }
                });
                webAbc.markStar({
                    container: mark, title: '掌握程度', fn: function fn(mark) {
                        remark[2] = mark;
                    }
                });
            }

            $('.classEvaluate .btntiny').on('click', function () {
                var action = $(this).attr('action'),
                    content = $('.evaluatecontent').val();
                if (action == 'close') {
                    $('.layui-layer-close').click();
                    return;
                }
                if (remark[0] == 0 || remark[1] == 0 || remark[2] == 0) {
                    webAbc.showMessage(2, "请打分！");
                    return;
                }
                if (!content) {
                    webAbc.showMessage(2, "请写上您的评价！");
                    return;
                }
                webAbc.ajax({
                    url: '/Member/CreateClassComment',
                    data: {
                        ClassId: course.ClassId, CplId: lesson.CplId, Content: $('.evaluatecontent').val(),
                        Rate1: remark[0], Rate2: remark[1], Rate3: remark[2], CommentType: course.CategoryCode
                    },
                    success: function success() {
                        webAbc.showMessage(1, "评价成功！");
                        setTimeout(function () {
                            layer.closeAll();
                        }, 2000);
                    }
                });
            });
            var SetLessonComment = function SetLessonComment(cplId, isPublic) {
                var container = $('.classEvaluate');
                $.ajax({
                    url: $.url + '/Member/GetLessonComment',
                    type: 'post',
                    data: { cplId: cplId, isPublic: isPublic },
                    dataType: 'json',
                    success: function success(rel) {
                        if (rel.IsSuccess) {
                            if (rel.Result) {
                                remark = [rel.Result.Rate1, rel.Result.Rate2, rel.Result.Rate3];
                                $('.evaluatecontent').val(rel.Result.Content);
                                $('.btntiny', container).html('关闭');
                                $('.btntiny', container).attr('action', 'close');
                            } else {
                                $('.evaluatecontent').val('');
                                remark = [0, 0, 0];
                                $('.btntiny', container).html('提交');
                                $('.btntiny', container).attr('action', 'submit');
                            }
                            var imgArrray = $('.rate img');
                            $.each(remark, function (index, mark) {
                                for (var i = 0; i < 5; i++) {
                                    imgArrray[i + index * 5].src = i < mark ? $.url + '/Images/star-on.png' : $.url + '/Images/star-off.png';
                                }
                            });
                        } else {
                            webAbc.showMessage(2, rel.ErrMsg);
                        }
                    }
                });
            };
            var getRowHtml = function getRowHtml(item, type) {
                var teacherName = item.TeacherEnName || item.TeacherCNName || '暂无分配',
                    classtime = teacherName == '暂无分配' ? '-' : item.ClassDate + ' ' + item.BeginTime + '~' + item.EndTime;
                var html = '<tr><td>' + item.LessonNo + '</td><td>' + teacherName + '</td><td title="' + item.ManagerName + '">' + (webAbc.getCharLength(item.ManagerName) < 18 ? item.ManagerName || "" : item.ManagerName.substr(0, 14) + '..') + '</td><td>' + item.CurrStudentNum + '/' + item.MaxStudentNum + '</td><td>' + classtime + '</td><td>' + item.Clength + '</td><td>' + item.LessonStatusName + '</td>';
                if (teacherName != '暂无分配') switch (type) {
                    case '0':
                        html += '<td>';
                        if (memberType == '1' && course.ClassModel == 1 && course.CategoryCode != '1') html += '<a class="btntiny" action="Yuyue">立即预约</a>';
                        html += '</td></tr>';
                        break;
                    case '1':
                        html += '<td style="width:200px;"><a class="btntiny" action="InClassRoom">进入教室</a>';
                        if (memberType == '1' && course.ClassModel == 1) html += '<a class="btntiny" action="Cancel">取消约课</a>';
                        if (course.CategoryCode < 100) {
                            html += '<a class="btntiny" action="LessonAccess" >课件</a></td></tr>';
                        }
                        break;
                    case '2':
                        html += '<td>';
                        if (course.CategoryCode < 100) {
                            html += '<a class="btntiny" action="LessonAccess" >课件</a>';
                        }
                        if (memberType == '1' || memberType == '3' && course.CategoryCode === 1) {
                            html += '<a class="btntiny" action="Evaluate">评价</a>';
                        }
                        html += '</td></tr>';
                        break;
                    default:
                        html += '</tr>';
                } else {
                    html += type == '3' ? '</tr>' : '<td></td></tr>';
                }
                return html;
            };
            var InitClassLesson = function InitClassLesson(obj, lessons) {
                if (obj.queryType == '3') {
                    $('.classhour th').eq(7).addClass('hidden');
                } else {
                    $('.classhour th').eq(7).removeClass('hidden');
                }
                webAbc.getPageSetting($('.classhour .page'), lessons, 10, function (items) {
                    var tb = $($('.classhour tbody')[0]);
                    //var table =
                    //    $('<div class="classhour"><table class="course_yueke extb">' +
                    //        '<thead>' +
                    //        '<tr class="odd add"><th>课次</th><th style="width: 113px;">上课老师</th>' +
                    //        '<th style="width: 113px;">学管师</th><th>已约/可约</th><th>上课时间</th>' +
                    //        '<th>时长</th><th>状态</th><th>操作</th></tr></thead>' +
                    //        '<tbody></tbody></table><div class="page"></div></div>');

                    //if (obj.queryType == '3') {
                    //    $('th', table).eq(7).remove();
                    //}
                    //var tb = $('tbody', table);
                    $('tr', tb).remove();
                    items.forEach(function (item) {
                        var row = $(getRowHtml(item, obj.queryType));
                        row.addClass(items.indexOf(item) % 2 ? 'odd' : 'opp');
                        tb.append(row);console.log($('.btntiny', row));
                        row.find('.btntiny').click(function () {
                            //$('.btntiny',row).click(function () {
                            var action = $(this).attr('action');
                            lesson = item;
                            switch (action) {
                                case 'Yuyue':
                                    // alert(11111111);
                                    $.ajax({
                                        url: $.url + '/Member/InsertCourse',
                                        dataType: 'json',
                                        type: 'post',
                                        data: { planId: item.CplId, classId: item.ClassId },
                                        success: function success(rel) {
                                            if (rel != null) {
                                                if (rel.Result[0].Code > 0) {
                                                    webAbc.showMessage(1, rel.Result[0].Message);
                                                    member.setActiveTab('courselist');
                                                    //oldEl.click();
                                                    oldbtn.click();
                                                } else {
                                                    webAbc.showMessage(2, rel.Result[0].Message);
                                                }
                                            } else {
                                                webAbc.showMessage(2, "访问服务器异常，请重试！");
                                            }
                                        }
                                    });
                                    break;
                                case 'Cancel':
                                    cancelYuyue(item.CplId, item.CategoryCode, function () {
                                        member.setActiveTab('courselist');
                                        oldEl.click();
                                    });
                                    break;
                                case 'Evaluate':
                                    SetLessonComment(item.CplId, item.CategoryCode >= 100);
                                    OpenLayer({
                                        type: 1,
                                        title: '课程评价',
                                        closeBtn: 1,
                                        shadeClose: true,
                                        shade: 0,
                                        area: ['480px', '360px'],
                                        content: $('.classEvaluate')
                                    });
                                    break;
                                case 'InClassRoom':
                                    console.log('InClassRoom');
                                    // debugger;
                                    inClassRoom(item);
                                    break;
                                case 'LessonAccess':
                                    searchLessonAccess(item.CplId);
                                    break;
                            }
                        });
                    });
                    OpenLayer({
                        type: 1,
                        title: ' ',
                        area: '900px',
                        shadeClose: true,
                        //content: table
                        content: $('.classhour')
                    });
                });
            };
            var searchClassLesson = function searchClassLesson(type) {
                $('.classhour li').remove();
                $('#coursedetail').html("&nbsp;&gt;&nbsp;" + course.CourseName);
                GetClassPlan({ classType: 1, queryType: type, courseType: course.CourseType, classId: course.ClassId }, InitClassLesson);
            };
            var InitClassPlan = function InitClassPlan(obj, courses) {
                webAbc.getPageSetting($('.page', container), courses, 10, function (items) {
                    var tb = $('tbody', container);
                    $('tr', tb).remove();
                    //debugger;
                    var fs = $(".courselist .nav-tabs li").eq(1).hasClass("focus");
                    items.forEach(function (item) {
                        var index = courses.indexOf(item);
                        //var row = $('<tr><td>' + item.CategoryName + '</td><td>' + item.LevelName + '</td><td>' + item.CourseName + '</td><td>' + (item.ClassModel ? '自约上课' : '固定开课') + '</td><td>'
                        //    + (item.ClassProgress * item.LessonCount) + '/' + item.LessonCount + '</td><td>'
                        //    + (obj.queryType == '0' && item.CategoryCode == 1 ? '<div class="btntiny flt" action="yuyue">发起预约</div>' : '')
                        //    + (item.CourseType == -1 ? '' : '<div class="btntiny flt" action="search">查看详情</div>') + '</td></tr>');
                        var row = $('<tr class=' + (index % 2 ? 'odd' : 'opp') + '><td>' + item.CategoryName + '</td><td>' + item.LevelName + '</td><td>' + item.CourseName + '</td><td>' + (item.ClassModel ? '自约上课' : '固定开课') + '</td><td>' + item.FinishCount + '/' + item.LessonCount + '</td><td style="width:200px;">' + (obj.queryType == '0' && item.CategoryCode == 1 ? '<div class="btntiny " action="yuyue">发起预约</div>' : '') + (item.CourseType == -1 ? '' : (obj.queryType == '0' && item.CategoryCode == 1 ? '<div class="btntiny " action="search">查看详情</div>' : '<div class="btntiny " action="search">' + (fs ? "发起预约" : "查看详情") + '</div>') + '</td></tr>'));

                        tb.append(row);
                        row.find('.btntiny').click(function () {
                            var action = $(this).attr('action');
                            course = item;
                            switch (action) {
                                case 'search':
                                    searchClassLesson(obj.queryType);
                                    oldbtn = $(this);
                                    otab.addClass('hidden');
                                    otab = $('.classlesson');
                                    otab.removeClass('hidden');
                                    break;
                                case 'yuyue':
                                    //    debugger;
                                    var title = $('.courseyuyue .title');
                                    title.html('<a style="cursor:pointer">我的课程</a>&gt;<a>' + course.CategoryName + '&nbsp;-&nbsp;' + item.CourseName + '<a>');
                                    title.find('a').eq(0).click(function () {
                                        member.setActiveTab('courselist');
                                    });
                                    member.myCapacityReady(course.ClassId, course.CourseId);
                                    otab.addClass('hidden');
                                    otab = $('.courseyuyue');
                                    otab.removeClass('hidden');
                                    break;
                            }
                        });
                    });

                    webAbc.autoAjustIframeHeight();
                });
            };
            if (this.myCourseReadyStatu) {
                $('.nav-tabs li', container).eq(0).click();
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
            $('.nav-tabs li', container).eq(0).click();
            this.myCourseReadyStatu = true;
        },
        myCourseReadyStatu: false,
        //智能约课
        teacherIds: '',
        myCapacityReady: function myCapacityReady(classId, courseId) {
            var me = this,
                container = $('.courseyuyue'),

            //container = $('.courseyuyue').clone(),
            mode = '1',
                times = 1,
                bookDate = null,
                beginTime = null,
                teacherObj = $('div[action="selectTeacher"]', container),
                modesEl = container.find('.selbtn[action="mode"]'),
                timesEl = container.find('.selbtn[action="times"]'),
                html = '';

            var oEl = null,
                tEl = null,
                el = null;
            webAbc.ajax({
                url: '/Member/GetClassTeacher',
                data: { classId: classId },
                success: function success(teachers) {
                    var grid = $('.win_grid');
                    var pageFunc = function pageFunc(items) {
                        var table = $('.win_table tbody', grid);
                        $('tr', table).remove();
                        var str = '';
                        items.forEach(function (item) {
                            var row = $('<tr data=' + item.Id + ' data_name="' + item.Name + '"><td><img src="' + (item.Logo || '../../Images/member_default.png') + '" width="64px" /></td><td>' + (item.EnName || "") + '</td><td>' + (item.Signature || "") + '</td><td><div class="btn" style="width:80px;" >选择</div></td></tr>');
                            //var row = $('<tr data=' + item.Id + ' data_name="' + item.Name + '"><td><img src="' + (item.Logo || '../../Images/member_default.png') + '" width="64px" /></td><td>' + (item.Name || "") + '</td><td>' + (item.EnName || "") + '</td><td>' + (item.Signature || "") + '</td><td><div class="btn" style="width:80px;" >选择</div></td></tr>');
                            var func = function func() {
                                //debugger;
                                me.teacherIds = item.Id;
                                teacherObj.html(item.Name);
                                layer.close(layer.index);
                                el && el.click();
                            };
                            row.find('.btn').click(func);
                            table.append(row);
                        });
                    };
                    pageFunc(teachers);
                    grid.find('.input').bind('keyup', function () {
                        var text = this.value;
                        pageFunc(teachers.filter(function (item) {
                            return item.Name.indexOf(text) > -1 || item.EnName.indexOf(text) > -1 || !text;
                        }));
                    });
                }
            });
            //if (me.myCapacityReadyStatu) {
            //    //  debugger;
            //    teacherObj.html('');

            //    //modesEl.eq(0).click();
            //    //timesEl.eq(0).click();

            //    me.teacherIds = '';
            //    $('.classdate', container).removeClass('selectdate');
            //    $('.choicetime', container).html('');

            //    return;
            //}
            var clear = function clear() {
                //   debugger;
                teacherObj.html('');
                modesEl.eq(0).click();
                timesEl.eq(0).click();
                me.teacherIds = '';
                $('.classdate', container).removeClass('selectdate');
                $('.choicetime', container).html('');
            };
            teacherObj.on('click', function () {
                OpenLayer({
                    type: 1,
                    title: '选择老师',
                    closeBtn: 1,
                    shadeClose: true,
                    shade: 0.1,
                    area: ['720px', '540px'],
                    content: $('.win_grid')
                });
            });

            //获取时段
            var setTeacherTimes = function setTeacherTimes(items) {
                var html = '';
                var em = null;
                var choiceTims = $('.choicetime', container);
                $('.classtime', choiceTims).remove();
                items.forEach(function (item) {
                    var obj = $('<div class="classtime">' + item.valid_time_begin + '</div>');
                    obj.click(function () {
                        em && em.removeClass('selecttime');
                        em = $(this);
                        em.addClass('selecttime');
                        beginTime = item.valid_time_begin;
                        if (mode == "1") {
                            //   debugger;
                            me.teacherIds = item.teacher_ids.join(',');
                        }
                    });
                    choiceTims.append(obj);
                });
            };
            var setDateTime = function setDateTime() {
                if (mode == '2' && me.teacherIds == '') {
                    webAbc.showMessage(2, '请选择老师！');
                    return;
                }
                var lay = layer.load(1, {
                    shade: [0.1, '#fff'], //0.1透明度的白色背景
                    offset: ["290px"]
                });
                // debugger;
                var tid = me.teacherIds;
                //设置时段
                $.ajax({
                    url: $.url + '/Member/GetCourseTeachers',
                    type: 'post',
                    data: { courseId: courseId, classId: classId, teacherIds: me.teacherIds, bookDate: bookDate, courseCount: times },
                    dataType: 'json',
                    success: function success(rel) {
                        layer.close(lay);
                        var results = [];
                        if (rel != null && rel.Data != null && rel.Result[0].Code > 0) {
                            results = rel.Data;
                        }
                        if (rel && rel.Result[0].Code < 1) {
                            webAbc.showMessage(2, rel.Result[0].Message);
                        } else if (results.length == 0) {
                            webAbc.showMessage(2, '无可约时段！');
                        }
                        setTeacherTimes(results);
                    }
                });
            };

            //提交预约
            $('.btn[action="submit"]', container).click(function () {
                if (!bookDate) {
                    webAbc.showMessage(2, '请选择上课日期！');return;
                }
                if (!beginTime) {
                    webAbc.showMessage(2, '请选择上课时段！');return;
                }
                $.ajax({
                    url: $.url + '/Member/Order',
                    type: 'post',
                    data: { classId: classId, courseId: courseId, beginTime: beginTime, bookDate: bookDate, teacherIds: me.teacherIds, courseCount: times },
                    dataType: 'json',
                    success: function success(rel) {
                        if (rel.Result[0].Code < 1) {
                            webAbc.showMessage(1, rel.Result[0].Message);
                        } else {
                            webAbc.showMessage(1, '预约成功！');
                        }
                        member.myCourseReadyStatu = false;

                        $('.choicedate .selectdate').click();
                        //$('.side-menu a[action="courselist"]').click();
                    }
                });
            });

            //设置模式
            modesEl.click(function () {
                var el = $(this);
                mode = el.attr('data');
                oEl && oEl.removeClass('select') || modesEl.eq(0).removeClass('select');
                oEl = el;
                oEl.addClass('select');
                //  me.teacherIds = "";
                beginTime = "";
                container.find('.choicetime').html('');
                //debugger;
                if (mode == '2') {
                    //按照时间约课
                    container.find('.selteacher').removeClass('hidden');
                    container.find('.selteacher').find('.input').html("请选择教师");
                } else {
                    //按照老师约课
                    container.find('.selteacher').addClass('hidden');
                    me.teacherIds = '';
                    teacherObj.html('');
                    //if (bookDate != null) {
                    //    $.ajax({
                    //        url: $.url + '/Member/GetCourseTeachers',
                    //        type: 'post',
                    //        data: { courseId: courseId, classId: classId, TeacherIds: me.teacherIds, bookDate: bookDate, courseCount: times },
                    //        dataType: 'json',
                    //        success: function (rel) {
                    //            layer.close(lay);
                    //            var results = [];
                    //            if (rel != null && rel.Data != null && rel.Result[0].Code > 0) {
                    //                results = rel.Data;
                    //            }
                    //            if (rel && rel.Result[0].Code < 1) {
                    //                webAbc.showMessage(2, rel.Result[0].Message);
                    //            }
                    //            else if (results.length == 0) {
                    //                webAbc.showMessage(2, '无可约时段！');
                    //            }
                    //            setTeacherTimes(results);
                    //        }
                    //    });
                    //}
                    //  setDateTime();
                    modesEl.eq(0).click();
                }
                $(".classdate.selectdate").click();
            });

            //设置次数
            timesEl.click(function () {

                var el = $(this);
                times = el.attr('data');
                tEl && tEl.removeClass('select');
                tEl = el;
                tEl.addClass('select');

                $('.classdate.selectdate').click();
            });
            timesEl.eq(0).click();

            //设置日期
            for (var i = 1; i < 8; i++) {
                var date = new Date(new Date().getTime() + i * 24 * 3600 * 1000);
                html += '<div class="classdate flt" data="' + webAbc.dateParseString(date, true, false) + '">' + webAbc.getWeekDay(date.getDay()) + '<br/>' + (date.getMonth() + 1) + '-' + date.getDate() + '</div>';
            }
            container.find('.choicedate').empty().append(html);
            //container.find('.choicedate').append(html);

            var setDayCourse = function setDayCourse(lessons) {
                webAbc.getPageSetting($('.page', container), lessons, 6, function (items) {
                    $('.courseinfo', container).remove();
                    $('.previewclass li').each(function (index, el) {
                        if (index != 0) el.remove();
                    });
                    items.forEach(function (item) {
                        if (bookDate == item.ClassDate && item.CourseCount > 0) {
                            var li = $('<li class="courseinfo"><div class="time flt right_border">' + (item.CategoryCode == 1 ? "一对一课程" : "一对六课程") + '</div><div class="coursename flt right_border">' + item.CourseName + '</div> <div class="class flt right_border">' + (item.ClassModel ? '自约上课' : '固定开课') + '</div><div class="coursename flt right_border">' + (item.TeacherEnName || item.TeacherCnName || '暂无分配') + '</div><div class="class flt right_border">' + item.BeginTime + '~' + item.EndTime + '</div><div class="operation flt">' + (item.ClassModel ? '<div class="btntiny " style="height:18px; line-height:18px;margin-top: 8px;" >取消预约</div>' : '') + '</div></li>');
                            li.find('.btntiny').click(function () {
                                //debugger;
                                var obj = this;
                                cancelYuyue(item.CplId, item.CategoryCode, function () {
                                    //alert(1111);
                                    //debugger;
                                    $(obj).parent().parent().remove();
                                    //$(obj.parent.parent).remove();
                                });
                            });
                            $('.previewclass').append(li);
                        }
                    });
                });
            };
            $('.classdate', container).click(function () {
                el && el.removeClass('selectdate');
                el = $(this);
                el.addClass('selectdate');
                bookDate = el.attr('data');
                setDateTime();

                //查看当日课程
                webAbc.ajax({
                    url: '/Member/GetSchedule',
                    data: { beginTime: bookDate },
                    success: function success(results) {
                        //选出当日课程
                        var lessons = results.filter(function (item) {
                            return bookDate == item.ClassDate && item.CourseCount > 0;
                        });
                        setDayCourse(lessons);
                    }
                });
            });
            //layer.open({
            //    type: 1,
            //    title: ' ',
            //    area: '900px',
            //    shadeClose: true,
            //    content: container
            //});
            OpenLayer({
                type: 1,
                title: ' ',
                closeBtn: 1,
                shadeClose: true,
                shade: 0.1,
                area: '900px',
                content: $('.courseyuyue')
            });
            this.myCapacityReadyStatu = true;
        },
        myCapacityReadyStatu: false,
        //我的课表
        myCourseListReady: function myCourseListReady() {
            initSchedule(new Date());
        },
        //我的评价
        myEvaluateReady: function myEvaluateReady() {
            var container = $('.myevaluate'),
                li = $('.nav-tabs li', container),
                dataType = '0',
                course,
                vlesson,
                oldEvaluate = null;

            if (this.myEvaluateReadyStatu) {
                li.eq(0).click();
                return;
            }
            var getMarkHtml = function getMarkHtml(remark) {
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

            var getEvaluate = function getEvaluate(cplid, coursetype, dataType) {
                webAbc.ajax({
                    url: '/Member/GetClassComment',
                    type: 'post',
                    dataType: 'json',
                    data: { type: dataType },
                    success: function success(datas) {
                        var html = '';
                        webAbc.getPageSetting($('.page', container), datas.filter(function (item) {
                            return item.CourseType == coursetype && (item.CplId == cplid || item.ClassId == cplid);
                        }), 3, function (items) {
                            var html = '';
                            items.forEach(function (item) {
                                html += '<div class="evaluate_item">' + '<table><tr><td rowspan=2 class="evaluate_photo">' + (item.Logo ? '<img src="' + item.Logo + '" />' : '<img src="../../Images/member_default.png" />') + '</td><td>授课老师:' + item.Teacher + '</td><td>课程名称:' + item.CourseName + '</td></tr><tr><td colspan="2">' + (item.About || "") + '</td></tr><tr><td colspan=2>评价时间:' + webAbc.dateParseString(new Date(parseInt(item.CreateTime.substr(6)))) + '</td><td>评分:' + getMarkHtml(item.Remark) + '</td></tr><tr><td colspan=3 rowspan=2>' + item.Content + '</td></tr></table></div>';
                            });
                            html = html || '<div style="width:100%;height:80px;margin-top:100px;font-weight:bold;text-align:center;"><div style="margin-top:10px;">暂无评价</div></div>';
                            $('.order-list', container).html(html);
                        });
                    }
                });
            };

            var couseContainer = $('.courselist_table_container', container);
            var lessonContainer = $('.classhour', container);
            var orderContainer = $('.orderlist', container);
            //var title = $('.content_title', container);
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
                courses = courses.filter(function (item) {
                    return item.CourseType != -1;
                });
                webAbc.getPageSetting($('.page', couseContainer), courses, 10, function (items) {
                    var tb = $('tbody', couseContainer);
                    $('tr', tb).remove();
                    items.forEach(function (item) {
                        var row = $('<tr class="' + (items.indexOf(item) % 2 ? 'odd' : '') + '"><td>' + item.CategoryName + '</td><td>' + item.LevelName + '</td><td>' + item.CourseName + '</td><td>' + (item.ClassModel ? '自约上课' : '固定开课') + '</td><td>' + item.FinishCount + '/' + item.LessonCount + '</td><td>' + '<div class="btntiny " action="search">查看详情</div></td></tr>');
                        tb.append(row);
                        row.find('.btntiny').click(function () {
                            //couseContainer.addClass('hidden');
                            //title.html('课后评价 &gt; ' + item.CourseName);
                            course = item;
                            GetClassPlan({ classType: 1, queryType: 2, courseType: item.CourseType, classId: item.ClassId }, function (obj, lessons) {
                                webAbc.getPageSetting($('.page', lessonContainer), lessons, 10, function (items) {
                                    var tb = $('tbody', lessonContainer);
                                    $('tr', tb).remove();
                                    items.forEach(function (lesson) {
                                        var teacherName = lesson.TeacherEnName || lesson.TeacherCNName || '暂无分配',
                                            classtime = teacherName == '暂无分配' ? '-' : lesson.ClassDate + ' ' + lesson.BeginTime + '~' + lesson.EndTime;
                                        var html = '<tr class="' + (items.indexOf(lesson) % 2 ? 'odd' : '') + '"><td>' + lesson.LessonNo + '</td><td>' + teacherName + '</td><td title="' + lesson.ManagerName + '">' + (webAbc.getCharLength(lesson.ManagerName) < 18 ? lesson.ManagerName || "" : lesson.ManagerName.substr(0, 14) + '..') + '</td><td>' + lesson.CurrStudentNum + '/' + lesson.MaxStudentNum + '</td><td>' + classtime + '</td><td>' + lesson.Clength + '</td><td>' + lesson.LessonStatusName + '</td>';
                                        if (dataType == '0' || dataType == '1' && course.CategoryCode === 1) {
                                            html += '<td><a class="btntiny" action="Evaluate">查看评价</a></td>';
                                        }
                                        html += '</td></tr>';

                                        var row = $(html);
                                        tb.append(row);
                                        row.find('.btntiny').click(function () {
                                            console.log('click2');
                                            //title.html('课后评价 &gt; ' + course.CourseName + '&gt; 课次' + lesson.LessonNo);
                                            var action = $(this).attr('action');
                                            //lessonContainer.addClass('hidden');
                                            vlesson = lesson;
                                            li.eq(0).click();
                                            //orderContainer.removeClass('hidden');
                                            OpenLayer({
                                                type: 1,
                                                title: item.CourseName,
                                                area: '600px',
                                                shadeClose: true,
                                                content: orderContainer
                                            });
                                        });
                                    });
                                });
                                //lessonContainer.removeClass('hidden');
                            });
                            console.log('click');
                            OpenLayer({
                                type: 1,
                                title: item.CourseName,
                                area: '900px',
                                shadeClose: true,
                                content: lessonContainer
                            });
                        });
                        console.log('add click');
                    });
                });
            });

            li.on('click', function () {
                oldEvaluate && oldEvaluate.removeClass('focus');
                oldEvaluate = $(this);
                oldEvaluate.addClass('focus');
                dataType = $(this).attr('data');
                getEvaluate(vlesson.CplId, course.CourseType, dataType);
            });
            this.myEvaluateReadyStatu = true;
        },
        myEvaluateReadyStatu: false,
        //我的订单
        myOrderReady: function myOrderReady() {
            var container = $('.orderform'),

            //list = $('.nav-tabs li', container);
            list = $('.tab li', container);

            webAbc.ajax({
                url: 'getorders',
                success: function success(results) {
                    window.orders = results;
                    list.eq(0).click();
                }
            });
            if (this.myOrderReadyStatus) return;
            this.myOrderReadyStatus = true;
            var oldOrder;
            list.on('click', function () {
                var je = $(this),
                    type = je.attr('data'),
                    source = [];

                //oldOrder && oldOrder.removeClass('focus');
                oldOrder && oldOrder.removeClass('active');
                oldOrder = je;
                //oldOrder.addClass('focus');
                oldOrder.addClass('active');

                if (window.orders) {
                    window.orders.forEach(function (order) {
                        if (type == '0' || !order.TradeNo && type == '1' || order.TradeNo && type == '2') source.push(order);
                    });
                }

                var createOrderHtml = function createOrderHtml(details) {
                    var html = '',
                        oitem = details[0],
                        total = 0;
                    html += '<div class="order-item" style="height:' + (40 + 32 * details.length) + 'px">' + '<div class="order-item-title">' + '<div class="date">' + webAbc.dateParseString(new Date(parseInt(oitem.OrderTime.substr(6))), true, true) + '</div>' + '<div class="no">订单号：</div>' + '<div class="trade">' + oitem.No + '</div>' + '</div>' + '<table class="order-body" >';
                    while (details.length > 0) {
                        var order = details.shift();
                        html += '<tr><td class="order-body-name" >' + order.CardName + '</td><td class="order-body-category" >' + order.Category + '</td><td class="order-body-name" >' + order.CourseName + '</td><td class="order-body-price" >' + order.Amount + '</td><td class="order-body-qty" >' + order.Qty + '</td></tr>';
                        total += order.Price;
                    }
                    html += '</table><div class="order-item-total">' + total + '</div><div class="order-item-operation">' + (!oitem.TradeNo ? '<a class="operation btn" data="' + order.No + '" action="zhifu">支付</a><a class="operation btn" data="' + order.No + '" action="quxiao">取消</a>' : '') + '</div></div>';

                    return html;
                };

                webAbc.getPageSetting($('.page', container), source, 8, function (items) {
                    var html = '';
                    var details = [];
                    items.forEach(function (item) {
                        if (details.length == 0 || details[0].No == item.No) {
                            details.push(item);
                        } else {
                            html += createOrderHtml(details);
                            details.push(item);
                        }
                    });
                    html += details.length > 0 ? createOrderHtml(details) : '';
                    $('.order-list', container).html(html);
                    $('a[action]', container).click(function () {
                        var el = $(this),
                            action = el.attr('action'),
                            orderNo = el.attr('data');

                        if (action == 'zhifu') {
                            window.location.href = $.url + '/BuyClass/BuyCarSubmit?orderNo=' + orderNo;
                        } else if (action == 'quxiao') {
                            $.ajax({
                                url: $.url + '/Member/cancelorder',
                                type: 'post',
                                dataType: 'json',
                                data: { orderNo: orderNo },
                                success: function success(rel) {
                                    if (rel.IsSuccess) {
                                        webAbc.showMessage(1, '订单取消成功！');
                                        member.myOrderReady();
                                    } else {
                                        webAbc.showMessage(2, rel.ErrMsg);
                                    }
                                }
                            });
                        }
                    });
                });
            });
        },
        myOrderReadyStatus: false,
        //我的提问
        myQuestionReady: function myQuestionReady() {
            if (memberType == 1) {
                // debugger;
                window.parent.$(".nav li").eq(4).find("a").click();
                window.location.href = "/Free/Free";
            }
            //var container = $('.myquestion');
            //refreshQuestion();
            //if (this.myQuestionReadyStatus) return;
            //this.myQuestionReadyStatus = true;
            //$('.btn', container).on('click', function () {
            //    var val = $('textarea', container).val();
            //    if (val.length < 6) {
            //        webAbc.showMessage(2, '请更详细的描述问题！');
            //        return;
            //    }
            //    webAbc.ajax({
            //        url: '/Member/RaiseQuestion',
            //        data: { Content: val },
            //        success: function () {
            //            webAbc.showMessage(1, '您的问题已记录！');
            //            $('textarea', container).val('');
            //            refreshQuestion();
            //        }
            //    });
            //});
            //$('.questionanswer .searchAnswer').on('click', function () {
            //    otab.addClass('hidden');
            //    otab = $('.myquestion');
            //    otab.removeClass('hidden');
            //});
            //$('.searchAnswer', container).on('click', function () {
            //    var el = $(this);
            //    otab.addClass('hidden');
            //    otab = $('.questionanswer');
            //    otab.removeClass('hidden');
            //    $('#questionanswer', otab).html($(this.parentNode.parentNode).find('.content').html());
            //    $.ajax({
            //        url: $.url + '/Member/GetQuestionAnswer',
            //        type: 'post',
            //        data: { Id: el.attr('data') },
            //        dataType: 'json',
            //        success: function (rel) {
            //            if (rel.IsSuccess) {
            //                if (rel.Result.length == 0) return;
            //                var hasAccept = rel.Result[0].IsAccept == 1;
            //                webAbc.getPageSetting($('.page', otab), rel.Result, 6, function (answers) {
            //                    var html = '';
            //                    for (var i = 0; i < answers.length; i++) {
            //                        html += '<div class="questionanswer_item">'
            //                            + '<div class="content">' + answers[i].Content + '</div>'
            //                            + '<div class="sign">' + answers[i].UserName + '&nbsp;&nbsp;' + webAbc.dateParseString(new Date(parseInt(answers[i].CreateTime.substr(6)))) + (hasAccept ? answers[i] == rel.Result[0] ? '&nbsp;&nbsp;&nbsp;&nbsp;最佳答案' : '' : '&nbsp;&nbsp;&nbsp;&nbsp;<a class="accept" data="' + answers[i].AnswerId + '">采纳</a>') + '</div>'
            //                        + '</div>';
            //                    }
            //                    $('.order-list', otab).html(html);
            //                    $('.accept', otab).click(function () {
            //                        $.ajax({
            //                            url: 'SetQuestionAnswer',
            //                            type: 'post',
            //                            data: { Id: $(this).attr('data') },
            //                            dataType: 'json',
            //                            success: function (rel) {
            //                                if (rel.IsSuccess) {
            //                                    $('.back', otab).click();
            //                                } else {
            //                                    webAbc.showMessage(2, rel.ErrMsg);
            //                                }
            //                            }
            //                        })
            //                    })
            //                });
            //            }
            //            else {
            //                webAbc.showMessage(2, rel.ErrMsg);
            //            }
            //        }
            //    });
            //});
        },
        myQuestionReadyStatus: false,
        //常见问题
        myAnswerReady: function myAnswerReady() {
            if (membertype == 3) {
                var container = $('.myanswer');
                $.ajax({
                    url: $.url + '/member/getanswer',
                    type: 'post',
                    datatype: 'json',
                    success: function success(rel) {
                        if (rel.issuccess) {
                            var html = '';
                            var datas = rel.result;
                            webabc.getpagesetting($('.page', container), datas, 5, function (items) {
                                var html = '';
                                items.foreach(function (item) {
                                    html += '<div class="answer_item">' + '<div class="question">' + item.username + ':&nbsp;&nbsp;' + item.ask + '</div>' + '<div class="answer">' + item.content + '</div>' + '<div class="sign">' + webabc.dateparsestring(new date(parseint(item.createtime.substr(6)))) + '</div>' + '</div>';
                                });
                                $('.order-list', container).html(html);
                            });
                        } else {
                            webabc.showmessage(2, res.errmsg);
                        }
                    }
                });
            }
            if (membertype == 1) {
                window.parent.$(".nav li").eq(4).click();
            }
        },
        setActiveTab: function setActiveTab(action) {
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
            action == 'phone' && member.phoneReady(); //coursecard
            action == 'coursecard' && member.myCourseCardReady();
            action == 'courselist' && member.myCourseReady();
            action == 'coursetable' && member.myCourseListReady();
            action == 'orderform' && member.myOrderReady();
            action == 'myevaluate' && member.myEvaluateReady();
            action == 'myquestion' && member.myQuestionReady();
            action == 'myanswer' && member.myAnswerReady();
        }
    };

    var oli = null,
        otab = null,
        query = webAbc.getUrlQuery(window.location.search);
    menu_a.click(function () {
        var action = $(this).attr('action');
        member.setActiveTab(action);
    });

    member.setActiveTab(query ? query['action'] : 'single');
    window.member = member;
});

