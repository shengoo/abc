
console.log('buy')
$(document).ready(function () {
    setTimeout(function () {
        //var height = $('.content')[0].clientHeight;
        var height = document.body.scrollHeight;
        console.log(height)
        window.parent.$('#ContentFrame').css({
            height: height + 100
        });
    }, 100);

    $('.pay_normal').click(function () {
        var el = $(this);

        $('.pay_normal').removeClass('selector');
        el.addClass('selector');
        el.find('input')[0].checked = true;
    })

    $('.btn').click(function () {
        var paytype = '';
        $('input[name="payMethod"]').each(function (Index, el) {
            if (el.checked)
                paytype = el.value;
        })
        var url = "/BuyClass/PayAccount?payType=" + paytype + "&orderNo=" + orderNo;
        if (paytype == 'weixin') {
            window.location.href = url;
        } else {
            //iframe层
            layer.open({
                type: 2,
                title: '支付结果确认',
                shadeClose: true,
                shade: 0.5,
                area: ['600px', '360px'],
                content: ['/BuyClass/PayConfirm', 'no']//iframe的url
            });
            window.open(url, "_blank");
        }
    })
})