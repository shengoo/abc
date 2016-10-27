<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ABC在线英语</title>
    <link href="<%=ViewBag.Path%>/static/css/Purchase.css" rel="stylesheet"/>
    <script>
        window.parent.$('#ContentFrame').css({
            height: 1300
        });
    </script>
</head>
<body>
<div class="banner_one"></div>
<div class="nav_box">
    <ul>
        <li>
            <a href="<%=ViewBag.Path%>/Home/index">首页</a>
        </li>
        <li>
            <a href="<%=ViewBag.Path%>/Home/index">个人设置</a>
        </li>
        <li class="active">
            <a href="<%=ViewBag.Path%>/Purchase/Purchase">课程管理</a>
        </li>
        <li>
            <a href="<%=ViewBag.Path%>/Home/index">我的订单</a>
        </li>
         <li>
            <a href="<%=ViewBag.Path%>/MyContent/MyContent">购买课程</a>
        </li>
        <li>
            <a href="<%=ViewBag.Path%>/Home/index">专家答疑</a>
        </li>
        <li class="no-border">
            <a href="<%=ViewBag.Path%>/Option/Option">常见问题</a>
        </li>
    </ul>
</div>
<div class="section">
    <div class="ad ad-1">
        <div class="container">
            <div class="page-title">
                <h1>COURSE MANAGEMENT</h1>
                <div class="divider"></div>
                <ul class="teacher-type">
                     <li class="active"><a href="<%=ViewBag.Path%>/Purchase/Purchase">我的卡次</a></li>
                    <li><a href="<%=ViewBag.Path%>/PurchaseNo/PurchaseNo">我的课程</a></li>
                    <li><a href="<%=ViewBag.Path%>/PurchaseTo/PurchaseTo">我的课表</a></li>
                    <li><a href="<%=ViewBag.Path%>/PurchaseTh/PurchaseTh">课后评分</a></li>
                </ul>
            </div>
            <div class="free-course">
            	<div class="each-media">
            	   <table class="extb">
                      <tr class="odd add">
                       <td class="opp">序号</td>
                       <td>课程卡编号</td>
                       <td>课程卡类型</td>
                       <td>课程卡名称</td>
                       <td>课程名称</td>
                       <td>课程类型</td>
                       <td>卡次总数</td>
                       <td>剩余次数</td>
                       <td>截止有限期</td>
                      </tr>
                      <tr>
                       <td class="opp"></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                      </tr>
                        <tr class="odd">
                       <td class="opp"></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                      </tr>
                      <tr>
                       <td class="opp"></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                      </tr>
                      <tr class="odd">
                       <td class="opp"></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                      </tr>
                        <tr>
                       <td class="opp"></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                      </tr>
                       <tr class="odd">
                       <td class="opp"></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                      </tr>
                        <tr>
                       <td class="opp"></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                      </tr>
                       <tr class="odd">
                       <td class="opp"></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                       <td></td>
                      </tr>
                   </table>
            	</div>
            </div>
        </div>
    </div>
</div>
</body>
</html>
