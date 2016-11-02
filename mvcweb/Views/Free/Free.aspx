<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <title>ABC在线英语</title>
     <link href="<%=ViewBag.Path%>/static/css/expert_faq.css" rel="stylesheet"/>
    <link href="<%=ViewBag.Path%>/assets/css/StyleSheet1.css" rel="stylesheet" />
    <script src="../../js/jquery-1.8.3.min.js"></script>
    <script src="../../js/base.js"></script>
    <script src="../../js/common.js"></script>
    <script src="../../js/free.js"></script>
    <script>
        window.onload = function () {
            if (!webAbc.judgeSystem()) {
                if (window.parent.$('iframe')[0]) {
                    window.parent.$('iframe')[0].style.height = '2000px';
                    window.parent.scrollTo(0, 0);
                }
            }
        }
        $(function () {
            webAbc.bindPageImage(5,
                function (result) {
                    if (result.length) {
                        var url = result[0].Url;
                        $('.banner').css('background-image', 'url(' + url + ')');
                    }
                });
        });
    </script>
</head>
<body>
   <div class="banner"></div>
<%  Html.RenderPartial("AdultNav", 4)%>
<div class="section">
    <div class="page-title">
        <h1>ABC EXPERT TEACHERS</h1>
        <div class="divider"></div>
        <p>
            ABC在线VIP学员享有专家老师在线答疑服务，随时随地解决学员在英语学习中遇到的问题，提升VIP学员用户体验！<br/>
更有在线客服为学员24小时解决问题，贴心服务！

        </p>
    </div>
    <div class="intro"></div>
    <div class="download-app">
        <div class="page-title">
            <h1>轻松下载，名师常伴左右</h1>
            <div class="divider"></div>
        </div>
        <div class="app-url">
            <a class="iphone"><img src="<%=ViewBag.Path%>/image/expert_faq/iphone.png" /></a>
            <a class="andriod"><img src="<%=ViewBag.Path%>/image/expert_faq/android.png" /></a>
        </div>
    </div>
</div>
    <script>
        window.parent.$('#ContentFrame').css({
            height: 2200
        });
    </script><script src="<%=ViewBag.Path%>/assets/js/JavaScript1.js"></script>
</body>
</html>
