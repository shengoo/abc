﻿window.reloadIndex = function () {
    window.location.href = window.location.href;
}
if (window != window.parent && window.parent.reloadIndex) {
    window.parent.reloadIndex();
}

var configs = {
    index: {
        xinlang: {
            text: '扫码关注',
            src: '../Images/twodimensioncode.jpg'
        },
        weibo: {
            text: '关注ABC微信',
            src: '../Images/twodimensioncode.jpg'
        }
    }
}
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
        window.CurrentUser = obj;
        $('.close').click();
        $('.xubox_close').click();
        $('.layui-layer-close').click();
        $('.right ul').addClass('hidden');
        $('.header .get').addClass('hidden');
        $('.user span').eq(0).html('您好，' + obj.Name + '，欢迎你！');
        $('.user span').eq(1).html('<a href="javascript:loginOut();" target="_self">退出</a>');
        if (obj.Type != 1) {
            $('#hidTab').html('个人中心');
        }
        if (obj.Type == 2 || obj.Type == 4) {
            $('#hidTab').attr('href', '/Member/Member?action=myanswer');
        }
        //     $(".nav li").find(".color-white").find("a").click();
        //  $(".nav .color-white a").click();
        //$('#ContentFrame ').contentWindow.location.reload();
        $("#ContentFrame")[0].contentWindow.location.reload();
        $('.nav li').removeClass('hidden');
        $('.nav li:last').show();
        //$('nav.menu li:last').show();
        $('.user').removeClass('hidden');
        $('#login').hide();
    }
    function aa() {
        $(".set").show();
    }
    $(".register_title").mousedown(function (e)//e鼠标事件 
    {
        $(this).css("cursor", "move");//改变鼠标指针的形状 
        var offset = $('.login').offset();//DIV在页面的位置 
        var x = e.pageX - offset.left;//获得鼠标指针离DIV元素左边界的距离 
        var y = e.pageY - offset.top;//获得鼠标指针离DIV元素上边界的距离 
        $(document).bind("mousemove", function (ev)//绑定鼠标的移动事件，因为光标在DIV元素外面也要有效果，所以要用doucment的事件，而不用DIV元素的事件 
        {
            $(".login").stop();//加上这个之后 
            var _x = ev.pageX - x;//获得X轴方向移动的值 
            var _y = ev.pageY - y;//获得Y轴方向移动的值 
            $(".login").animate({ left: _x + "px", top: _y + "px" }, 10);
        });
    });

    $(document).mouseup(function () {
        $(".register_title").css("cursor", "default");
        $(this).unbind("mousemove");
    })
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
                showMessage(2, '用户名或密码不能为空！');
                return;
            }
            webAbc.ajax({
                url: '/Home/Login',
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
                err = '请输入正确的电话号码！';
            }
            else if (!pwd || pwd.length < 6) {
                err = '请输入至少6位的密码！';
            }
            else if (pwd != cls.eq(2).val()) {
                err = '两次输入的密码不一致！';
            }
            else if (!valid) {
                err = '请输入短信验证码！';
            }
            if (err) {
                showMessage(2, err);
                return;
            }

            $.ajax({
                url: $.url + url + '/Register',
                type: 'post',
                data: { user: user, pwd: pwd, userType: userType, valid: valid },
                dataType: 'json',
                success: function (rel) {
                    if (rel.IsSuccess) {
                        showMessage(1, "您已注册成功！");
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
            console.log(cls, mobile)
            if (!mobile || mobile.trim().length != 11) {
                showMessage(2, "您输入的手机号码有误！");
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
                            showMessage(1, "短信发送成功！");
                            var siv = setInterval(function () {
                                if (times == 0) {
                                    el.innerHTML = '获取验证码';
                                    clearInterval(siv);
                                    je.prop('disabled', false);
                                    return;
                                }
                                el.innerHTML = times-- + '秒后重新发送';
                            }, 1000);
                        } else {
                            showMessage(2, rel.ErrMsg);
                            je.prop('disabled', false);
                        }
                    }
                });
                je.prop('disabled', true);
            }
        }
        else if (method == 'modifyPassword') {
            var cls = $('.searchPassword input');
            var user = cls.eq(0).val(),
                pwd = cls.eq(1).val(),
                valid = cls.eq(3).val();

            var err = '';
            if (!user || user.length != 11) {
                err = '请输入正确的电话号码！';
            }
            else if (!pwd || pwd.length < 6) {
                err = '请输入至少6位的密码！';
            }
            else if (pwd != cls.eq(2).val()) {
                err = '两次输入的密码不一致！';
            }
            else if (!valid) {
                err = '请输入短信验证码！';
            }
            if (err) {
                showMessage(2, err);
                return;
            }
            webAbc.ajax({
                url: $.url + '/Home/ModifyPassword',
                data: { user: user, pwd: pwd, valid: valid },
                success: function (result) {
                    setLogin(result);
                }
            })
        }
    });

    //获取底部文章列表
    $.ajax({
        url: $.url + '/Home/GetArtcleForFooter',
        type: 'post',
        data: {},
        dataType: 'json',
        success: function (data) {
            if (data.ret) {
                var sHtml = "";
                $.each(data.obj, function (item, value) {
                    sHtml += '<div class="footer-list" ' + (item === 0 ? 'style="margin: 0 0 0 20px;"' : '') + '>';
                    sHtml += "<h3>" + value.ArtcleCateName + "</h3><ul>";
                    $.each(value.ArtcleList, function (i, v) {
                        //sHtml += "<li><img src='/Content/icon/abccon.jpg' style=' margin-bottom: 2px; margin-right: 4px;'></img><a href='javascript:void(0)' >" + v.Title + "</a></li>";
                        sHtml += "<li><img src='/Content/icon/abccon.jpg' style=' margin-bottom: 2px; margin-right: 4px;'></img><a>" + v.Title + "</a></li>";
                    });
                    sHtml += "</ul></div>";
                });
                $(".footer .w1000").html(sHtml);
            }
        }
    });



    $.ajax({
        url: $.url + url + '/GetLogin',
        type: 'post',
        data: { login: $.cookie('loginname') },
        dataType: 'json',
        success: function (rel) {
            if (rel.IsSuccess) {
                setLogin(rel.Result);
            } else {
                $('.choose-page').show();
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

window.loginOut = function () {
    $.ajax({
        url: $.url + '/Home/LoginOut',
        data: Math.random(),
        type: 'post',
        dataType: 'json',
        success: function (rel) {
            if (rel.IsSuccess) {
                window.location.href = window.location.href;
            }
        }
    });

    ///添加退出确认框
    //layer.confirm('您确定要退出？', {
    //    btn: ['确定', '取消'] //按钮
    //}, function (index) {
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
    //}, function () {
    //    layer.close(index);
    //});


}

window.showLogin = function (type) {
    if (window.CurrentUser) return;
    $('#login .login').show();
    $('#login .register').hide();
    webAbc.openDom($('#login'));
}
window.showRegister = function () {
    if (window.CurrentUser) return;
    $('#login .login').hide();
    $('#login .register').show();
    webAbc.openDom($('#login'));
}

window.searchPassword = function () {
    //layer.open({
    //    type: 1,
    //    title: ' ',
    //    shadeClose: true,
    //    area: ['440px', 'auto'],
    //    content: $('.searchPassword') //iframe的url
    //});
    //$('.layui-layer-content').css({ overflow: 'hidden' });
    webAbc.openDom($('.searchPassword'));
}

window.showMessage = function (tip, message) {
    layer.alert(message,
    {
        icon: tip || 1,
        move: false,
        title:' ',
        shadeClose: true,
        skin: 'layer-ext-abc' //该皮肤由layer.seaning.com友情扩展。关于皮肤的扩展规则，去这里查阅
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
    $('.user span').eq(0).html('您好，' + name + '，欢迎你！');
};

window.updateContentFrameHeight = function (height) {
    $('#ContentFrame').css({
        height: height
    });
};


$(() => {

    $('#login_register')
        .click(() => {
            $('#login .login').hide();
            $('#login .register').show();
            $('.layui-layer-content').css({ height: 'auto' });
        });
    $('#register_login')
        .click(() => {
            $('#login .login').show();
            $('#login .register').hide();
            $('.layui-layer-content').css({ height: 'auto' });
        });

    //登陆
    $('.header .get .exit')
        .click(() => {
            showLogin();
        });
    //注册
    $('.header .get .enroll')
        .click(() => {
            showRegister();
        });

    //底部注册按钮
    $('.fixed-register .buttons')
        .click(() => {
            window.top.showRegister();
        });

    $('.page-type.adult')
        .click(() => {
            $('.choose-page').hide();
        });
    $('.choose-page-link')
        .click(e => {
            e.preventDefault();
            document.getElementById('ContentFrame').src = e.target.href;
            $('.choose-page').hide();
            //$('#ContentFrame')[0].src(e.target.href);
        });

    //scroll to top
    $('.footer-icon')
        .click(() => {
            $('body, html').animate({ scrollTop: 0 }, 800);
        });


});

window.SiteType = location.href.indexOf('Young') > -1 ? 1 : 0;