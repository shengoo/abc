window.reloadIndex = function () {
    window.location.href = window.location.href;
}
if (window != window.parent && window.parent.reloadIndex) {
    window.parent.reloadIndex();
}

var configs = {
    index: {
        weibo: {
            text: '扫码关注',
            src: '../../Images/twodimensioncode.jpg'
        },
        weixin: {
            text: '关注ABC微信',
            src: '../../Images/twodimensioncode.jpg'
        }
    }
}

$(function () {
    window.SiteType = location.href.indexOf('Young') > -1 ? 1 : 0;

    $(".register .close").bind("click", function () {
        $(".register").hide();
    });
    //var nTop = $(".header").offset().top;
    //$(window).scroll(function () {
    //    /*固定导航开始*/
    //    var nSrolltop = $(this).scrollTop();
    //    if (nSrolltop >= nTop) {
    //        $(".header").css({
    //            "position": "fixed",
    //            "top": 0,
    //            "left": 0,
    //            "z-index": 100
    //        });
    //    }
    //    /*固定导航结束*/

    //    /*回到顶部开始*/
    //    if ($(window).scrollTop() >= 500) {
    //        $('.back').fadeIn(300);
    //    } else {
    //        $('.back').fadeOut(300);
    //    }
    //    /*回到顶部结束*/
    //    $('iframe')[0].style.marginTop = '105px';
    //});
    $('.back').click(function () { $('html,body').animate({ scrollTop: '0px' }, 800); });
});

$(document).ready(function () {
    var url = window.location.href.split('/').length > 1 ? '/Home' : '';
    $(".right-01,.right-02,.opts li").bind("click", function () {
        showLogin($(this).hasClass('right-02') || $(this).hasClass('opt-two') ? 2 : 1);
    });

    $('li[action="appDown"]').mouseover(function () {
        var el = $(this),
            config = $('li[action="appDown"]')[0] == this ? configs.index.weibo : configs.index.weixin,
            down = $('.appDown');

        down.css({
            left: this.offsetLeft + 'px',
            top: document.body.scrollTop + this.offsetTop + this.offsetHeight + 'px'
        });
        $('.appDown_title', down).html(config.text);
        $('img', down).attr('src', config.src);
        down.removeClass('hidden');
    }).mouseout(function () {
        $('.appDown').addClass('hidden');
    });

    function setLogin(obj) {
        var win = window.parent;
        if (obj.Type == '1') {
            win.location.href = '/Home/Index';
            return;
        }
        win.CurrentUser = obj;

        $('.close').click();
        $('.xubox_close').click();
        $('.layui-layer-close').click();
        win.$('.right ul').addClass('hidden');
        win.$('.user').removeClass('hidden');
        win.$('.user span').eq(0).html('Hello，' + obj.Name + '，Welcome！');
        win.$('.user span').eq(1).html('<a href="javascript:loginOut();" id="loginout" >LoginOut</a>');
     //   win.AddLoginOutEvent();
        var centertab = win.$("#hidTab");
        if (obj.Type != 1) {
            centertab.html('Personal Center');
        }
        if (obj.Type == 3) {
            centertab.attr('href', '/Member/TeacherMember?action=coursetable');
        }
        //window.parent.$('#ContentFrame')[0].contentWindow.location.href = '/Member/TeacherMember?action=coursetable';
        window.parent.$('#ContentFrame')[0].contentWindow.location.href = '/Teacher/ChangePassword';
        centertab.parent('li').removeClass('hidden');
        centertab.parent('li').click();
    }

    $('button').bind('click', function () {
        var el = this,
            je = $(el),
            method = je.attr('method');

        if (method == 'hidemasktip') { $('.masktip').addClass('hidden'); }
        else if (method == 'login') {
            var form1 = $('#Form1 input'),
                user = form1.eq(0).val(),
                pwd = form1.eq(1).val();

            if (!user || !pwd) {
                showMessage(2, 'User name or password can not be empty！');
                return;
            }
            webAbc.ajax({
                url: '/Home/MemberTeacherLogin',
                data: {
                    UserName: user,
                    Pwd: pwd,
                    isSave: $('.autologin')[0].checked
                },
                success: function (result) {
                    setLogin(result);
                }
            });
        }
        else if (method == 'register') {
            var cls = $('#Form2 input');

            var user = cls.eq(0).val(),
                pwd = cls.eq(1).val(),
               //userType = cls[3].checked ? 1 : 2,
               userType = 1,
                valid = cls.eq(3).val();

            var err = '';
            if (!user || user.length != 11) {
                err = 'Please enter the correct phone number!';
            }
            else if (!pwd || pwd.length < 6) {
                err = 'Please enter a password of at least 6!';
            }
            else if (pwd != cls.eq(2).val()) {
                err = 'The two passwords do not match!';
            }
            else if (!valid) {
                err = 'Please enter the SMS verification code!';
            }
            if (err) {
                showMessage(2, err);
            }

            $.ajax({
                url: $.url + url + '/Register',
                type: 'post',
                data: { user: user, pwd: pwd, userType: userType, valid: valid },
                dataType: 'json',
                success: function (rel) {
                    if (rel.IsSuccess) {
                        showMessage(1, "You have successfully registered！");
                        setLogin(rel.Result);
                    } else {
                        showMessage(2, rel.ErrMsg);
                    }
                }
            });
        }
        else if (method == 'action') {
            $('iframe')[0].src = el.attributes.action.value;
        }
        else if (method == 'sendValid') {
            var cls = $('input[name="UserName"]'),
                mobile = cls.eq(je.attr('data')).val();

            if (!mobile || mobile.trim().length != 11) {
                showMessage(2, "Your phone number is wrong！");
                return;
            }
            if (!parseInt(el.innerHTML)) {
                $.ajax({
                    url: '/Home/sendvalid',
                    type: 'post',
                    dataType: 'json',
                    data: { "mobile": mobile, "isupdate": je.attr('data') == 1 },
                    success: function (rel) {
                        if (rel.IsSuccess) {
                            var times = 60;
                            showMessage(1, "SMS Success！");
                            var siv = setInterval(function () {
                                if (times == 0) {
                                    el.innerHTML = 'get verification code';
                                    clearInterval(siv);
                                    return;
                                }
                                el.innerHTML = times-- + ' seconds later resend';
                            }, 1000);
                        } else {
                            showMessage(2, rel.ErrMsg);
                        }
                    }
                });
            }
        }
        else if (method == 'modifyPassword') {
            var cls = $('.searchPassword input');
            var user = cls.eq(0).val(),
                pwd = cls.eq(1).val(),
                valid = cls.eq(3).val();

            var err = '';
            if (!user || user.length != 11) {
                err = 'Please enter the correct phone number!';
            }
            else if (!pwd || pwd.length < 6) {
                err = 'Please enter a password of at least 6!';
            }
            else if (pwd != cls.eq(2).val()) {
                err = 'The two passwords do not match!';
            }
            else if (!valid) {
                err = 'Please enter the SMS verification code!';
            }
            if (err) {
                showMessage(2, err);
                return;
            }
            webAbc.ajax({
                url: $.url + '/Home/ModifyPasswordForTeacher',
                data: { user: user, pwd: pwd, valid: valid },
                success: function (result) {
                    setLogin(result);
                }
            })
        }
    });
    
    $.ajax({
        url: '/Home/GetLogin',
        type: 'post',
        data: { login: $.cookie('loginname') },
        dataType: 'json',
        success: function (rel) {
            if (rel.IsSuccess) {
                setLogin(rel.Result);
            }
        }
    });
});

window.setTab = function (name, cursel, n) {
    for (var i = 1; i <= n; i++) {
        var main_menu = document.getElementById(name + i);
        var sub_menu = document.getElementById('con-' + name + '-' + i);
        main_menu.className = (i == cursel) ? 'hover' : '';
        sub_menu.style.display = (i == cursel) ? 'block' : 'none';
    }
};

//window.loginOut = function () {
//    $.ajax({
//        url: $.url + '/Home/LoginOut',
//        data: Math.random(),
//        type: 'post',
//        dataType: 'json',
//        success: function (rel) {
//            if (rel.IsSuccess) {
//                window.location.href = window.location.href;
//            }
//        }
//    });
//}

window.showLogin = function (type) {
    if (window.CurrentUser) return;
    layer.open({
        type: 1,
        title: false,
        closeBtn: 1,
        shadeClose: true,
        shade: 0,
        area: ['500px', 'auto'],
        content: $('.mask_login') //iframe的url
    });
    $('.layui-layer-content').css({ height: 'auto' });
    setTab('taba', type || 1, 2);
}

window.searchPassword = function () {
    layer.open({
        type: 1,
        title: false,
        closeBtn: 1,
        shadeClose: true,
        shade: 0.1,
        area: ['540px', 'auto'],
        content: $('.searchPassword') //iframe的url
    });
    $('.layui-layer-content').css({ overflow: 'hidden' });
}

window.showMessage = function (tip, message) {
    layer.alert(message,
    {
        icon: tip || 1,
        skin: 'layer-ext-moon' //该皮肤由layer.seaning.com友情扩展。关于皮肤的扩展规则，去这里查阅
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
};

window.updateUser = function (name) {
    $('.user span').eq(0).html('Hello，' + name + '，Welcome！');
}