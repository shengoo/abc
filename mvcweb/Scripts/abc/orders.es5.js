'use strict';

$(function () {
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
    //if (this.myOrderReadyStatus) return;
    //this.myOrderReadyStatus = true;
    var oldOrder;
    list.on('click', function (e) {
        var je = $(e.target),
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
            html += '</table><div class="order-item-total">' + total + '</div>' + '<div class="order-item-operation">' + (!oitem.TradeNo ? '<a class="operation btn" data="' + order.No + '" action="zhifu">支付</a>' + '<a class="operation btn" data="' + order.No + '" action="quxiao">取消</a>' : '<a class="operation btn" action="nothing" disabled>已完成</a>') + '</div></div>';

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
            webAbc.autoAjustIframeHeight();
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
});

