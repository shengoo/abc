<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ABC在线英语</title>
    <link href="<%=ViewBag.Path%>/static/css/MyContent.css" rel="stylesheet"/>
     <script type="text/javascript" src="<%=ViewBag.Path%>/js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="<%=ViewBag.Path%>/js/common.js"></script>
    <script type="text/javascript" src="<%=ViewBag.Path%>/js/base.js"></script>
    <script>
        window.onload = function () {
            if (!webAbc.judgeSystem()) {
                if (window.parent.$('iframe')[0]) {
                    window.parent.$('iframe')[0].style.height = '4600px';
                    window.parent.scrollTo(0, 0);
                }
            }
        }
        $(document).ready(function () {
            $("#courseinfodiv").find("a").click(function (event) {
                var url = "<%=ViewBag.VideoUrl%>";
                layer.open({
                    type: 2,
                    //fix :false,
                    offset: '800px',
                    title: '<img src="../../Content/img/logo_new.png"  style="float:left;" height="36px" />',
                    shadeClose: true,
                    shade: 0.5,
                    area: ['800px', '443px'],
                    content: [url, 'no']//iframe的url
                });
            });
        })
            webAbc.bindPageImage(1, function (results) {
                $('.slide img').each(function (index, el) {
                    var imgs = results.filter(function (image) { return image.OrderBy == index; });
                    if (imgs.length > 0)
                        el.src = imgs[0].Url;
                })
            });

    </script>
</head>
<body>
   <div class="slider">
    <div class="slider-box">
        <div class="slider-one">
            <span>信息</span>
            <span class="close">X</span>
        </div>
         <div class="slider-two">
            <div class="box-one">
                <div class="slider-img"></div>
                <p>加入购物车成功</p>
            </div>
            <div class="box-two">
                 <div class="play-btn btn_a">
                前去结算
                </div>
               <div class="play-btn btn_b">
                继续购卡
               </div>
            </div>
        </div>
    </div>
</div>
<div class="section">
    <div class="ad ad-1">
        <div class="container">
            <div class="page-title">
                <h1>MY ORDERS</h1>
                <div class="divider"></div>
                <ul class="teacher-type">
                    <li class="active">VIP一对一授课</li>
                    <li>一对六小班授课</li>
                    <li>超级大课堂</li>
                </ul>
            </div>
            <div class="free-course">
                <div class="each-media">
                    <div class="media-img">
                        <img src="<%=ViewBag.Path%>/image/index/women.png" />
                    </div>
                    <div class="media-text">
                        <h5>VIP一对一授课</h5>
                        <div class="line">高性价比</div>
                        <p>总价&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;：&nbsp;&nbsp;&nbsp;￥<span class="oll">28800</span>元
                        </p>
                        <div class="tc-box">
                            <p>课程套餐：</p>
                            <div class="option active">一年套餐</div>
                            <div class="option">两年套餐</div>
                            <div class="option">两年超值套餐</div>
                            <div class="option">三年劲爆套餐</div>
                        </div>
                         <div class="xq-box">
                            <div class="petion">
                                 <div class="hezi">课程详情：</div>
                                <p>核心课100次</p>
                                <p>实践课80次</p>
                            </div>
                            <div class="mation">
                                <p>浸泡文化课365次</p>
                                <p>浸泡文化课365次</p>
                            </div>
                        </div>
                        <div class="tool">
                            <div class="play-btn btn_a">加入购物车</div>
                            <div class="play-btn btn_b">查看购物车</div>
                        </div>
                    </div>
                </div>
            </div>
             <div class="free-cours">
                <div class="each-media">
                    <div class="media-img">
                        <div class="divid">套餐详情</div>
                        <div class="media-text"></div>
                    </div>
                    <div class="media-box">
                        <ul>
                            <li class="each-row line">
                                 <div class="mate-box">
                                    <div class="mate">核心课、一对一VIP课程
                                    </div>
                                </div>
                                <div class="matp">
                                   <div class="divid"></div>
                                   <p>中教每堂60分钟</p>
                                   <div class="divia"></div>
                                   <div class="divio"></div>
                                   <p>外教每堂60分钟</p>
                                </div>
                            </li>
                            <li class="each-row but line">
                                <div class="mate-box">
                                    <div class="mate">浸泡文化课/大课堂形式
                                </div>
                                </div>
                                 <div class="matp ri">
                                   <div class="divid"></div>
                                   <p>每堂课20分钟，固定时间上课</p>
                                    <div class="divid"></div>
                                   <p>练习听力为主，不可语音互动</p>
                                </div>
                            </li>
                            <li class="each-row line">
                                 <div class="mate-box">
                                    <div class="mate">实践课/一对六外教课程
                                    </div>
                                </div>
                                <div class="matp">
                                  <div class="divio"></div>
                                   <p>一对六外教课程</p>
                                    <div class="divia"></div>
                                   <p>每堂45分钟，小班互动</p>
                                </div>
                            </li>
                            <li class="each-row but">
                                 <div class="mate-box">
                                    <div class="mate">评估课/专业学管师测评
                                    </div>
                                </div>
                                <div class="matp ri ur">
                                   <div class="divid"></div>
                                   <p>专业学管老师每个月测评一次，每次20-30分钟，随时掌握学员效果成人重点考核效果展示，青少年重点考核近期所学内容</p>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</body>
</html>
