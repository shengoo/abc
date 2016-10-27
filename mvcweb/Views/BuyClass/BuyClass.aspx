<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ABC</title>
</head>
<body>
    <div class="content">
        <ul class="col_tab_ul clearfix">
            <!--课程卡种类-->
        </ul>
        <div class="clearfix" style="height: 450px;">
            <div class="col_tab_img">
                <!--Rl mod-->
                <img src="<%=ViewBag.Path%>/Images/buyclass_1.jpg" width="423" height="297">
            </div>
            <div class="col_tab_imgtxt">
                <!--Rl mod-->
                <div class="coursetitle">
                    <!--课程卡名称-->
                </div>
                <div class="courseinfo">
                    <!--课程信息-->
                </div>
                <div class="number clearfix">
                    <div style="height: 30px; display:none;">
                        <div class="flt" style="width: 70px; text-align: right; height: 30px;font-size: 13px; line-height: 30px;">数&nbsp;量：</div>
                        <div title="减1" class="reduce flt">-</div>
                        <input type="text" class="number_input flt" value="1" size="2" maxlength="3" title="请输入购买量">
                        <div class="plus flt" title="加1">+</div>
                        <div style="height: 26px; line-height: 26px; float: left; margin-left: 3px;">件</div>
                    </div>
                    <div class="gift visible clearfix">
                        <div class="flt" id="label_addcard" style="width:70px; text-align: right;font-size:14px; color: #666; height:  30px; line-height:30px;font-family: Microsoft YaHei,微软雅黑,arial,宋体;">课程详情：</div>
                        <div style="margin-left: 35px; margin-top: 10px;" class="gift_select"></div>
                    </div>
                          <div class="price clearfix">
                        <div class="flt" style="width: 70px; text-align: right; height: 30px; font-size:15px; font-family: Microsoft YaHei,微软雅黑,arial,宋体;">价&nbsp;&nbsp;格：</div>
                        <span class="price_num"></span>
                    </div>
                    <div style="margin-top: 10px; height: 30px;">
                        <div method="buy" class="buy add"></div>
                        <div method="search" class="buy search"></div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col_tab_ulbox clearfix">
            <ul class="col_tab_ul2 clearfix">
                <li class="on" onmouseover="showtab(1,event)">套餐详情</li>
           <%--     <li onmouseover="showtab(2,event)">超值优惠</li>--%>
            </ul>
            <div class="m2eBox">
            </div>
        <%--    <div class="m2eBox hidden">
            </div>--%>
        </div>
    </div>

</body>
<link href="<%=ViewBag.Path%>/Content/buyclass.css" rel="stylesheet" />
<script src="<%=ViewBag.Path%>/js/jquery-1.8.3.min.js"></script>
<script src="<%=ViewBag.Path%>/js/base.js"></script>
<script src="<%=ViewBag.Path%>/js/layer/layer.js"></script>
<script src="<%=ViewBag.Path%>/js/common.js"></script>
<script src="<%=ViewBag.Path%>/js/buyclass.js"></script>
</html>
