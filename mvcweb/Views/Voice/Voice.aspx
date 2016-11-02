<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <title>ABC在线英语</title>
    <link href="<%=ViewBag.Path%>/static/css/student_voice.css" rel="stylesheet" />
    <link href="<%=ViewBag.Path%>/assets/css/StyleSheet1.css" rel="stylesheet" />
    <style>
        .page-title .divider {
            margin: 15px auto 0;
            width: 146px;
        }
    </style>
</head>
<body>
    <div class="banner"></div>
    <%  Html.RenderPartial("AdultNav", 6)%>
    <div class="section">
        <div class="page-title">
            <h1>STUDENTS VOICE</h1>
            <h2 class="sub-text">学员心声</h2>
            <div class="divider"></div>
            <p>
                无论是零基础学员，还是外教口语的学员，ABC在线都将为您打造完美的教学体验。<br />
                无论身处何地，ABC在线将品质教学带给每一个需要的学员；<br />
                追求学员的口碑和满意度，是我们不断追求的目标！

            </p>
        </div>
        <div class="container">
            <div class="student-feedback">
                <div class="row">
                </div>
            </div>
            <div class="ad ad-1">
                <h1 class="title">学员活动</h1>
                <h2 class="sub-text">线上学习不孤单，落地活动丰富多彩</h2>
                <div class="divider"></div>
                <p>
                    忙碌奔波完了一整个春天，你用什么来迎接夏季的到来？送走了撸串的时节，是时候用缤纷的PIZZA和酸甜的饮料迎来你爱的六月。<br />
                    ABC在线英语诚意邀请您，参加一场开心的落地趴。O2O的新鲜理念带你见到你一直好奇的屏幕里的那位在线英语学习管理师
                ！别忘了还有我们专业可爱的外教，带你了解西方饭桌礼仪，体验不一样的PIZZA盛会！PIZZA总念成"披萨"？总是用刀叉切着吃PIZZA？PIZZA到底怎么做？IF YOU ARE READY, COME &
                GET IT! NA NA NA NA... GET READY TO BE AMAZED IN ABC ONLINE ENGLISH.
                </p>
                <a class="btn btn-danger" href="">我要报名</a>
            </div>
        </div>
    </div>
</body>
<script src="<%=ViewBag.Path%>/js/jquery-1.8.3.min.js" type="text/javascript"></script>
<script src="<%=ViewBag.Path%>/js/base.js"></script>
<script src="<%=ViewBag.Path%>/js/common.js"></script>
<script src="<%=ViewBag.Path%>/js/voice.js"></script>
<script src="<%: Url.Content("~/assets/js/JavaScript1.js") %>"></script>
<script>

    $(function () {
        webAbc.bindPageImage(7,
            function (result) {
                if (result.length) {
                    var url = result[0].Url;
                    $('.banner').css('background-image', 'url(' + url + ')');
                }
            });
    });
</script>
</html>
