
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智能约课</title>
    <link href="../../Content/commen.css" rel="stylesheet" />
    <style type="text/css">
        .content{
            width:1000px;
            margin:0 auto;
        }
        
        .content_title {
            margin: 0px 0px 10px 23px;
            height: 44px;
            padding-top: 2px;
            font-size: 18px;
            font-weight: bold;
            line-height: 44px;
            border-bottom: 1px solid #333;
            width: 1000px;
        }

        .list_text {
            font-size:14px;
            margin:10px auto;
        }

        .content_left {
            width:640px;
        }
        .content_table {
            width:360px;
        }


        .previewclass {
            width: 400px;
        }

            .previewclass td {
                text-align: center;
            }

        .ul_menu_left {
            list-style-type: none;
            margin: 0;
            padding: 0;
        }

            .ul_menu_left li {
                width: 100%;
                text-align: left;
                margin-top: 15px;
                padding-left: 20px;
            }

        .classdate {
            width: 600px;
            height: 80px;
        }

        .classtime {
            width: 600px;
            height: 80px;
            border:1px solid #333;
        }

        .coursedate {
            width: 30px;
            height: 30px;
            background-color: #d3cccc;
        }

            .coursedate:hover {
                background-color: #d3dffd;
            }
        .w80 {
            width:80px;
        }
    </style>
</head>
<body>
    <div class="content">
    <div class="content_title">VIP1对1A套餐英语课程</div>
    <div class="content_left flt">
        <ul class="ul_menu_left">
            <li>
                <div>
                    <div class="list_text">请选择约课方式：</div>
                    <input type="radio" name="yuekestyle" value="1" checked="checked" />按时间
                <input type="radio" name="yuekestyle" value="2" />按老师
                </div>
            </li>
            <li>
                <div>
                    <div class="list_text">请选择约课次数：</div>
                    <input type="radio" name="ordertimes" value="1" checked="checked" />按次约课
                <input type="radio" name="ordertimes" value="2" />连约两堂课
                <input type="radio" name="ordertimes" value="3" />连约三堂课
                </div>
            </li>
            <li>
                <div>
                    <div class="list_text">请选择上课日期：</div>
                    <div class="classdate"></div>
                </div>
            </li>
            <li>
                <div>
                    <div class="list_text">请选择上课老师：</div>
                    <select class="select"><option value="0">请选择</option>
                    </select>
                </div>
            </li>
            <li>
                <div>
                    <div class="list_text">请选择上课时段：</div>
                <div class="classtime"></div>
                </div>
            </li>
            <li>
                <div class="btn w80 frt">提交预约</div>
            </li>
        </ul>
    </div>
    <div class="content_table flt">
        <table class="previewclass" style="border:1px solid #333">
            <tr style="background-color: #fcfcfc">
                <td colspan="3">已有课程预览</td>
            </tr>
            <tr style="background-color: #fefefe">
                <td>时间</td>
                <td>课程名称</td>
                <td>课程老师</td>
            </tr>
        </table>
    </div>
        </div>
</body>
</html>
