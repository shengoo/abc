<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ABC在线英语</title>
    <link href="<%=ViewBag.Path%>/static/css/index.css" rel="stylesheet"/>
    <script type="text/javascript" src="<%=ViewBag.Path%>/js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="<%=ViewBag.Path%>/js/common.js"></script>
    <script type="text/javascript" src="<%=ViewBag.Path%>/js/base.js"></script>
    <script type="text/javascript">
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
<div class="banner"></div>
<div class="nav">
    <ul>
        <li class="active">
            <a href="<%=ViewBag.Path%>/Home/Home">首页</a>
        </li>
        <li>
            <a href="<%=ViewBag.Path%>/Open/Open">免费课程</a>
        </li>
        <li>
            <a href="<%=ViewBag.Path%>/Feature/Feature">课程特色</a>
        </li>
        <li>
            <a href="<%=ViewBag.Path%>/Team/Team">外教团队</a>
        </li>
        <li>
            <a href="<%=ViewBag.Path%>/Free/Free">免费答疑</a>
        </li>
        <li>
            <a href="<%=ViewBag.Path%>/Flow/Flow">上课流程</a>
        </li>
        <li>
            <a href="<%=ViewBag.Path%>/Voice/Voice">学员心声</a>
        </li>
         <li class="no-border">
            <a id="hidTab" href="<%=ViewBag.Path%>/MyContent/MyContent">个人中心</a>
        </li>
    </ul>
</div>
<div class="section">
    <div class="ad ad-1">
        <div class="container">
            <h1 class="title">WELCOME TO ABC</h1>
            <h2 class="sub-text">SOME GREAT FACTS</h2>
            <div class="divider"></div>
            <div class="pc">
                <img src="<%=ViewBag.Path%>/image/index/pc.png"/>
                <div class="img-text">
                    <p class="first">中国首家100%美加外教在线教育平台</p>
                    <p class="second">王牌零起点课程，从零开始不用怕，四个月流利口语脱口而出</p>
                    <p class="third">高效率的培训模式，网上真人教学一对一效果更好</p>
                    <p class="fourth">五星级学管团队全程监督学习效果，还有丰富课外内容供您选修</p>
                    <p class="fifth">独特的教育手段，"兴趣教学法"让你享受学习的乐趣</p>
                    <p class="sxith">20年强大的线下实体教学累计，学员满意度99.2%</p>
                </div>
            </div>
            <div class="why">
                <h2>Why Choose ABC</h2>
                <p>
                    ABC远程，隶属于ABC教育集团。以遍布全国的近30家实体教学中心为依托，数十万优秀学员卓越学习成果是ABC创建20余年来程碑似的见证。"神奇的音标教学法"、"兴趣教学法"、"动感教学法"和"三维口语训练法"，是ABC独创的英语教学方法，帮助了无数学员从被动学习到主动灵活学习。
                </p>
            </div>
        </div>
    </div>
    <div class="ad ad-2">
        <div class="container">
            <h1 class="title">WHAT WE OFFER</h1>
            <h2 class="sub-text">SOME GREAT FACTS</h2>
            <div class="divider"></div>
            <div class="plan">
                <dl>
                    <dt>
                        <img src="<%=ViewBag.Path%>/image/index/red.png" alt="">
                    </dt>
                    <dd>
                        <h3>零基础学习方案</h3>
                        <p>五大模块基础学习<br/>循序渐进,生动形象<br/>打造完美发音体系</p>
                    </dd>
                </dl>
                <dl>
                    <dt>
                        <img src="<%=ViewBag.Path%>/image/index/blue.png" alt="">
                    </dt>
                    <dd>
                        <h3>实用口语提升方案</h3>
                        <p>常用情景再现，身临其境<br/>课后人物卡，输入输出同步进行<br/>科学方法、从词汇到句型</p>
                    </dd>
                </dl>
                <dl>
                    <dt>
                        <img src="<%=ViewBag.Path%>/image/index/orange.png" alt="">
                    </dt>
                    <dd>
                        <h3>旅游英语速成方案</h3>
                        <p>经典城市介绍<br/>旅游攻略情景再现<br/>常见问题解答</p>
                    </dd>
                </dl>
                <dl>
                    <dt>
                        <img src="<%=ViewBag.Path%>/image/index/green.png" alt="">
                    </dt>
                    <dd>
                        <h3>刘学英语专项方案</h3>
                        <p>托福，雅思，私人定制<br/>外教全程授课、模拟<br/>学管师全程管理、辅助</p>
                    </dd>
                </dl>
                <dl>
                    <dt>
                        <img src="<%=ViewBag.Path%>/image/index/purple.png" alt="">
                    </dt>
                    <dd>
                        <h3>商务英语突破方案</h3>
                        <p>商务词汇拓展<br/>商务背景资深外教匹配<br/>现实案例分析</p>
                    </dd>
                </dl>
            </div>
        </div>
    </div>
    <div class="ad-3">
        <div class="container">
            <div class="reg-text">
                <h1>立即注册,免费试听?</h1>
                <p>名额仅剩50名</p>
            </div>
            <div class="reg-button">
                <button class="reg">会员注册</button>
                OR
                <button class="contact-us">联系我们</button>
            </div>
        </div>
    </div>
    <div class="ad ad-4">
        <div class="container">
            <h1 class="title">专业外教精彩课堂</h1>
            <h2 class="sub-text">学英语、找学校、老师最重要</h2>
            <div class="divider"></div>
            <div class="course">
                <div class="each-course active">
                    <div class="course-img" style="background-image: url(../image/index/course_1.png)">
                        <!--<img src="../image/index/course_1.png" alt="">-->
                        <div class="course-mask">
                            <div class="mask"></div>
                            <i class="play"></i>
                        </div>
                    </div>
                    <div class="course-feature">
                        <i class="caret"></i>
                        <h5>中国首家100%美加外教授课</h5>
                        <div class="course-intro">
                            <h6>坚持一对一教学为主</h6>
                            <p>
                                1对1，ABC远程最核心教学方式！专业中外籍师资集多年线上线下教学经验，根据您的个性化学习方案，专业教学帮助您实现高效学习效果！
                            </p>
                            <a class="btn">了解更多</a>
                        </div>
                    </div>
                </div>
                <div class="each-course">
                    <div class="course-img" style="background-image: url(../image/index/course_2.png)">
                        <!--<img src="" alt="">-->
                        <div class="course-mask">
                            <div class="mask"></div>
                            <i class="play"></i>
                        </div>
                    </div>
                    <div class="course-feature">
                        <i class="caret"></i>
                        <h5>坚持真人在线授课</h5>
                        <div class="course-intro">
                            <h6>20年强大的线下实体教学积累</h6>
                            <p>
                                零起点也有王牌课程解决方案，选择ABC远程"一对六中外教小班授课"给您最佳互动课堂！让您在同学的"英文头脑风暴"中获得更多新鲜IDEA和表达方式！
                            </p>
                            <a class="btn">了解更多</a>
                        </div>
                    </div>
                </div>
                <div class="each-course">
                    <div class="course-img" style="background-image: url(../image/index/course_3.png)">
                        <!--<img src="" alt="">-->
                        <div class="course-mask">
                            <div class="mask"></div>
                            <i class="play"></i>
                        </div>
                    </div>
                    <div class="course-feature">
                        <i class="caret"></i>
                        <h5>五星级学管团队全程监督</h5>
                        <div class="course-intro">
                            <h6>学员满意度99.2%</h6>
                            <p>
                                五星级血管团队全程监督学习效果，监督开始到结束的每一细节，做到对整个培训的全面控制，还有丰富的课外内容供您选择，多年教学学员，满意度高达99.2%！
                            </p>
                            <a class="btn">了解更多</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="ad ad-5">
        <div class="container">
            <h1 class="title">国内顶尖优秀学管师</h1>
            <h2 class="sub-text">五星级学习管理师全程跟踪</h2>
            <div class="divider"></div>
            <div class="tutor">
                <div class="each-tutor">
                    <div class="tutor-img">
                        <img src="<%=ViewBag.Path%>/image/index/tutor_1.png" alt="">
                    </div>
                    <div class="tutor-feature">
                        <h5>学管师：ROSA</h5>
                        <p>
                            ABC五星级学习管理师<br>擅长播音和托福英语
                        </p>
                    </div>
                </div>
                <div class="each-tutor">
                    <div class="tutor-img">
                        <img src="<%=ViewBag.Path%>/image/index/tutor_2.png" alt="">
                    </div>
                    <div class="tutor-feature">
                        <h5>学管师：SUSIE</h5>
                        <p>
                            ABC五星级学习管理师<br>热衷地道口语和美剧
                        </p>
                    </div>
                </div>
                <div class="each-tutor active">
                    <div class="tutor-img">
                        <img src="<%=ViewBag.Path%>/image/index/tutor_hover_img.png" alt="">
                    </div>
                     <div class="font">立即预约</div>
                    <div class="tutor-feature">
                        <h5>学管师：KATE</h5>
                        <p>
                            ABC五星级学习管理师<br>热衷地道口语和美剧
                        </p>
                    </div>
                </div>
                <div class="each-tutor">
                    <div class="tutor-img">
                        <img src="<%=ViewBag.Path%>/image/index/tutor_3.png" alt="">
                    </div>
                    <div class="tutor-feature">
                        <h5>学管师：TINA</h5>
                        <p>
                            ABC五星级学习管理师<br>专注英语教学十年
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="ad ad-6">
        <div class="container">
            <h1 class="title">我们的荣誉</h1>
            <h2 class="sub-text">在誉20余年致力打造品质教学</h2>
            <div class="divider"></div>
            <div class="honor">
                <div class="slide">
                    <i class="prev"></i>
                    <img class="center-prev-2" src="<%=ViewBag.Path%>/image/index/honor_1.png" alt="">
                    <img class="center-prev-1" src="<%=ViewBag.Path%>/image/index/honor_2.png" alt="">
                    <img class="center" src="<%=ViewBag.Path%>/image/index/honor_3.png" alt="">
                    <img class="center-next-1" src="<%=ViewBag.Path%>/image/index/honor_4.png" alt="">
                    <img class="center-next-2" src="<%=ViewBag.Path%>/image/index/honor_5.png" alt="">
                    <i class="next"></i>
                </div>
            </div>
        </div>
    </div>
    <div class="ad ad-7">
        <div class="container">
            <h1 class="title">我们的客户</h1>
            <h2 class="sub-text">与全国多家品牌名企战略合作</h2>
            <div class="divider"></div>
            <div class="client">
                <div class="row">
                    <i class="client-icon cctv"></i>
                    <i class="client-icon lg"></i>
                    <i class="client-icon benz"></i>
                    <i class="client-icon dasauto"></i>
                    <i class="client-icon symantec"></i>
                </div>
                <div class="row">
                    <i class="client-icon baidu"></i>
                    <i class="client-icon tencent"></i>
                    <i class="client-icon sina"></i>
                    <i class="client-icon netEase-mail"></i>
                    <i class="client-icon netEase-edu"></i>
                </div>
                <div class="row">
                    <i class="client-icon china"></i>
                    <i class="client-icon youdao"></i>
                    <i class="client-icon qihu"></i>
                    <i class="client-icon golf"></i>
                    <i class="client-icon sohu"></i>
                </div>
            </div>
        </div>
    </div>
</div>
</body>
</html>
