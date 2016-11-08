(function () {
    var getCalenderHtml = function (date, data) {
        var html = '<table width="100%" style="border-spacing: 0;"><tr><th>周一</th><th>周二</th><th>周三</th><th>周四</th><th>周五</th><th>周六</th><th>周日</th></tr>',
            dayCount = getMonthDayCount(date.getFullYear(), date.getMonth() + 1),
            day = new Date(date.setDate(1)).getDay() || 7, count = 1;

        for (var i = 0; count - day < dayCount; i++) {
            html += '<tr>';
            for (var j = 1; j <= 7; j++) {
                count = i * 7 + j;
                if (count < day || count - day >= dayCount)
                    html += '<td></td>';
                else
                    html += '<td data_date="' + (count - day + 1) + '" class="coursetd normal' + ((data.indexOf(count - day + 1) > -1) ? ' green' : '') + '">' + (count - day + 1) + '</td>';
            }
            html += '</tr>';
        }
        html += '</table>';
        return html;
    }
    var getCourse = function (date) {
        return [
            { Id: 1, Name: '课程1', Teacher: '教师', Process: 3, Total: 10 },
            { Id: 2, Name: '课程2', Teacher: '教师', Process: 3, Total: 10 },
            { Id: 3, Name: '课程3', Teacher: '教师', Process: 3, Total: 10 },
            { Id: 4, Name: '课程4', Teacher: '教师', Process: 3, Total: 10 }
        ];
    };
    var setCalender = function (date) {
        var data = [3, 4, 5, 9, 17, 25];
        var day = date.getDate(), str_day = getDateString(date, true, false);

        $('.overview .content').html(str_day.substr(0, 8).replace('-', '年').replace('-', '月'));
        $('.overview .content').attr('data_date', str_day);
        $('.calender .table').html(getCalenderHtml(date, data));
        var selTd = null;
        $('.calender td').click(function () {
            var el = this, course = '', date = $(el).attr('data_date');
            $('.activedate').html(date);
            $('.activeday').html(getWeekDay(el.cellIndex));

            if (selTd == el) return;
            if (selTd) selTd.removeClass('select');
            selTd = $(el);
            selTd.addClass('select');
            if (el.className.indexOf('green') > 0) {
                course = '<table width="100%" cellpadding="0" cellspacing="0"><tr><td>课程名称</td><td>上课老师</td><td>课程进度</td><td>课程介绍</td></tr>';
                getCourse(date).forEach(function (item) {
                    course += '<tr><td>' + item.Name + '</td><td>' + item.Teacher + '</td><td>' + item.Process + '</td><td><button class="btn" method="playCourse" data="' + item.Id + '">进入教室</button></td></tr>';
                });
                course += '</table>';
            }
            $('#calendar_course').html(course);
        });
        $('.calender .table td[data_date="' + day + '"]').click();
    }
    $('.overview .prev,.overview .next').click(function () {
        var el = this;
        var date = new Date($('.overview .content').attr('data_date').replace('-', '/').replace('-', '/'));
        date.setMonth(date.getMonth() + (el.className == 'prev' ? -1 : 1));
        setCalender(date);
    });
    setCalender(new Date());
})();