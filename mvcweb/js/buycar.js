
function setTotalPrice(price) {
    price = price.toFixed(2);
    if (price.indexOf("-") > -1) {
        price = 0.00;
    }
    $('.total_price')[0].innerHTML = '￥ ' + price + ' 元';
}


$(document).ready(function () {
    var tprice = 0.00;

    window.carts = [];

    $('.continue_buy').click(function () {
        location.href = $.url + '/BuyClass/BuyClass';
    });

    //全选 反选
    $('.chk_car div').click(function () {
        var el = this,
            type = el.attributes.data_ischeck.value;

        $('input[type="checkbox"]').prop({ checked: type == "true" })
        tprice = 0;
        if (type == "true") {
            window.carts.forEach(function (cart) {
                tprice += cart.Price * cart.Number;
            })
        }
        setTotalPrice(tprice);
    });

    //批量删除
    $('.batch_delete').click(function () {
        var el = this,
            cartIds = [],
            cartEls = $('input[type="checkbox"]'),
            checkEls = [];

        cartEls.each(function (index, el) {
            if (el.checked) {
                checkEls.push(el);
                cartIds.push(parseInt(el.value));
            }
        });
        if (cartIds.length == 0) {
            webAbc.showMessage(2, '请选择不少于一张课程卡删除！')
            return;
        }

        layer.confirm('您确认需要删除选中的课程卡吗?', {
            btn: ['确定', '取消'] //按钮
        }, function () {
            webAbc.ajax({
                url: '/BuyClass/DelCart',
                data: { carts: cartIds.join(',') },
                success: function () {
                    var sycarts = [];
                    checkEls.forEach(function (el) {
                        el.parentElement.parentElement.remove();
                    });
                    window.carts.forEach(function (cart) {
                        if (cartIds.indexOf(cart.Id) < 0) {
                            sycarts.push(cart);
                        }
                    })
                    window.carts = sycarts;
                    tprice = 0;
                    setTotalPrice(tprice);
                    if (window.carts.length == 0) {
                        $('.car_nogoods').removeClass('hidden');
                        $('.car_bottom').addClass('hidden');
                    }
                    layer.closeAll();
                }
            });
        }, function () {
            layer.closeAll();
        });
    })

    webAbc.ajax({
        url: '/BuyClass/GetBuyCart',
        dataType: 'json',
        success: function (results) {
            var str = '';
            window.carts = results;

            $(window.carts.length ? '.car_bottom' : '.car_nogoods').removeClass('hidden');
            window.carts.forEach(function (item) {
                str += '<li><div class="chk_car flt"><input type="checkbox" checked=true value="' + item.Id +
                    '"></div><div class="car_name flt">' + item.CardName + '</div><div class="car_opera frt"><div class="car_del" data_id="' + item.Id + '" >删除</div></div><div class="car_number frt">' + item.Number + '</div><div class="car_price frt">' + item.Price + '</div><div class="car_gift frt">' + (item.GiftNames ? item.GiftNames : "") + '</div></li>';
                tprice += item.Price * item.Number;
            });

            setTotalPrice(tprice);
            $('.ul_car').append($(str));

            //删除订单
            $('.car_del').click(function () {
                var el = this, cartId = $(el).attr('data_id');
                $.ajax({
                    url: $.url + '/BuyClass/DelCart',
                    type: 'post',
                    data: { carts: cartId },
                    dataType: 'json',
                    success: function (rel) {
                        if (rel.IsSuccess) {
                            var row = $(el.parentElement.parentElement);
                            var i = 0, cart;
                            for (; i < window.carts.length; i++) {
                                cart = window.carts.pop();
                                if (cart.Id == cartId) {
                                    break;
                                }
                                window.carts.unshift(cart);
                            }
                            if (row.find('input')[0].checked) {
                                tprice = tprice - (cart.Price * cart.Number);
                            }
                            row.remove();
                            setTotalPrice(tprice);
                        }
                    }
                });
            });

            $('button').click(function () {
                var el = this,
                    action = el.attributes.method ? el.attributes.method.value : '';

                if (action == "account") {
                    var data = [];
                    var chks = $('.chk_car input');
                    chks.each(function (index, chk) {
                        if (chk.checked) {
                            for (var i = 0; i < window.carts.length; i++) {
                                if (window.carts[i].Id == chk.value) {
                                    data.push(window.carts[i]);
                                    break;
                                }
                            }
                        }
                    });
                    if (data.length == 0) {
                        webAbc.showMessage(2, '请选择至少一个课程卡！');
                        return;
                    }
                    webAbc.ajax({
                        url: '/BuyClass/AccountCart',
                        data: { carts: JSON.stringify(data) },
                        success: function (rel) {
                          //  alert(1111111111);
                            //layer.msg('订单支付结果确认', {
                            //    //  time: 20000, //20s后自动关闭
                            //    btn: ['支付成功', '支付失败']
                            //});
                            //  window.open("/BuyClass/BuyCarSubmit?orderNo=" + rel, "_blank");
                            window.location.href = '/BuyClass/BuyCarSubmit?orderNo=' + rel;
                        }
                    });
                }
            });

            $('input[type="checkbox"]').change(function () {
                var el = this;
                for (var i = 0; i < window.carts.length; i++) {
                    if (window.carts[i].Id == el.value) {
                        if (el.checked) {
                            tprice += window.carts[i].Price * window.carts[i].Number;
                        } else {
                            tprice -= window.carts[i].Price * window.carts[i].Number;
                        }
                        break;
                    }
                }

                setTotalPrice(tprice);
            });
        }
    });
})