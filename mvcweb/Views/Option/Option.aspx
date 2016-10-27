<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content=""/>
    <meta name="description" content=""/>
    <title>ABC在线英语</title>
    <link href="<%=ViewBag.Path%>/static/css/Option.css" rel="stylesheet"/>
    <link href="<%=ViewBag.Path%>/assets/css/common.css" rel="stylesheet" />
    <script>
        window.onload = function () {
            window.parent.$('.set').show();
        }
    </script>
    <style>
        .section .tab li {
            width: auto;
        }
    </style>
</head>
<body>
<div class="banner">
    <div class="banner-text">
        <h1>EASY TO LEARN ENGLISH</h1>
        <h5>轻松学英语，<strong>零基础也能变达人</strong></h5>
    </div>
</div>
<% Html.RenderPartial("UserCenterNav", 6);%>
<div class="section">
    <div class="container">
        <div class="ad">
            <h1 class="title">常见问题</h1>
            <h2 class="sub-text">COMMON PROBLEM</h2>
            <div class="divider"></div>
            <ul class="tab">
                <li class="active"><a href="javascript:void(0);"><span class="about-abc"></span>关于ABC</a></li>
                <li><a href="javascript:void(0);"><span class="about-foreign-teacher"></span>关于外教</a></li>
                <li><a href="javascript:void(0);"><span class="about-class"></span>课程与教材</a></li>
                <li><a href="javascript:void(0);"><span class="about-appointment"></span>预约与取消</a></li>
                <li><a href="javascript:void(0);"><span class="about-chinese-teacher"></span>关于中教</a></li>
                <li><a href="javascript:void(0);"><span class="about-faq"></span>常见问题</a></li>
            </ul>
            <div class="tab-content">
                <div id="aboutABC" class="faq">
                    <dl class="opened">
                        <dt>Q：ABC ONLINE全部是一对一教学吗？<span class="menu-status"></span></dt>
                        <dd>A：ABC Online主要是一对一教学，但是同时辅助有一对六实践课和一对多文化课。给学员提供更多的实践和练习的机会。全方位打造英语听说读写的能力。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：我可以试听吗？<span class="menu-status"></span></dt>
                        <dd>A：可以的。您只需花30秒就能马上免费预约一节体验课了。或者拨打400-661-9888，我们的客服会帮您安排。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：ABC Online的课程适合什么样的学员？<span class="menu-status"></span></dt>
                        <dd>A：只要您想说英语敢于说英语，任何年龄段或任何基础的学员都可以在ABC Online学习。我们的学员年龄跨度从四岁到七十多岁各个年龄段，各种学习需求的都有。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：可以每天上课吗？<span class="menu-status"></span></dt>
                        <dd>A：可以的。我们的上课时间是每天的06：00-23:30。登录会员中心您可以自助式预约适合您的上课时间。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：公司地址在哪里？<span class="menu-status"></span></dt>
                        <dd>A：我们位于北京市海淀区中关村大街甲28号海淀文化艺术大厦B座三层，乘车至海淀黄庄东站或海淀黄庄站，或地铁至海淀黄庄站，从东北口出向东走100米即到。</dd>
                    </dl>
                </div>
                <div id="aboutForeignTeacher" style="display: none;" class="faq">
                    <dl class="opened">
                        <dt>Q：ABC Online的老师全部是外教吗？<span class="menu-status"></span></dt>
                        <dd>A：我们不止有口音纯真的北美外教，更有经验丰富的中教老师。对于零基础和基础薄弱的学员，ABC Online会为您匹配经验丰富的中教老师进行授课哦！</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：老师会不会说中文？<span class="menu-status"></span></dt>
                        <dd>A：对于有一定英文基础，可以上外教课的学员，ABC营造的是一个全英语的学习环境，在这里会有类似留学的新鲜体验，让我们真正用英语的思维去思考和沟通，全英文的环境更有利于英语听力和口语的提高哦。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：学生可以自由选择外教老师吗？<span class="menu-status"></span></dt>
                        <dd>A：登录会员中心选择“预约课程”，您可以根据自己的情况选择适合您的上课时间、外教老师、课程以及教材。您在ABC Online可以体验全程自助式预约课程的服务。老师的时间状态只要是开放的，您就可以预约。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：老师的教学质量如何？<span class="menu-status"></span></dt>
                        <dd>A：老师全部经过严格的招聘筛选和培训流程，具有丰富的教学经验。而且我们会定期根据老师的上课表现来做测评和再培训，甚至淘汰学员综合评分低的老师。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：换老师的话，老师不会一直了解我们的情况吧？<span class="menu-status"></span></dt>
                        <dd>A：您的上课进度都记录在课程档案中，老师会在课前查看您的历史课程档案的。如果您有其他的需求的话可以随时跟老师沟通，比如在约课的时候给老师留言等。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：教师是固定的吗？<span class="menu-status"></span></dt>
                        <dd>A：您每节课都是全程自助式的预约老师、教材和上课时间的。由于老师会有休假或参与公司在岗培训的安排，所以通常建议您多选择几位您喜欢的老师进行收藏。</dd>
                    </dl>
                </div>
                <div id="aboutClass" style="display: none;" class="faq">
                    <dl class="opened">
                        <dt>Q：请问我要学习什么样的教材呢？<span class="menu-status"></span></dt>
                        <dd>A：ABC Online的课程设置是个性化的，也就是根据每个学员不同的程度和学习需求量身定做学习计划。循序渐进的教材设置，灵活匹配的教材内容，让学员能最快速的学以致用。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：我是否可以做预习和复习呢？<span class="menu-status"></span></dt>
                        <dd>A：当然可以的。每次上课学习的教材学员都可以提前下载进行预习。课后，学员也可以通过视频复习的形式进行复习。保证每次上课的学习效果。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：免费的公开课每个班多少人？<span class="menu-status"></span></dt>
                        <dd>A：公开课是不限制人数的。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：公开课面向什么样的学员呢？<span class="menu-status"></span></dt>
                        <dd>A：公开课目前面向的是所有ABC Online注册的学员，程度包括零基础课程、中教口语、外教文化课。这是给广大学员提供的免费学习的平台，内容涉猎比较广泛，希望更多的学员可以借助ABC Online的平台学习英文。</dd>
                    </dl>
                </div>
                <div id="aboutAppointment" style="display: none;" class="faq">
                    <dl class="opened">
                        <dt>Q：如何预约课程？<span class="menu-status"></span></dt>
                        <dd>A：付费学员预约课程需登录网站会员中心进行自助式预约。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：预约课程的时候是否有限制？<span class="menu-status"></span></dt>
                        <dd>A：上课前需要至少提前十分钟在网站上预约课程，例如15点的课，至少需要在14:50之前进行预约操作。如果您使用的是次卡，可以一次性预约接下来三天内任何开放时间段课程，如果使用的是年卡或月卡，也可以一次性预约接下来三天的课程，但是每天只能约一堂课哦。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：已经预约了的课程可以取消吗？要提前多长时间取消？<span class="menu-status"></span></dt>
                        <dd>A：已经预约的课程可以取消，但是需要至少提前4个小时取消，少于4个小时就得正常扣课时了，所以建议大家还是按时上课哦。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：上课晚到了还可以继续上课吗？<span class="menu-status"></span></dt>
                        <dd>A：10分钟以内的晚到仍可以继续上课，外教老师将只给您上该节课剩下的时间。。晚到10分钟以上的，则视为学生缺席，该课程取消并扣除此节课。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：如何修改个人信息，比如：英文名、手机号、邮箱等信息？<span class="menu-status"></span></dt>
                        <dd>A：登录会员中心下的“账户设置”进行个人信息修改。</dd>
                    </dl>
                </div>
                <div id="aboutChineseTeacher" style="display: none;" class="faq">
                    <dl class="opened">
                        <dt>Q：什么样的学员可以选择中教授课？<span class="menu-status"></span></dt>
                        <dd>A：零基础学员和基础比较薄弱的学员是可以选择中教老师上课的。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：中教老师的资质怎么样？<span class="menu-status"></span></dt>
                        <dd>A：中教老师都是专业八级水平，并拥有多年教学经验的老师。能够快速找到学员基础问题，并有针对性的进行辅导，快速提高学员成绩。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：中教老师一对一上课的时间和外教老师是一样的吗？<span class="menu-status"></span></dt>
                        <dd>A：如果是成人套餐，每次中教老师上课是1个小时，外教是45分钟；如果是青少年套餐，每次中教老师上课是45分钟，外教是30分钟。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：中教老师上课也可以随时预约吗？<span class="menu-status"></span></dt>
                        <dd>A：如果要固定中教老师，则上课的时间要跟中教老师来单独预约。中教老师的上班时间是8：30-21：00。</dd>
                    </dl>
                </div>
                <div id="aboutFAQ" style="display: none;" class="faq">
                    <dl class="opened">
                        <dt>Q：登录用户名忘记了怎么办呢？密码忘记了可以找回吗？<span class="menu-status"></span></dt>
                        <dd>A：可以哦，登录之后在个人中心——个人设置——修改密码里面进行修改就行。2.登录之后在哪里选课呢？</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：已经登录了，但是不能选课是怎么回事呢？<span class="menu-status"></span></dt>
                        <dd>A：要先看一下自己的次数是不是上完了，如果次数还有看一下是否过期了，如果已经过期了可以联系学管师申请延期，每位学员可以有一次免费延期的机会。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：已经下载了启动器，但是好像不能安装是怎么回事呢？<span class="menu-status"></span></dt>
                        <dd>A：Windows系统的话，首先需要先看一下您的电脑上是否安装了解压缩工具，如果已经安装了需要先解压再进行安装。如果是Mac系统的话直接下载启动器之后刷新界面就可以进入了。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：老师看不到（听不到）我是怎么回事啊？<span class="menu-status"></span></dt>
                        <dd>A：首先确保自己的电脑上已经插上耳机（摄像头），并且处于打开状态，同时教室中的麦克风（摄像头）也已经打开，如果这两个都没有问题，可以在教室左下角的音视频设置——麦克风（视频），优选一下设备再试一下。如果还是不行，请尽快与学管师/客服联系。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：我看不到（听不到）老师怎么办啊？<span class="menu-status"></span></dt>
                        <dd>A：如果听不到老师，到教室左下角的音视频设置——扬声器里，重新选择设备再试一下。如果看不到老师的话，到教室右上角——齿轮设置里，根据自己的宽带优选一下网络。如果还是不行，请尽快与学管师/客服联系。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：上课的时候看不到PPT怎么办呢？<span class="menu-status"></span></dt>
                        <dd>A：需要下载Adobe Flash Player for IE，安装完刷新页面重新登录进入即可。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：网络好像有问题，听老师说话断断续续的。<span class="menu-status"></span></dt>
                        <dd>A：到教室右上角——齿轮设置里，根据自己的宽带优选一下网络即可解决。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：黑板是黑色的，静止不动了怎么办呢？<span class="menu-status"></span></dt>
                        <dd>A：到教室右上角——齿轮设置里，根据自己的宽带优选一下网络即可解决。</dd>
                    </dl>
                    <dl class="opened">
                        <dt>Q：我的手机号换了怎么办呢？<span class="menu-status"></span></dt>
                        <dd>A：您可以在个人中心——个人设置——修改手机里面进行修改，但是这个只是更改了联系电话，用户名还是原来的注册手机号哦。</dd>
                    </dl>
                </div>
            </div>
        </div>
    </div>
</div>
    <script src="<%=ViewBag.Path%>/js/jquery-1.8.3.min.js"></script>
    <script>
        $(function() {
            $('.tab li a')
                .click(function() {
                    var index = $('.tab li a').index(this);
                    $('.tab li').removeClass('active');
                    $('.tab li').eq(index).addClass('active');
                    $('.tab-content > div').hide();
                    $('.tab-content > div').eq(index).show();

                    window.parent.$('#ContentFrame').css({
                        height: document.body.clientHeight
                    });
                });

            window.parent.$('#ContentFrame').css({
                height: 1515
            });
        });
    </script>
</body>
</html>
