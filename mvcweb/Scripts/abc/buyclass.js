function showtab(index, evt) {
    var e = window.event || evt,
        el = e.target;
    $('.col_tab_ul2 li').removeClass('on');
    $(el).addClass('on');
    if (index == 1) {
        $('.m2eBox').eq(0).removeClass('hidden');
        $('.m2eBox').eq(1).addClass('hidden');
    } else {
        $('.m2eBox').eq(1).removeClass('hidden');
        $('.m2eBox').eq(0).addClass('hidden');
    }
}
var csssuit = function () {
    var l = ($(".gift_select [class=giftcard]").length / 2).toFixed();
    //$("#label_addcard").height(($("#label_addcard").height() + l * 35) + "px");
    $("#label_addcard").height((140 + l * 35) + "px");
    // debugger;
    if (l > 4) {
        $(".col_tab_ul2").css("margin-top", ((10 + l * 35 - 40) + "px"));
        //$("#ContentFrame", window.parent.document).height((650 + l * 35) + "px");
        $("#ContentFrame", window.parent.document).height((1800 + l * 35) + "px");

        $(".price").css("margin-top", ((10 + (l - 1) * 35) + "px"));
    }
    else {
        $(".col_tab_ul2").css("margin-top", 10 + "px");
        $(".price").css("margin-top", 10 + "px");
        //$("#ContentFrame", window.parent.document).height(650 + "px");
        $("#ContentFrame", window.parent.document).height(1800 + "px");
    }
}

$(document)
    .ready(function() {
        window.parent.scrollTo(0, 0);
        webAbc.updateFrameHeight(1850);
        var card = null;

        function tabClick() {
            //var tabA = $('.col_tab_ul li'),
            var tabA = $('.tab li'),
                query = webAbc.getUrlQuery(window.location.search),
                oldEl = null;

            tabA.click(function() {
                var el = this,
                    category = $(el).attr('data'),
                    text = el.innerHTML;

                if (oldEl && oldEl[0] == el) return;

                $.ajax({
                    url: '/BuyClass/GetCourseCard',
                    data: { type: category, cardtypeid: window.parent.SiteType == 1 ? 1 : 2 },
                    dataType: 'json',
                    type: 'post',
                    success: res => {
                        if (!res.IsSuccess) {
                            showMessage(2, "获取课程卡信息失败！" + res.ErrMsg);
                            return;
                        }
                        var rel = res.Result;
                        if (rel.length == 0) {
                            showMessage(1, "尚未开课！敬请期待！");
                            return;
                        };
                        var data = {
                            title: text,
                            img: $.url + '/Images/' + rel[0].Thunm,
                            cika: [],
                            yueka: []
                        }

                        var str = '', time = '', type = '', strYueka = '';
                        for (var i = 0; i < rel.length; i++) {
                            if (data.cika.length == 0)
                                str += '<div data="1" name="type" class="course flt" ><b></b>次卡</div>';

                            time += '<div type="' +
                                rel[i].CardId +
                                '" name="time"  class="course flt" ><b></b>' +
                                rel[i].CardName +
                                '</div>';
                            data.cika.push({
                                CardId: rel[i].CardId,
                                category: rel[i].CardName,
                                price: rel[i].Price,
                                ClassContent: rel[i].ClassContent,
                                Discount: rel[i].Discount
                            });
                        }
                        str += strYueka;
                        //oldEl && oldEl.removeClass("selector");
                        //$(el).addClass("selector");
                        oldEl && oldEl.removeClass("active");
                        $(el).addClass("active");
                        oldEl = $(el);

                        $('.coursetitle')[0].innerHTML = data.title;
                        $('.courseinfo')[0].innerHTML = '';
                        $('.courseinfo')
                            .append($('<div class="clearfix"><ul class="course_ul clearfix">' +
                                '<li class="clearfix"><div class="hidden coursetype"><div class="course_t flt">课程类型：</div>' +
                                str +
                                '</div></li>' +
                                (time == ''
                                    ? ''
                                    : '<li name="1" class="clearfix"><div class="coursetype">' +
                                    '<div class="course_t flt label-left" style="height:' +
                                    (rel.length > 4 ? '70px' : '30px') +
                                    '">课程套餐</div>' +
                                    time +
                                    '</div></li>') +
                                (type == ''
                                    ? ''
                                    : '<li name="2" class="clearfix hidden" ><div class="coursetype"><div class="course_t flt label-left">课程套餐</div>' + type + '</div></li>') +
                                '</ul></div>'));

                        var courseType = $('.course[name="type"]'),
                            oldLi = null,
                            oldType = null;
                        courseType.click(function() {
                            var el = this,
                                je = $(el); //1:次卡2:月卡

                            if (oldType == je) return;
                            oldType && oldType.removeClass('selector');
                            oldType = je;
                            oldType.addClass('selector');
                            oldLi && oldLi.addClass('hidden');
                            oldLi = $('.course_ul li[name="' + oldType.attr('data') + '"]');
                            oldLi.removeClass('hidden');

                            $('.course_ul li[name="' + oldType.attr('data') + '"] .course').eq(0).click();
                        });

                        var courseTime = $('.course[name="time"]'),
                            oldTime = null;
                        courseTime.click(function() {
                            var el = this,
                                je = $(el),
                                cardId = je.attr('type');

                            if (oldTime == je) return;
                            oldTime && oldTime.removeClass('selector');
                            oldTime = je;
                            oldTime.addClass('selector');

                            var datas = oldType.attr('data') == "1" ? data.cika : data.yueka;
                            for (var i = 0; i < datas.length; i++) {
                                if (datas[i].CardId == cardId) {
                                    card = datas[i];

                                    //$('.m2eBox').eq(0).html('<img style="width: 98%;height: 130px;padding-left: 10px; padding-top: 2px;" src=' + (card.ClassContent || '') + '>');

                                    $('.m2eBox')
                                        .eq(0)
                                        .html('<img style="width: 98%;height: 600px;padding-left: 10px; padding-top: 2px;" src="' + (card.ClassContent || '/assets/image/class-intro.png') + '">');

                                    //$('.m2eBox').eq(1).html('<p>' + (card.Discount || '暂无') + '</p>');
                                    $.ajax({
                                        url: $.url + '/BuyClass/GetCourseGift',
                                        type: 'post',
                                        data: { cardId: datas[i].CardId },
                                        success: function(rel) {
                                            var str = '';
                                            if (rel.IsSuccess && rel.Result.length > 0) {
                                                rel.Result.forEach(function(item) {
                                                    str += "<div class='giftcard' value='" +
                                                        item.CardId +
                                                        "'><b></b>" +
                                                        item.CardName +
                                                        "</div>";
                                                });
                                                $('.gift').removeClass('visible');
                                            } else {
                                                $('.gift').addClass('visible');
                                            }
                                            if (rel.Result.length > 3) {
                                                $('#label_addcard')
                                                    .css({
                                                        height: '70px'
                                                    });
                                            } else {
                                                $('#label_addcard')
                                                    .css({
                                                        height: '30px'
                                                    });
                                            }
                                            $('.gift_select').html(str);


                                            csssuit();
                                        }
                                    });
                                    $('.number_input')[0].value = 1;
                                    $('.number_input')[0].style.borderColor = '';
                                    $('.price_num')[0].innerHTML = card.price;


                                    break;
                                }
                            }

                        });
                        courseType.eq(0).click();


                    }
                });
            });

            tabA.eq(query ? query['action'] : 0).click();
        };


        $.ajax({
            url: $.url + '/BuyClass/GetCourseCategory',
            type: 'post',
            dataType: 'json',
            success: function(res) {
                if (!res.IsSuccess) {
                    showMessage(2, "获取课程卡种类失败！" + res.ErrMsg);
                    return;
                }
                var str = '',
                    categorys = res.Result;
                for (var i = 0; i < categorys.length; i++)
                    str += '<li data="' + categorys[i].Code + '">' + categorys[i].CategoryName + '</li>';

                //$('.col_tab_ul').append($(str));
                $('.tab').append($(str));
                tabClick();
            }
        });

        $('.buy')
            .click(function() {
                var el = this,
                    method = el.attributes.method.value;

                if (method == 'buy') {
                    var number = parseInt($('.number_input')[0].value);

                    if (card == null || $('.number_input')[0].style.borderColor != '') {
                        showMessage(2, '请输入有效的购买数量！');
                        return;
                    }
                    webAbc.ajax({
                        url: '/BuyClass/BuyCart',
                        data: {
                            cardId: card.CardId,
                            number: number
                        },
                        success: function(rel) {
                            //webAbc.showMessage(1, '加入购物车成功！');


                            //function showMessage(type, message, fn) {
                            //<sumary>公共提示信息</sumary><param name="type" type="number">1:提示;2:警告;3:错误;4:判断</param>
                            var layer = window.top.layer || window.layer;
                            if (layer) {
                                layer.alert('加入购物车成功！',
                                    {
                                        btn: ['前去结算', '继续购卡'],
                                        icon: 1,
                                        title: ' ',
                                        area: ['477px', '257px'],
                                        move: false,
                                        shadeClose: true,
                                        skin: 'layer-ext-abccart' //该皮肤由layer.seaning.com友情扩展。关于皮肤的扩展规则，去这里查阅
                                        , yes: function (index, layero) {
                                            console.log('yes')
                                            layer.closeAll();
                                            location.href = $.url + '/BuyClass/BuyCar';
                                        }
                                    },
                                    function (index, layero) {
                                        console.log('callback')
                                        layer.closeAll();
                                    }
                                );
                            } else {
                                showMessage(type, message);
                            }
                            //}


                        }
                    });
                } else {
                    if (window.parent.CurrentUser.Type == 1) {
                        location.href = $.url + '/BuyClass/BuyCar';
                    } else {
                        showMessage(2, '非学员不能购卡！');
                    }
                }
            });

        $('.plus')
            .click(function() {
                $('.number_input').attr('value', parseInt($('.number_input').val()) + 1);
                $('.price_num').html(card.price * $('.number_input').val());
            });

        $('.reduce')
            .click(function() {
                $('.number_input').attr('value', parseInt($('.number_input').val()) - 1 || 1);
                $('.price_num').html(card.price * $('.number_input').val());
            })

        $('.number_input')
            .on('change',
                function() {
                    var el = this;

                    if (/^[1-9]\d{0,2}$/.test(el.value))
                        el.style.borderColor = '';
                    else
                        el.style.borderColor = '#f00';
                });

    });

function showMessage(type, message) {
    var layer = window.top.layer || window.layer;
    if (layer) {
        layer.alert(message, {
            icon: type || 1,
            title: ' ',
            move: false,
            shadeClose: true,
            area: ['477px', '257px'],
            skin: 'layer-ext-abccart'
            //offset:"150px"
        });
    }
    else {
        window.parent.showMessage(type, message);
    }
}