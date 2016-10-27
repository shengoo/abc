@{
Layout=null;
}
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">      
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <title>个人中心</title>
    <link href="../../Content/commen.css" rel="stylesheet" />
    <link href="../../Content/member.css" rel="stylesheet" />
    <link href="../../js/laydate/need/laydate.css" rel="stylesheet" />
    <link href='../../js/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../../js/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
</head>
<body>
    <div class="main">
        <div class="side-menu flt">
            <p style="border-top: none;">
                <%--  <span class="personinfo"></span>--%>
                <%--<img src="../../Content/icon/abi-icon_07.png" />--%> <span class="spaninfo">个人设置</span>
            </p>
            <ul>
                <li class="user-info-nav"><a action="single">个人信息</a></li>
                <%--  <li class="user-info-nav"><a action="photo">我的头像</a></li>--%>
                <li class="message-center-nav"><a action="safe">修改密码</a></li>
                <li class="message-center-nav"><a action="phone">修改手机</a></li>
            </ul>
            <p class="hide4">
                <%--  <img src="../../Content/icon/abi-icon_03.png" />--%>
                <%--<span class="coursem"></span>--%><span class="spaninfo">课程管理</span>
            </p>
            <ul>
                <li class="message-center-nav hide3 hide4"><a action="coursecard">我的卡次</a></li>
                <li class="message-center-nav hide4"><a action="courselist">我的课程</a></li>
                <li class="message-center-nav hide4"><a action="coursetable">我的课表</a></li>
                <li class="message-center-nav hide4"><a action="myevaluate">课后评分</a></li>
            </ul>
            <p class="hide3 hide4">
                <%--   <img src="../../Content/icon/abi-icon_10.png" />--%>
                <%--<span class="orderm"></span>--%><span class="spaninfo">订单管理</span>
            </p>
            <ul class="hide3 hide4">
                <li class="message-center-nav hide3 hide4"><a action="orderform">我的订单</a></li>
                <li class="message-center-nav hide3 hide4" id="buycoursecard"><a href="/BuyClass/BuyClass" target="_self">购买课程</a></li>
            </ul>
            <p>
                <%--<span class="questionm"></span>--%><span class="spaninfo hide3">VIP服务</span>
                <%--<img src="../../Content/icon/ico17a.png" />--%>
            </p>
            <ul>
                <li class="message-center-nav hide3 hide4"><a action="myquestion">专家答疑</a></li>
                <li class="message-center-nav hide3 hide4"><a action="myanswer">常见问题</a></li>
            </ul>
        </div>

        <div class="flt" style="width: 875px; margin-left: 10px; border: 1px solid #ddd; background: #fff;">
            <!--个人信息-->
            <div class="single hidden flt" style="height: 762px">
                <div class="content_title">
                    个人信息
                </div>
                <table class="table" style="width: 100%; height: 400px; margin-left: 18px;" cellpadding="0" cellspacing="0">


                    <tr>
                        <td>
                            <div class="text_content">
                                <div class="label flt">中文名:</div>
                                <input type="text" class="input flt" name="name" />
                                <%--<div class="descibe gray flt">请输入您的中文名称，方便老师与您进行联系！输入非法字符将不能保存。</div>--%>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="text_content">
                                <label class="label flt">英文名:</label>
                                <input type="text" class="input flt" name="sign" />
                                <%--<div class="descibe gray flt">请输入您的英文文名称！好听的英文名称，让大家更容易记住你。</div>--%>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="white-space: nowrap;">
                            <%--     <nobr>--%>
                            <label class="label flt">头&nbsp;&nbsp;&nbsp;&nbsp;像:</label>
                            <iframe frameborder="0" style="border: 0; width: 100%; height: 119px; overflow: hidden; margin-left: 13px;" src="ModifyPhoto" scrolling="no"></iframe>
                            <%--         </nobr>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="text_content">
                                <label class="label flt">性&nbsp;&nbsp;&nbsp;&nbsp;别:</label>
                                <div class="flt" style="height: 26px; text-align: left; vertical-align: middle; padding-top: 8px; margin-left: 16px; color: #808080;">
                                    <input type="radio" value="0" name="sex" style="width: 20px;" />男<input value="1" type="radio" name="sex" style="margin-left: 10px; width: 20px;" />女
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="text_content">
                                <label class="label flt">手机号:</label>
                                <div class="flt" id="myphone" style="height: 23px; text-align: left; vertical-align: middle; padding-top: 7px; color: #808080; margin-left: 16px;">
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="text_content">
                                <label class="label flt">生&nbsp;&nbsp;&nbsp;日:</label>
                                <input type="text" class="input flt" readonly="readonly" name="birth" onclick="laydate()" /><div class="descibe hidden flt"></div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="text_content">
                                <label class="label flt">邮&nbsp;&nbsp;&nbsp;箱:</label>
                                <input type="text" class="input flt" name="email" />
                                <%--                                <div class="descibe gray flt">请输入有效的邮箱号码！</div>--%>
                            </div>
                        </td>
                    </tr>
                    <tr id="userVoice" style="display: none;">
                        <td>
                            <div class="text_content" style="height: 90px">
                                <label class="label flt" style="height: 90px; line-height: 90px;">学员心声:</label>
                                <div class="flt" style="height: 34px; text-align: left; vertical-align: middle; padding-top: 10px;">
                                    <textarea name="Voice" cols="40" rows="5" style="margin-top: 2px; width: 314px; height: 83px; resize: none; margin-left: 12px;"></textarea>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="text_content" style="height: 90px">
                                <label class="label flt" style="height: 90px; line-height: 90px;">详细地址:</label>
                                <div class="flt" style="height: 34px; text-align: left; margin-left: 3px; vertical-align: middle; padding-top: 10px; margin-left: 16px;">
                                    <textarea name="address" cols="40" rows="5" style="margin-top: 2px; width: 314px; height: 74px; resize: none; color: #808080; border: 1px solid rgba(36, 34, 38, 0.15);"></textarea>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>

                            <button id="sbm1" class="btn middle flt" style="margin-left: 112px;" method="saveSingle">保存</button>
                        </td>
                    </tr>
                </table>
            </div>

            <!--上传头像-->
            <div class="photo hidden flt">
                <%-- <div class="content_title">
                    我的头像
                </div>
                <div>
                    <iframe frameborder="0" style="border: 0; width: 100%; height: 600px; overflow:hidden;" src="ModifyPhoto" scrolling="no"></iframe>
                </div>--%>
            </div>

            <!--修改密码-->
            <div class="safe hidden flt">
                <div class="content_title">
                    修改密码
                </div>
                <div class="single-body">
                    <div class="form-group" style="height: 50px; margin-top: 36px">
                        <label class="label" style="float: left;">原密码：</label>
                        <input type="password" name="pwd" class="input flt" placeholder="请输入原密码" />
                        <%-- <div class="descibe flt">密码必须是以数字、字母或字符组成，且不能少于6位</div>--%>
                    </div>

                    <div class="form-group" style="height: 50px;">
                        <label class="label" style="float: left;"><span id="name">新密码：</span></label>
                        <input type="password" name="newpwd" class="input flt" placeholder="输入新密码" />
                        <div class="descibe flt">密码必须是以数字、字母或字符组成，且不能少于6位</div>
                    </div>
                    <div class="form-group" style="height: 50px;">
                        <label class="label" style="float: left;">确认密码：</label>
                        <input type="password" name="confirmpwd" class="input flt" placeholder="请再次输入新密码" />
                        <div class="descibe flt">确认密码与新密码必须相同</div>
                    </div>
                    <div class="form-group" style="height: 50px;">
                        <button method="updatePassword" class="btn middle" style="margin-left: 112px;">保存</button>
                    </div>
                </div>
            </div>

            <!--修改手机号-->
            <div class="phone hidden flt">
                <div class="content_title">
                    修改手机
                </div>
                <div class="single-body">
                    <div class="form-group" style="margin-top: 45px; height: 45px;">
                        <label class="label" style="margin-left: 20px">
                            <%-- <span class="required">*</span>--%><span id="name">手机号：</span>
                        </label>
                        <%--<br />--%>
                        <input type="text" name="phone" class="input " style="width: 300px;" placeholder="请输入新手机号" />
                    </div>
                    <div class="form-group" style="height: 45px;">
                        <label class="label" style="margin-left: 20px">
                            <%--<span class="required">*</span>--%><span> 验证码：</span>
                        </label>
                        <%-- <br />--%>
                        <input type="text" name="code" style="width: 200px" class="input" placeholder="请输入验证码" />
                        <button class="btn" style="margin: 1px 0px 0px 5px;" method="sendValid">获取验证码</button>
                    </div>
                    <div class="form-group">
                        <button method="updatePassword" class="btn middle" style="margin-left: 105px; width: 108px;">保&nbsp;&nbsp;存</button>
                    </div>
                </div>
            </div>

            <!--我的卡次-->
            <%--   <div class="coursecard hidden flt" style="margin-left: 14px;">--%>
            <div class="coursecard hidden flt" style="margin-left: 5px;">
                <div class="content_title">
                    我的卡次
                </div>
                <div style="min-height: 200px">
                    <table class="course_yueke" cellspacing="0">
                        <thead>
                            <tr style="height: 32px;">
                                <th>序号</th>
                                <th>课程卡编号</th>
                                <th>课程卡类型</th>
                                <th>课程卡名称</th>
                                <th>课程名称</th>
                                <th>课程类型</th>
                                <th>卡次总数</th>
                                <th>剩余次数</th>
                                <th>截止有效期</th>
                            </tr>
                        </thead>
                        <tbody class="coursecardbody" id="tb1_"></tbody>
                    </table>
                </div>
                <div class="page"></div>
            </div>

            <!--我的课程-->
            <div class="courselist hidden flt">
                <div class="content_title">
                    我的课程
                </div>
                <div>
                    <ul class="nav-tabs">
                        <li class="focus" data="3">学习计划</li>
                        <li data="0" class="hide3">我要约课</li>
                        <li data="1">待上课</li>
                        <li data="2">上课历史</li>
                    </ul>
                </div>
                <div class="courselist-div">
                    <div class="courselist_table_container">
                        <table class="course_yueke" cellspacing="0">
                            <colgroup>
                                <col width="15%" />
                                <col width="13%" />
                                <col width="15%" />
                                <col width="12%" />
                                <col width="10%" />
                                <col width="20%" />
                            </colgroup>
                            <thead>
                                <tr>
                                    <th>课程类型</th>
                                    <th>课程级别</th>
                                    <th>课程名称</th>
                                    <th>上课方式</th>
                                    <th>进度</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>
                    </div>
                    <div style="width: 100%; height: 60px;">
                        <div class="page"></div>
                    </div>
                </div>
            </div>

            <!-- 课程详情 -->
            <div class="classlesson hidden">
                <div class="content_title" id="mycourse">
                    <label style="cursor: pointer;">我的课程</label><span id="coursedetail" style="width: 100%; /*cursor: pointer; */">课程详情</span>
                </div>
                <div class="classhour">
                    <table class="course_yueke">
                        <thead>
                            <tr>
                                <th>课次</th>
                                <th style="width: 113px;">上课老师</th>
                                <th style="width: 113px;">学管师</th>
                                <th>已约/可约</th>
                                <th>上课时间</th>
                                <th>时长</th>
                                <th>状态</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                    <div class="page"></div>
                </div>
                <div class="classEvaluate">
                    <div class="remark flt" style="width: 400px; height: 125px;">
                    </div>
                    <div class="flt" style="width: 400px; height: 120px;">
                        <label class="label flt" style="height: 120px; width: 120px; line-height: 120px;">评&nbsp;&nbsp;&nbsp;价：</label>
                        <textarea class="evaluatecontent flt" style="height: 120px; width: 260px;"></textarea>
                    </div>
                    <div style="width: 400px; height: 20px; float: left;">
                        <a class="btntiny frt" style="margin-top: 20px; margin-right: 30px;" action="evaluate">提交</a>
                    </div>
                </div>
            </div>

            <!--查看课件-->
            <div class="lessonaccess hidden">
                <table class="course_yueke">
                    <thead>
                        <tr>
                            <td>序号</td>
                            <td>课次号</td>
                            <td>课次名称</td>
                            <td>课件名称</td>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>

            <div class="videoaccess hidden">
                <table class="course_yueke">
                    <thead>
                        <tr>
                            <td>序号</td>
                            <td>视频名称</td>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>

            <!--智能约课-->
            <div class="courseyuyue hidden flt" style="height: 810px;">
                <div class="content_title">
                    <div class="title flt">VIP1对1英语套餐课程</div>
                </div>
                <div class="content_left flt">
                    <ul class="ul_yueke_left">
                        <li style="height: 33px;">
                            <div class="list_text">
                                <div class="label flt">
                                    约课方式:
                                </div>
                                <div class="container flt">
                                    <div class="selbtn select flt" action="mode" data="1">按时间</div>
                                    <div class="selbtn flt" action="mode" data="2">按老师</div>
                                </div>
                            </div>
                        </li>
                        <li style="height: 33px;">
                            <div class="list_text">
                                <div class="label flt">
                                    约课次数:
                                </div>
                                <div class="container flt">
                                    <div class="selbtn select flt" action="times" data="1">按次约课</div>
                                    <div class="selbtn flt" action="times" data="2">连约两堂课</div>
                                    <div class="selbtn flt" action="times" data="3">连约三堂课</div>
                                </div>
                            </div>
                        </li>
                        <li style="height: 30px;" class="selteacher hidden">
                            <div class="list_text">
                                <div class="label flt">选择老师:</div>
                                <div class="input flt" style="cursor: pointer; height: 18px; color: #30a0f6; padding: 5px; margin-top: 3px; text-align: center;" action="selectTeacher"></div>
                            </div>
                        </li>
                        <li style="height: 40px;">
                            <div class="list_text flt">
                                <div class="label flt" style="height: 60px; line-height: 60px;">上课日期:</div>
                                <div class="choicedate flt"></div>
                            </div>
                        </li>
                        <li style="height: 120px;">
                            <div class="list_text flt">
                                <div class="label">上课时段:</div>
                                <div class="choicetime flt">
                                </div>
                            </div>
                        </li>
                        <li style="height: 30px;">
                            <button class="btn flt" action="submit" style="margin-left: 742px; width: 80px; height: 30px;">预约</button>
                        </li>
                    </ul>
                </div>
                <div class="content_table flt">
                    <ul class="previewclass">
                        <li style="">
                            <div class="time flt right_border">课程类型</div>
                            <div class="coursename flt right_border">课程名称</div>
                            <div class="class flt right_border">上课方式</div>
                            <div class="coursename flt right_border">上课老师</div>
                            <div class="class flt right_border">上课时间</div>
                            <div class="operation flt">操作</div>
                        </li>
                    </ul>
                    <div class="page"></div>
                </div>

                <div class="win_grid hidden">
                    <div style="height: 30px; padding: 5px;">
                        <div class="label flt" style="width: inherit;">名称：</div>
                        <input class="input flt" style="padding: 5px" type="text" />
                    </div>
                    <div style="width: 100%; padding: 0;">
                        <table class="win_table">
                            <thead style="background-color: #ddd;">
                                <tr>
                                    <th>头像</th>
                                    <%--<th>中文名称</th>--%>
                                    <th>英文名称</th>
                                    <th style="width: 280px;">介绍</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                        <%--<div class="page" style="position: absolute; top: 380px; right: 10px;">--%>
                    </div>
                </div>
            </div>

        </div>

        <!--我的课表-->
        <div class="coursetable hidden flt" style="margin-left: 11px;">
            <div class="content_title">
                我的课表
            </div>
            <div class="fullcalender">
            </div>
            <div class="courseform hidden">
                <table>
                    <tr>
                        <td>课程类型：</td>
                        <td>
                            <div id="kclx"></div>
                        </td>
                    </tr>
                    <tr>
                        <td>课程级别：</td>
                        <td>
                            <div id="kcjb"></div>
                        </td>
                    </tr>
                    <tr>
                        <td>课程名称：</td>
                        <td>
                            <div id="kcmc"></div>
                        </td>
                    </tr>
                    <tr>
                        <td>上课老师：</td>
                        <td>
                            <div id="skls"></div>
                        </td>
                    </tr>
                    <tr>
                        <td>上课模式：</td>
                        <td>
                            <div id="skms"></div>
                        </td>
                    </tr>
                    <tr>
                        <td>上课时间：</td>
                        <td>
                            <div id="sksj"></div>
                        </td>
                    </tr>
                    <tr>
                        <td>上课时长：</td>
                        <td>
                            <div id="sksc"></div>
                        </td>
                    </tr>
                    <tr>
                        <td>课次：</td>
                        <td>
                            <div id="kc"></div>
                        </td>
                    </tr>
                </table>

                <div class="oper">
                    <a class="btn" type="1" target="_blank">进入教室</a>
                    <a class="btn" type="2">取消预约</a>
                    <a class="btn" type="3" target="_blank">视频回放</a>
                    <a class="btn" type="4" target="_blank">下载课件</a>
                </div>
            </div>
        </div>

        <!--我的订单-->
        <div class="orderform hidden flt" style="height: 820px; margin-left: 10px;">
            <div class="content_title">
                我的订单
            </div>
            <div>
                <div>
                    <div style="float: left; width: 100%;">
                        <ul class="nav-tabs">
                            <li data="0">全部</li>
                            <li data="1">未支付</li>
                            <li data="2">已完成</li>
                        </ul>
                    </div>
                </div>
                <table style="width: 100%;" class="course_yueke">
                    <colgroup>
                        <col width="20%" />
                        <col width="15%" />
                        <col width="20%" />
                        <col width="10%" />
                        <col width="10%" />
                        <col width="10%" />
                        <col width="15%" />
                    </colgroup>
                    <thead>
                        <tr>
                            <th>课程卡名称</th>
                            <th>课程卡类型</th>
                            <th>分配课程</th>
                            <th>价格</th>
                            <th>数量</th>
                            <th>订单金额</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                </table>
                <div class="order-list" style="height: 585px; overflow-y: auto;">
                </div>
                <div style="width: 100%; height: 60px;">
                    <div class="page"></div>
                </div>
            </div>
        </div>

        <!--我的评价-->
        <div class="myevaluate hidden flt" style="margin-left: 9px;">
            <div class="content_title" style="cursor: pointer">
                课后评分
            </div>
            <div>
                <div class="courselist_table_container">
                    <table class="course_yueke">
                        <colgroup>
                            <col width="15%" />
                            <col width="13%" />
                            <col width="15%" />
                            <col width="12%" />
                            <col width="10%" />
                            <col width="20%" />
                        </colgroup>
                        <thead>
                            <tr>
                                <th>课程类型</th>
                                <th>课程级别</th>
                                <th>课程名称</th>
                                <th>上课方式</th>
                                <th>进度</th>
                                <th>查看评价</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                    <div class="page"></div>
                </div>
                <div class="classhour hidden">
                    <table class="course_yueke">
                        <thead>
                            <tr>
                                <th>课次</th>
                                <th style="width: 113px;">上课老师</th>
                                <th style="width: 113px;">学管师</th>
                                <th>已约/可约</th>
                                <th>上课时间</th>
                                <th>时长</th>
                                <th>状态</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                    <div class="page"></div>
                </div>
                <div class="orderlist hidden">
                    <div style="width: 100%; height: 35px;">
                        <ul class="nav-tabs">
                            <li data="0">学员评价</li>
                            <li data="1">教师评语</li>
                        </ul>
                    </div>
                    <div class="order-list" style="height: 500px">
                    </div>
                    <div style="width: 100%; height: 60px;">
                        <div class="page"></div>
                    </div>
                </div>
            </div>
        </div>

        <!--我的提问-->
        <div class="myquestion hidden flt">
            <div class="content_title">
                我的提问
            </div>
            <div>
                <%--  <div style="height:140px;width:100%;">
                        <textarea cols="104" rows="5"></textarea>
                        <div class="btn" style="width:100px;height:24px; font-size:16px; margin-top:10px;">我要提问</div>
                    </div>--%>
                <table id="question_sdk" style="width: 200px;" class="hidden">
                    <tr>
                        <td align="center">
                            <img src="../../Images/twodimensioncode.jpg" width="110px" height="110px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">安装手机客户端提问</td>
                    </tr>
                </table>
                <div class="order-list hidden" style="height: 540px">
                </div>
                <div style="width: 100%; height: 60px;">
                    <div class="page"></div>
                </div>
            </div>
        </div>

        <!--问题答案-->
        <div class="questionanswer hidden flt">
            <div class="content_title"><span class="searchAnswer" style="cursor: pointer;">我的问题</span> &gt; <span id="questionanswer">问题</span></div>
            <div class="order-list" style="height: 540px">
            </div>
            <div style="width: 100%; height: 60px;">
                <div class="page"></div>
            </div>
        </div>

        <!--我的答疑-->
        <div class="myanswer hidden flt">
            <%-- <div class="content_title">
                    我的答疑
                </div>
                <div>
                    <div class="order-list" style="height: 540px">
                    </div>
                    <div style="width: 100%; height: 60px;">
                        <div class="page"></div>
                    </div>
                </div>--%>
            <iframe frameborder="0" style="border: 0; width: 100%; height: 100%; overflow: hidden; margin-left: 13px;" src="CommonQuestion" <%--scrolling="no"--%>></iframe>
        </div>
    </div>
    </div>
</body>

<script src="<%=ViewBag.Path%>/js/jquery-1.8.3.min.js"></script>
<script src="<%=ViewBag.Path%>/js/base.js"></script>
<script src="<%=ViewBag.Path%>/js/jquery.cookie.js"></script>
<script src="<%=ViewBag.Path%>/js/layer/layer.js"></script>
<script src="<%=ViewBag.Path%>/js/laydate/laydate.js"></script>
<script src='<%=ViewBag.Path%>/js/fullcalendar/lib/moment.min.js'></script>
<script src="<%=ViewBag.Path%>/js/fullcalendar/fullcalendar.js"></script>
<script src="<%=ViewBag.Path%>/js/common.js"></script>
<script src="<%=ViewBag.Path%>/js/member.js" type="text/javascript"></script>

</html>
<script type="text/javascript">
    var focusinput;
    $().ready(function () {

    })

</script>
