<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <title>ABC在线英语</title>
    <link href="<%=ViewBag.Path%>/Content/commen.css" rel="stylesheet" />
    <link href="<%=ViewBag.Path%>/static/css/index.css" rel="stylesheet"/>
    <link href="<%=ViewBag.Path%>/static/css/login.css" rel="stylesheet"/>
    <%: Styles.Render("~/bundles/styles")%>
</head>
<style>
.header .set{
    float: right;
    display:none;
}
.header .set span{
  display: inline-block;
  font-size: 14px;
  color:  #ff6a00;
}
.header .set a {
  display: inline-block;
  font-size: 14px;
  color: #ff6a00;
  margin-right: 20px;
}
.header .get{
    float: right;
    text-align:center;
}
.header .get a {
  display: inline-block;
  font-size: 14px;
  margin-right: 30px;
  color: #ff6a00;
  cursor:pointer;
}
.header .child{
    float:left;
    cursor:pointer;
    cursor:hand;
    text-align:center;
}
.header .child a{
  display: inline-block;
  font-size: 14px;
  margin-left:10px;
  color:#ff6a00;
}
</style>
<body>
   <div class="header">
    <div class="container">
        <div class="contach-info">
            <a class="email"><i></i>abc_online@abc.com.cn</a>
            <a class="tel"><i></i>400-661-9888</a>
        </div>
        <div class="logo">
            <a href="index.html"></a>
            <div class="logo-bg"></div>
        </div>
        <div class="login">
            <a class="xinlang"><i></i>
                <div class="ewm">
                    <img src="<%: Url.Content("~/assets/image/twodimensioncode.jpg")%>"/>
                    <div class="appDown_title">扫码关注</div>
                </div>
            </a>
            <a class="weixin"><i></i>
                <div class="ewm">
                    <img src="<%: Url.Content("~/assets/image/twodimensioncode.jpg")%>"/>
                    <div class="appDown_title">关注Abc微信</div>
                </div>
            </a>
        </div>
        <div class="child">
        	<a href="<%=ViewBag.Path%>/Young/Index">切换至少儿版</a>
        </div>
        <div class="get">
        	<a class="exit">登录</a>
        	<a class="enroll">注册</a>
        </div>
        <div class="set">
        	<span class="span">个人中心&nbsp;,&nbsp;</span>
        	<a class="exit">退出</a>
        </div>
    </div>
</div>
    <iframe name="ContentFrame" id="ContentFrame" style="min-width: 1140px; width: 100%; height: 2200px; border: 0px;" scrolling="no" frameborder="0" src="<%=ViewBag.Path%>/Home/Home"></iframe>

    <div class="content hidden" style="width: 800px; height: 500px;">
        <iframe src="" width="100%" height="450"></iframe>
    </div>
   <div class="footer">
    <div class="container">
        <i class="footer-icon"></i>
        <p class="copy">COPYRIGHT &copy; 2014-9-1 ABC.COM.CN, ALL RIGHTS RESERVED<br>京ICP备12029524号-1 京ICP证130137号
            京公网安备11010802012731号</p>
        <div class="logo-intro">
            <div class="footer-logo"></div>
        </div>
    </div>
</div>
<div class="alert-panel">
    <span class="close"></span>
    <div class="login-logo"></div>
    <!--BEGIN登录页-->
    <div class="login-div">
        <div class="login-form">
            <form action="">
                <div class="form-item">
                    <input type="text" class="form-control"/>
                    <span class="input-tooltip">请输入您的手机号码</span>
                </div>
                <div class="form-item">
                    <input type="text" class="form-control"/>
                    <span class="input-tooltip">您的密码</span>
                </div>
                <div class="form-item">
                    <label for="auto">
                        <input id="auto" type="checkbox"/>自动登录
                    </label>
                </div>
                <div class="form-item">
                    <input class="form-control" id="login" type="submit" value="登录"/>
                </div>
                <a class="retrieve-pwd">忘记密码？</a>
            </form>
        </div>
        <div class="other-action">还不是会员？<a>注册</a></div>
    </div>
    <!--END登录页-->
    <!--BEGIN注册页-->
    <div class="register-div">
        <div class="login-form">
            <form action="">
                <div class="form-item">
                    <input type="text" class="form-control"/>
                    <span class="input-tooltip">请输入您的手机号码</span>
                </div>
                <div class="form-item">
                    <input type="text" class="form-control"/>
                    <label>请输入6-14位数字或英文的密码，不含空格</label>
                    <span class="input-tooltip">您的密码</span>
                </div>
                <div class="form-item">
                    <input type="text" class="form-control"/>
                    <span class="input-tooltip">请再次输入您的密码</span>
                </div>
                <div class="form-item">
                    <div class="vali">
                        <input class="form-control"/>
                        <span class="input-tooltip">请输入验证码</span>
                    </div>
                        <a class="get-vali" href="">获取验证码</a>
                </div>
                <div class="form-item">
                    <input class="form-control" id="register" type="submit" value="注册"/>
                </div>
            </form>
        </div>
        <div class="other-action">已经拥有账户？<a>登录</a></div>
    </div>
    <!--END注册页-->
</div>

    <div class="mask-bg">
        <div class="site-select">
            <div class="item1">
                <img src="<%: Url.Content("~/assets/image/img1.jpg")%>" />
                <div class="hover-color"></div>
            </div>
            <div class="item2">
                <a href="<%= Url.Action("Index", "Young")%>">
                    <img src="<%: Url.Content("~/assets/image/img2.jpg")%>" />
                    <div class="hover-color"></div>
                </a>
            </div>
            <div class="item3">
                <a href="<%= Url.Action("Index", "Abroad")%>">
                    <img src="<%: Url.Content("~/assets/image/img3.jpg")%>" />
                    <div class="hover-color"></div>
                </a>
            </div>
            <div class="item4">
                <a href="<%= Url.Action("Train", "Abroad")%>">
                    <img src="<%: Url.Content("~/assets/image/img4.jpg") %>" />
                    <div class="hover-color"></div>
                </a>
            </div>
        </div>
    </div>

</body>
<script src="<%=ViewBag.Path%>/js/jquery-1.8.3.min.js"></script>
<script src="<%=ViewBag.Path%>/js/base.js"></script>
<script src="<%=ViewBag.Path%>/js/jquery.cookie.js"></script>
<script src="<%=ViewBag.Path%>/js/common.js"></script>
<script src="<%=ViewBag.Path%>/js/index.js"></script>

<script>

    var userinfoId = $("#hidUserInfo").val();
    var uname = '', upwd = '';
    if (userinfoId == "") {
    } else {
        uname = userinfoId;
        upwd = '123456';
    }
    var easemobIM = { config: {} };
    ////必填////
    easemobIM.config.tenantId = '14891';//企业id
    easemobIM.config.to = 'abcservicer';//必填, 指定关联对应的im号
    easemobIM.config.appKey = 'abconline888#abconlineapp';//必填, appKey
    ////非必填////
    easemobIM.config.buttonText = 'ABC在线英语客服';//设置小按钮的文案
    easemobIM.config.hide = false;//是否隐藏小的悬浮按钮
    easemobIM.config.mobile = /mobile/i.test(navigator.userAgent);//是否做移动端适配
    easemobIM.config.dragEnable = true;//是否允许拖拽
    easemobIM.config.dialogWidth = '400px';//聊天窗口宽度,建议宽度不小于400px
    easemobIM.config.dialogHeight = '500px';//聊天窗口高度,建议宽度不小于500px
    easemobIM.config.defaultAvatar = '/static/img/avatar.png';//默认头像
    easemobIM.config.minimum = true;//是否允许窗口最小化，如不允许则默认展开
    easemobIM.config.visitorSatisfactionEvaluate = false;//是否允许访客主动发起满意度评价
    easemobIM.config.soundReminder = true;//是否启用声音提醒
    easemobIM.config.imgView = true;//是否启动图片点击放大功能
    easemobIM.config.fixedButtonPosition = { x: '10px', y: '80px' };//悬浮初始位置，坐标以视口右边距和下边距为基准
    easemobIM.config.dialogPosition = { x: '10px', y: '10px' };//窗口初始位置，坐标以视口右边距和下边距为基准
    easemobIM.config.titleSlide = true;//是否允许收到消息的时候网页title滚动
    easemobIM.config.error = function (error) { };//错误回调
    easemobIM.config.onReceive = function (from, to, message) { };//收消息回调
    easemobIM.config.authMode = 'password';//验证方式
    easemobIM.config.user = {
        //可集成自己的用户，如不集成，则使用当前的appkey创建随机访客
        name: uname,//集成时必填
        password: upwd//authMode设置为password时必填,与token二选一
        //   token: ''//authMode设置为token时必填,与password二选一      
    };
</script>
<script src="<%=ViewBag.Path%>/static/js/easemob.js" type="text/javascript"></script>
    
    <%: Scripts.Render("~/bundles/scripts")%>
</html>
