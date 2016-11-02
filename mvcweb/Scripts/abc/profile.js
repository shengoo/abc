$(() => {

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
            } else if (name == 'email' && (!/^\w{1,16}@\w{1,10}[.]+\w{1,5}$/.test(value))) {
                err.addClass('error');
                el.addClass('error');
            }
        }
    });

    sig.find('.btn').click(function () {
        var els = sig.find('input');
        if ($(els[4]).hasClass('error')) {
            webAbc.showMessage(2, '请输入正确的生日！');
            return;
        }
        if ($(els[0]).hasClass('error')) {
            webAbc.showMessage(2, '请输入正确的中文名！');
            return;
        }
        if ($(els[1]).hasClass('error')) {
            webAbc.showMessage(2, '请输入正确的英文名！');
            return;
        }
        if (els.hasClass('error')) {
            webAbc.showMessage(2, '请输入正确的用户信息！');
            return;
        }
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

});