﻿var webAbc = {
    showMessage: function (type, message, fn) {
        //<sumary>公共提示信息</sumary><param name="type" type="number">1:提示;2:警告;3:错误;4:判断</param>
        if (window.layer) {
            window.layer.alert(message, {
                icon: type || 1,
                skin: 'layer-ext-moon'//, //该皮肤由layer.seaning.com友情扩展。关于皮肤的扩展规则，去这里查阅
                //offset:"150px"
            });
            var win = $('#layui-layer' + layer.index);
            console.log($(window.top).height(), win.height(), window.top.scrollY)
            if (win.length) {
                win.css({
                    //top: parseFloat(win[0].style.top) - 105 + (window.parent.scrollY ? window.parent.scrollY > 275 ? 275 : window.parent.scrollY : 30) + 'px'
                    //top: window.top.scrollY + 'px'
                    top: ($(window.top).height() - win.height()) / 2 + window.top.scrollY - 71
                });
            }
        }
        else {
            window.parent.showMessage(type, message);
        }
    },
    ajax: function (obj) {
        var fn = obj.success;
        obj.dataType = 'JSON';
        obj.type = obj.type || 'post';
        obj.url += (obj.url.indexOf('?') > 0 ? '&' : '?') + 'random=' + Math.random();
        obj.success = function (rel) {
            if (rel.IsSuccess) {
                if (typeof fn == 'function') {
                    fn(rel.Result);
                }
            } else if (rel.ErrCode == '1002') {
                window.parent.CurrentUser = null;
                window.parent.showLogin();
            }
            else {
                webAbc.showMessage(2, rel.ErrMsg);
            }
        }

        //debugger;
        $.ajax(obj);
    },
    dateParseString: function (date, hasDate, hasTime) {
        var res = '';
        if (hasDate !== false) {
            var year = date.getFullYear(),
                month = date.getMonth() + 1,
                day = date.getDate();

            res = year + '-' + (month > 9 ? month : '0' + month) + '-' + (day > 9 ? day : '0' + day);
        }
        if (hasTime !== false) {
            var hour = date.getHours(),
                minute = date.getMinutes(),
                second = date.getSeconds();

            res += (hasDate != false ? ' ' : '') + hour + ':' + (minute > 9 ? minute : '0' + minute) + ':' + (second > 9 ? second : '0' + second);
        }
        return res;
    },
    stringParseDate: function (date) {
        return Date.parse(date.replace('-', '/').replace('-', '/'));
    },
    getWeekDay: function (day) {
        switch (day) {
            case 0:
                return '周日';
            case 1:
                return '周一';
            case 2:
                return '周二';
            case 3:
                return '周三';
            case 4:
                return '周四';
            case 5:
                return '周五';
            case 6:
                return '周六';
        }
    },
    getMonthDayCount: function (year, month) {
        switch (month) {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                return 31;
            case 2:
                return year % 400 == 0 && year % 4 == 0 ? 29 : 28;
            case 4:
            case 6:
            case 9:
            case 11:
                return 30;
        }
    },
    getPageSetting: function (container, datas, size, fn, hidePage) {
        var pageCount = Math.ceil(datas.length / size);
        var barPage = 0;
        var barLength = 5;
        var page = 1;
        var setPage = function (pageNum) {
            fn(datas.slice(pageNum * size - size, pageNum * size));
        }

        if (hidePage) {
            var html = '<a class="page_for hidden" title="上一页" data="-1"><</a><a title="下一页" class="page_for ' + (pageCount == 1 ? 'hidden' : '') + '" style="margin-left:3px;" data="1">></a>';
            container.html(html);
            var pageA = $('a', container);
            pageA.click(function () {
                var el = $(this),
                    data = parseInt(el.attr('data'));

                page += data;
                if (page > 1) {
                    pageA.eq(0).removeClass('hidden');
                } else {
                    pageA.eq(0).addClass('hidden');
                }
                if (page == pageCount) {
                    pageA.eq(1).addClass('hidden');
                } else {
                    pageA.eq(1).removeClass('hidden');
                }
                setPage(page);
            });
            setPage(page);
            return;
        }

        var reloadBarHtml = function () {
            var html = barPage > 0 ? '<a class="page_for" title="上一页" data="' + (barPage - 1) + '"><</a>' : '';
            for (var i = 1; i <= barLength && (barPage * barLength + i) <= pageCount; i++) {
                html += '<a pos="' + i + '" data="' + (barPage * barLength + i) + '">' + (barPage * barLength + i) + '</a>';
            }
            html += (barPage + 1) * barLength < pageCount ? '<a title="下一页" class="page_for" data="' + (barPage + 1) + '">></a>' : '';

            container.html(html);
            var pageA = $('a', container);
            var focusA = pageA.eq(page - barPage * barLength - (barPage > 0 ? 0 : 1));
            pageA.click(function () {
                var el = $(this),
                    data = parseInt(el.attr('data')),
                    opage, pos;

                if (el.hasClass('page_for')) {
                    barPage = data;
                    pos = parseInt(focusA.attr('pos'));
                    page = barPage * barLength + pos;
                    page = page > pageCount ? pageCount : page;
                    reloadBarHtml();
                } else {
                    focusA.removeClass('page_focus');
                    pos = parseInt(el.attr('pos'));
                    setPage(data);
                    focusA = el;
                    focusA.addClass('page_focus');
                }
            });
            setPage(page);
            focusA.addClass('page_focus');
        }
        reloadBarHtml();
    },
    validate: function (val, type, ext) {
        var result = true;

        return result;
    },
    updateFrameHeight: function (height) {
        window.parent.document.getElementById('ContentFrame').style.height = (height || 800) + 'px';
    },
    getUrlQuery: function (search) {
        if (!search) return null;
        if (search.indexOf('?') > -1) search = search.substr(1);
        var search = '{"' + search + '"}';
        while (search.indexOf('=') > -1) {
            search = search.replace('=', '":"');
        }
        while (search.indexOf('&') > -1) {
            search = search.replace('&', '","');
        }
        return JSON.parse(search);
    },
    judgeSystem: function () {
        return window.location.href.indexOf('Young') > -1;
    },
    markStar: function (obj) {
        var me = this,
            remark = obj.remark || 1,
            //imgOn = '../../Images/star-on.png',//$.url+
            //imgOff = '../../Images/star-off.png',
              imgOn = $.url + '/Images/star-on.png',//$.url+
            imgOff = $.url + '/Images/star-off.png',
            getStarHtml = function (remark) {
                var html = '', count = obj.changed ? remark : 5;
                for (var i = 0; i < count; i++) {
                    html += '<img src="' + (remark > i ? imgOn : imgOff) + '" />';
                }
                return html;
            },
            markstar = $('<div style="width:100%;float:left;margin-top:5px;padding-left:30px;"><label class="label" style="float:left; font-size:13px;">' + obj.title + ':</label><div class="rate" style="float:left;">' + getStarHtml(remark)
                + '</div></div>');

        markstar.appendTo(obj.container);
        if (obj.changed) return;
        var imgs = markstar.find('img');
        imgs.mouseover(function (obj) {
            var mark = false;
            imgs.each(function (index, el) {
                el.src = mark ? imgOff : imgOn;
                mark = mark || el == obj.target;
            });
        })

        imgs.mouseout(function (obj) {
            imgs.each(function (index, el) {
                el.src = index < remark ? imgOn : imgOff;
            });
        })

        imgs.click(function (ev) {
            imgs.each(function (index, el) {
                if (el == ev.target) {
                    remark = index + 1;
                    obj.fn && obj.fn(remark);
                }
            })
        })
    },
    getCharLength: function (str) {
        var len = 0;
        if (str == null) return 0;
        for (var i = 0; i < str.length; i++) {
            var c = str.charCodeAt(i);
            if ((c >= 0x0001 && c <= 0x007e) || (0xff60 <= c && c <= 0xff9f)) {
                len++;
            }
            else {
                len += 2;
            }
        }
        return len;
    },
    bindPageImage: function (typeId, fn) {
        webAbc.ajax({
            url: $.url + '/home/getwebsiteimages',
            async: false,
            data: { siteType: window.parent.SiteType || 0, typeId: typeId },
            success: function (results) {
                if (results.length == 0) return;
                fn(results);
            }
        })
    },
    PlayGenSee: function (lesson, title) {
        var height = 640, width = 1020;
        $.ajax({
            url: '/Gensee/AssignGenSee',
            data: { CplId: lesson.CplId, CourseType: lesson.CourseType },
            type: 'post',
            success: function (rel) {
                //debugger;
                var url = '';
                if (rel && typeof rel === 'string') {
                    url = rel;
                }
                webAbc.OpenPage(rel);
            }
        });
    },
    OpenPage: function (url, title) {
        var layer = window.layer || window.parent.layer;
        if (!url) {
            webAbc.showMessage(1, '视频正在上传中，敬请期待！');
            return;
        }
        layer.open({
            type: 2,
            title: '<img src="../../Content/img/logo_new.png"  style="float:left;" height="36px" />',
            shadeClose: true,
            shade: 0.5,
            area: ['900px', '543px'],
            content: [url, 'no']//iframe的url
        });
    }
};

//window.parent.scrollTo(0, 0);
$('img[action="login"]').click(function () {
    window.parent.showLogin();
});