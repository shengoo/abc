<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ABC在线英语</title>
    <link href="<%=ViewBag.Path%>/static/css/PurchaseTo.css" rel="stylesheet"/>
    <script>
        window.parent.$('#ContentFrame').css({
            height: 1200
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
                     <li><a href="<%=ViewBag.Path%>/Purchase/Purchase">我的卡次</a></li>
                    <li><a href="<%=ViewBag.Path%>/PurchaseNo/PurchaseNo">我的课程</a></li>
                    <li class="active"><a href="<%=ViewBag.Path%>/PurchaseTo/PurchaseTo">我的课表</a></li>
                    <li><a href="<%=ViewBag.Path%>/PurchaseTh/PurchaseTh">课后评分</a></li>
                </ul>
            </div>
            <div class="option-course">
            	    <div class="play-btn btn_a">
                     上一月
                    </div>
                    <p>JULY</p>
                    <div class="play-btn btn_b">
                     下一月
                    </div>
            </div>
            <div class="free-course">
            	<div class="each-media">
            	   <table class="extb">
                      <tr class="odd">
                       <td>周日</td>
                       <td>周一</td>
                       <td>周二</td>
                       <td>周三</td>
                       <td>周四</td>
                       <td>周五</td>
                       <td>周六</td>
                      </tr>
                      <tr>
                       <td class="add">26</td>
                       <td class="add">27</td>
                       <td class="add">28</td>
                       <td class="add">29</td>
                       <td class="add">30</td>
                       <td>1</td>
                       <td>2</td>
                      </tr>
                        <tr>
                      <td>3</td>
                       <td>4</td>
                       <td>5</td>
                       <td>6</td>
                       <td>7</td>
                       <td>8</td>
                       <td>9</td>
                      </tr>
                      <tr>
                      <td>10</td>
                       <td>11</td>
                       <td>12</td>
                       <td>13</td>
                       <td>14</td>
                       <td>15</td>
                       <td>16</td>
                      </tr>
                      <tr>
                      <td>217</td>
                       <td>18</td>
                       <td>19</td>
                       <td>20</td>
                       <td>21</td>
                       <td>22</td>
                       <td>23</td>
                      </tr>
                        <tr>
                      <td>24</td>
                       <td>25</td>
                       <td>26</td>
                       <td>27</td>
                       <td>28</td>
                       <td>29</td>
                       <td>30</td>
                      </tr>
                       <tr>
                      <td>31</td>
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
