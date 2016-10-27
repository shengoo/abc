<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <title>ABC在线英语</title>
    <link href="<%=ViewBag.Path%>/static/css/class_process.css" rel="stylesheet"/>
    <link href="<%=ViewBag.Path%>/assets/css/StyleSheet1.css" rel="stylesheet" />
    <script src="<%=ViewBag.Path%>/js/jquery-1.8.3.min.js"></script>
    <script src="<%=ViewBag.Path%>/js/base.js"></script>
    <script src="<%=ViewBag.Path%>/js/common.js"></script>
    <%--<script>
        $(document).ready(function () {
            webAbc.bindPageImage(6, function (results) {
                $('.ban')[0].style.backgroundImage = 'url(' + results[0].Url + ')';
            })
        })
    </script>--%>
</head>
<body>
<div class="banner"></div>
<%  Html.RenderPartial("AdultNav", 5)%>
<div class="section">
    <div class="container">
        <div class="page-title">
            <h1>LEARNING PROCEDURE</h1>
            <div class="divider"></div>
            <p>
                轻松注册，随时随地可以预约体验，让学习变得更舒适自在。
            </p>
        </div>
        <div class="arrange"></div>
    </div>
</div>
    <script>
        window.parent.$('#ContentFrame').css({
            height: 1900
        });
    </script><script src="<%=ViewBag.Path%>/assets/js/JavaScript1.js"></script>
</body>
</html>
