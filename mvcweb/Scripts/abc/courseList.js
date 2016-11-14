$(() => {
    var course, lesson, oldEl = null,
                remark = [0, 0, 0],
                container = $('.courselist'),
                mark = $('.classEvaluate .remark');
    var oldbtn = null;

    var getClassPlan = function (obj, fn) {
        webAbc.ajax({
            url: $.url + '/Member/getclassplan',
            data: obj,
            success: function (result) {
                fn(obj, result);
            }
        });
    }

    var memberType = window.parent.CurrentUser.Type;

    if (memberType == 1) {
        webAbc.markStar({
            container: mark,
            title: '教学质量',
            fn: function(mark) {
                remark[0] = mark;
            }
        });
        webAbc.markStar({
            container: mark,
            title: '教师态度',
            fn: function(mark) {
                remark[1] = mark;
            }
        });
        webAbc.markStar({
            container: mark,
            title: '课堂气氛',
            fn: function(mark) {
                remark[2] = mark;
            }
        });
    }
    else if (memberType == 3) {
        webAbc.markStar({
            container: mark,
            title: '学习能力',
            fn: function(mark) {
                remark[0] = mark;
            }
        });
        webAbc.markStar({
            container: mark,
            title: '学习态度',
            fn: function(mark) {
                remark[1] = mark;
            }
        });
        webAbc.markStar({
            container: mark,
            title: '掌握程度',
            fn: function(mark) {
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
            success: function () {
                webAbc.showMessage(1, "评价成功！");
                setTimeout(function () {
                    layer.closeAll();
                }, 2000);
            }
        })
    });
    var setLessonComment = function (cplId, isPublic) {
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
                    })
                }
                else {
                    webAbc.showMessage(2, rel.ErrMsg);
                }
            }
        });
    }
    var getRowHtml = function (item, type) {
        var teacherName = item.TeacherEnName || item.TeacherCNName || '暂无分配',
            classtime = teacherName == '暂无分配' ? '-' : item.ClassDate + ' ' + item.BeginTime + '~' + item.EndTime;
        var html = '<tr><td>' + item.LessonNo + '</td><td>' + teacherName + '</td><td title="' + item.ManagerName + '">' + (webAbc.getCharLength(item.ManagerName) < 18 ? (item.ManagerName || "") : item.ManagerName.substr(0, 14) + '..') + '</td><td>' + item.CurrStudentNum + '/' + item.MaxStudentNum + '</td><td>' + classtime + '</td><td>' + item.Clength + '</td><td>' + item.LessonStatusName + '</td>';
        if (teacherName != '暂无分配')
            switch (type) {
                case '0':
                    html += '<td>';
                    if (memberType == '1' && course.ClassModel == 1 && course.CategoryCode != '1')
                        html += '<a class="btntiny" action="Yuyue">立即预约</a>';
                    html += '</td></tr>'
                    break;
                case '1':
                    html += '<td style="width:200px;"><a class="btntiny" action="InClassRoom">进入教室</a>';
                    if (memberType == '1' && course.ClassModel == 1)
                        html += '<a class="btntiny" action="Cancel">取消约课</a>';
                    if (course.CategoryCode < 100) {
                        html += '<a class="btntiny" action="LessonAccess" >课件</a></td></tr>'
                    }
                    break;
                case '2':
                    html += '<td>';
                    if (course.CategoryCode < 100) {
                        html += '<a class="btntiny" action="LessonAccess" >课件</a>';
                    }
                    if (memberType == '1' || (memberType == '3' && course.CategoryCode === 1)) {
                        html += '<a class="btntiny" action="Evaluate">评价</a>'
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
    var initClassLesson = function (obj, lessons) {
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
                tb.append(row); console.log($('.btntiny', row))
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
                                success: function (rel) {
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
                            cancelYuyue(item.CplId,
                                item.CategoryCode,
                                function () {
                                    member.setActiveTab('courselist');
                                    oldEl.click();
                                });
                            break;
                        case 'Evaluate':
                            setLessonComment(item.CplId, item.CategoryCode >= 100);
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
                            console.log('InClassRoom')
                            // debugger;
                            inClassRoom(item);
                            break;
                        case 'LessonAccess':
                            searchLessonAccess(item.CplId);
                            break;
                    }
                })
            });
            //webAbc.OpenLayer({
            //    type: 1,
            //    title: ' ',
            //    area: '900px',
            //    shadeClose: true,
            //    //content: table
            //    content: $('.classhour')
            //});
                webAbc.openDom($('.classhour'), '900px');
            }
        );

    }
    var searchClassLesson = function (type) {
        $('.classhour li').remove();
        $('#coursedetail').html("&nbsp;&gt;&nbsp;" + course.CourseName);
        getClassPlan({ classType: 1, queryType: type, courseType: course.CourseType, classId: course.ClassId }, initClassLesson);
    }
    var initClassPlan = function (obj, courses) {
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
                var row = $('<tr class=' + (index % 2 ? 'odd' : 'opp') + '><td>' + item.CategoryName + '</td><td>' + item.LevelName + '</td><td>' + item.CourseName + '</td><td>' + (item.ClassModel ? '自约上课' : '固定开课') + '</td><td>'
                  + item.FinishCount + '/' + item.LessonCount + '</td><td style="width:200px;">'
                  + (obj.queryType == '0' && item.CategoryCode == 1 ? '<div class="btntiny " action="yuyue">发起预约</div>' : '')
                  + (item.CourseType == -1 ? '' :
                  (obj.queryType == '0' && item.CategoryCode == 1 ? '<div class="btntiny " action="search">查看详情</div>' : '<div class="btntiny " action="search">' + (fs ? "发起预约" : "查看详情") + '</div>') + '</td></tr>'));

                tb.append(row);
                row.find('.btntiny').click(function () {
                    var action = $(this).attr('action');
                    course = item;
                    switch (action) {
                        case 'search':
                            searchClassLesson(obj.queryType);
                            oldbtn = $(this);
                            //otab.addClass('hidden');
                            //otab = $('.classlesson');
                            //otab.removeClass('hidden');
                            break;
                        case 'yuyue':
                            //    debugger;
                            var title = $('.courseyuyue .title');
                            title.html('<a style="cursor:pointer">我的课程</a>&gt;<a>' + course.CategoryName + '&nbsp;-&nbsp;' + item.CourseName + '<a>');
                            title.find('a').eq(0).click(function () {
                                member.setActiveTab('courselist');
                            })
                            member.myCapacityReady(course.ClassId, course.CourseId);
                            //otab.addClass('hidden');
                            //otab = $('.courseyuyue');
                            //otab.removeClass('hidden');
                            break;
                    }
                })
            });
            webAbc.autoAjustIframeHeight();
        });
    }
    //if (this.myCourseReadyStatu) {
    //    $('.nav-tabs li', container).eq(0).click();
    //    return;
    //}
    $('.nav-tabs li', container).click(e => {
        var je = $(e.target),
            type = je.attr('data');

        oldEl && oldEl.removeClass('focus');
        oldEl = je;
        oldEl.addClass('focus');
        getClassPlan({ classType: 0, queryType: type, courseType: 2 }, initClassPlan);
    });
    $('.nav-tabs li', container).eq(0).click();
});