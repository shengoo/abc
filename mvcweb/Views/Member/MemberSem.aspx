<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>个人中心</title>
    <style type="text/css">
        html, body {
            margin: 0;
            padding: 0;
            width: 100%;
            height: 800px;
            font-size: 14px;
            color: #333;
            background-color: #F1F1F1;
        }

        a {
            text-decoration: none;
        }

        .ul_menu_left {
            list-style-type: none;
            padding: 0;
            margin: 0;
        }

            .ul_menu_left li {
                height: 39px;
                width: 160px;
            }

                .ul_menu_left li a {
                    line-height: 38px;
                    font-size: 14px;
                    text-align: center;
                    cursor: pointer;
                    padding-left: 14px;
                }

                .ul_menu_left li:hover {
                    background-color: #FCFCFC;
                }

            .ul_menu_left .focus {
                color: #2B7DBC;
                font-weight: bold;
            }

        .flt {
            float: left;
        }

        .frt {
            float: right;
        }

        .tiny {
            width: 50px;
            font-size: 9px;
            margin-left: 5px;
            padding-bottom: 3px;
        }

        .small {
            width: 50px;
            height: 20px;
            font-size: 9px;
            margin: 5px;
            padding: 6px 12px;
        }

        .middle {
            width: 80px;
            font-size: 14px;
        }

        .max {
            width: 100px;
            font-size: 14px;
        }

        .thin {
            height: 5px;
        }


        .hidden {
            display: none;
        }

        .ul_courselist {
            list-style-type: none;
            height: 40px;
            background-color: #b9cce7;
            margin: 0px 0px 23px 23px;
        }

            .ul_courselist li {
                width: 80px;
                height: 40px;
                line-height: 40px;
                text-align: center;
                font-size: 14px;
                font-weight: bold;
                cursor: pointer;
                float: left;
            }

                .ul_courselist li:hover {
                    background-color: #ff0;
                }

            .ul_courselist .focus {
                background-color: #f87171;
            }

        .process {
            width: 100px;
            height: 20px;
            line-height: 20px;
            border: 1px solid #f00;
            position: relative;
            color: #00f;
        }

            .process .percent3 {
                width: 30%;
                height: 100%;
                background-color: #f00;
                position: relative;
            }

            .process .percent8 {
                width: 80%;
                background-color: #f00;
                position: relative;
                height: 100%;
            }

            .process .percent0 {
                width: 0%;
                background-color: #f00;
                position: relative;
                height: 100%;
            }

        .ul_vertical_list {
            list-style-type: none;
        }

            .ul_vertical_list li {
                padding-bottom: 10px;
            }

            .ul_vertical_list table tr:first-child {
                background-color: #b9cce7;
            }

        .main {
            width: 1000px;
            margin: 27px auto;
            height: 100%;
        }
        /*课时列表*/

        .content_title {
            margin-bottom: 10px;
            height: 44px;
            padding-top: 2px;
            font-size: 18px;
            font-weight: bold;
            line-height: 44px;
            width: 712px;
            border-bottom: 1px solid #E5E5E5;
            position: relative;
        }

        .w80 {
            width: 80px;
        }
        /*订单*/
        .order_table {
            width: 100%;
            height: 110px;
            font-size: 14px;
            line-height: 20px;
        }

        .order_header {
            width: 100%;
            height: 30px;
            background-color: #b9cce7;
        }

        .order_body {
            width: 100%;
            height: 80px;
            cursor: pointer;
            padding-top: 10px;
            padding-bottom: 10px;
        }


        /* 左侧导航 */

        .side-menu {
            width: 190px;
            padding: 0;
            border: 1px solid #ddd;
            border-radius: 6px;
            background: #fff;
        }

            .side-menu p {
                border-top: 1px solid #ddd;
                border-bottom: 1px solid #ddd;
                font-size: 16px;
                margin: 0;
                text-align: left;
                padding-top: 8px;
                padding-bottom: 8px;
                padding-left: 32px;
            }

                .side-menu p img {
                    margin-right: 10px;
                }

            .side-menu ul {
                width: 168px;
                margin: 10px auto;
                padding: 0;
                text-align: center;
                list-style-type: none;
            }

                .side-menu ul li {
                    width: 100%;
                    height: 33px;
                    margin-bottom: 8px;
                    line-height: 33px;
                }

                    .side-menu ul li:hover, .current-sub-nav {
                        background: #BCD9EE;
                        border-radius: 6px;
                    }

                        .side-menu ul li:hover a, .current-sub-nav a {
                            color: #333333;
                        }

                    .side-menu ul li a {
                        cursor: pointer;
                        display: block;
                        font-size: 14px;
                        color: #636363;
                    }

        .current {
            background: #3396D9;
            color: #fff;
        }
        /* 控件 */
        .single-body {
            padding: 0 27px;
            position: relative;
        }

        .form-group {
            margin-bottom: 15px;
            width: 100%;
            padding-left: 5px;
            height: 72px;
        }

            .form-group input {
                margin-left: 20px;
            }

        .required {
            color: red;
        }
        /* 课程 标签 */
        .nav-tabs {
            list-style-type: none;
        }

            .nav-tabs li {
                float: left;
                border: 1px solid #ddd;
                margin-left: 5px;
                height: 37px;
                min-width: 123px;
                text-align: center;
                padding: 0 13px;
                line-height: 37px;
                border-bottom: 0;
                cursor: pointer;
                border-top-left-radius: 6px;
                border-top-right-radius: 6px;
            }

                .nav-tabs li:hover {
                    background: #3396D9;
                    color: #fff;
                }

            .nav-tabs .focus {
                background-color: #3396D9;
                color: #fff;
            }
    </style>
    <!-- 个人信息 -->
    <style type="text/css">
        .single {
            width: 717px;
            height: 660px;
            padding-left: 23px;
        }

            .single .table tr td {
                padding-top: 10px;
            }

        .text_content {
            width: 100%;
            height: 34px;
            color: #333;
        }

        .error {
            border-color: #f00;
        }
    </style>

    <style type="text/css">
        .btntiny {
            border-radius: 2px;
            line-height: 1em;
            height: 18px;
            vertical-align: middle;
            text-align: center;
            cursor: pointer;
            border: 1px solid transparent;
            background-color: #428bca;
            font-weight: normal;
            font-size: 12px;
            margin-left: 3px;
            color: white;
            padding: 5px 3px 0 3px;
        }

            .btntiny:hover {
                background-color: #978bca;
            }
    </style>
    <!--修改密码-->
    <style type="text/css">
        .safe {
            height: 660px;
            width: 717px;
            padding-left: 23px;
        }
    </style>
    <!--我的课程-->
    <style type="text/css">
        .courselist {
            height: 660px;
            width: 717px;
            padding-left: 23px;
        }

        .courselist_table_container {
            height: 500px;
        }

        .evaluate {
            margin: 5px;
        }

        .classlesson {
            overflow: auto;
            height: 660px;
            width: 798px;
        }

        .course_yueke {
            width: 100%;
            font-size: 13px;
            border-top: 1px solid #ddd;
            border-left: 1px solid #ddd;
        }

            .course_yueke tr th {
                border-bottom: 1px solid #ddd;
                border-right: 1px solid #ddd;
                font-weight: bold;
                text-align: left;
                line-height: 1.42857;
                padding: 8px;
                vertical-align: middle;
            }

            .course_yueke tbody tr:hover {
                background-color: #f9f9f9;
            }

            .course_yueke tr td {
                border-bottom: 1px solid #ddd;
                border-right: 1px solid #ddd;
                text-align: left;
                line-height: 1.42857;
                padding: 5px;
                vertical-align: middle;
            }

            .course_yueke tr .single {
                background-color: #f9f9f9;
            }

        .classhour {
            background-color: #fff;
            overflow: auto;
        }

            .classhour table {
                border-spacing: 0px;
            }

            .classhour table {
                height: 30px;
                line-height: 30px;
            }

            .classhour tbody tr:hover {
                background-color: #f9f9f9;
                cursor: pointer;
            }

            .classhour table th, .classhour table td {
                margin: 0;
                font-size: 15px;
                padding-left: 5px;
                text-align: center;
            }

            .classhour ul {
                list-style-type: none;
                margin: 0;
                padding: 0;
            }

            .classhour li {
                margin-top: 10px;
                height: 30px;
                line-height: 30px;
                padding: 0;
            }

                .classhour li :hover {
                    background-color: #ff0;
                }

            .classhour .completed {
                margin-top: 10px;
                background-color: #f00;
                width: 12px;
                height: 12px;
                border-radius: 6px;
            }

            .classhour .continue {
                margin-top: 10px;
                background-color: #0f0;
                width: 12px;
                height: 12px;
                border-radius: 6px;
            }

            .classhour .content {
                margin-left: 5px;
            }

            .classhour .link {
                font-size: 12px;
                text-align: center;
                text-decoration: none;
                cursor: pointer;
                margin-left: 10px;
            }

        .rate {
            height: 45px;
        }

            .rate img {
                margin-left: 5px;
                width: 24px;
            }
    </style>
    <!--智能约课-->
    <style type="text/css">
        .courseyuyue {
            height: 660px;
            width: 717px;
            padding-left: 23px;
        }

        .classEvaluate {
            padding: 5px;
        }

        .win_grid {
            background-color: #FFFFFF;
            font-weight: normal;
        }

        .win_table {
            width: 98%;
            height: 80%;
            padding: 0;
            background-color: #fff;
            margin: 5px;
            border-spacing: 0;
            border-top: 1px solid #ddd;
            border-left: 1px solid #ddd;
            border-bottom: 1px solid #ddd;
        }

            .win_table th {
                font-weight: bold;
                font-size: 13px;
                text-align: left;
                border-right: 1px solid #ddd;
                padding: 5px;
            }

            .win_table tbody tr:hover {
                cursor: pointer;
                background-color: #f9f9f9;
            }

            .win_table tbody td {
                font-size: 12px;
                text-align: left;
                padding: 5px;
                border-top: 1px solid #ddd;
                border-right: 1px solid #ddd;
            }


        .list_text {
            font-weight: bold;
            margin: 3px auto;
            font-size: 13px;
            vertical-align: middle;
        }

            .list_text .container {
                padding: 5px;
            }

            .list_text .btn, .list_text .input {
                margin-left: 5px;
            }

        .courseyuyue .select {
            background-color: #2080f6;
        }

        .content_table {
            width: 700px;
            margin-left: 30px;
            margin-top: 5px;
        }

        .courseinfo div {
            text-align: left;
            padding: 5px;
        }

        .courseinfo .time {
            width: 25%;
        }

        .courseinfo .class {
            width: 45%;
        }

        .courseinfo .name {
            width: 20%;
        }


        .previewclass {
            width: 100%;
            border-top: 1px solid #ddd;
            border-left: 1px solid #ddd;
            border-right: 1px solid #ddd;
            list-style-type: none;
            padding: 0;
            margin: 0;
            font-size: 13px;
        }

            .previewclass li {
                line-height: 1.42857;
                text-align: left;
                padding: 5px;
                height: 30px;
                border-bottom: 1px solid #ddd;
                vertical-align: middle;
            }

                .previewclass li:first-child {
                    font-weight: bold;
                }

        .ul_yueke_left {
            list-style-type: none;
            margin: 0;
            padding: 0;
        }

            .ul_yueke_left li {
                width: 100%;
                text-align: left;
                margin-bottom: 10px;
            }

        .choicetime {
            width: 700px;
            margin-left: 30px;
            border: 1px solid #ddd;
            height: 150px;
        }

        .choicedate {
            width: 600px;
            height: 60px;
        }

        .classdate {
            width: 71px;
            height: 48px;
            padding-top: 10px;
            float: left;
            margin: 5px;
            color: #2B7DBC;
            text-align: center;
            cursor: pointer;
            background-image: url(../../Images/calender.png);
            background-repeat: no-repeat;
        }

            .classdate:hover {
                background-image: url(../../Images/calender_hover.png);
            }

        .selectdate {
            background-image: url(../../Images/calender_hover.png);
        }

        .classtime {
            width: 56px;
            height: 22px;
            float: left;
            margin: 5px;
            color: #2B7DBC;
            text-align: center;
            line-height: 22px;
            cursor: pointer;
            background-image: url(../../Images/classtime.png);
        }

        .selecttime {
            background-image: url(../../Images/classtime_focu.png);
            color: #fff;
        }

        .coursedate {
            width: 30px;
            height: 30px;
            background-color: #d3cccc;
        }

            .coursedate:hover {
                background-color: #d3dffd;
            }
    </style>
    <!--我的课表-->
    <style type="text/css">
        .coursetable {
            height: 660px;
            width: 717px;
            padding-left: 23px;
        }

        .calender {
            width: 717px;
            height: 295px;
            border: 1px solid #ddd;
            background-color: #F8F8F8;
        }

            .calender table {
                width: 580px;
                border-spacing: 0;
            }

                .calender table tr {
                    background-color: #F7F7F7;
                }

                    .calender table tr:first-child {
                        background-color: #F8F8F8;
                        border: 1px solid #ddd;
                    }

            .calender .coursetd {
                width: 54px;
                height: 36px;
                border-radius: 8px;
                text-align: center;
                vertical-align: middle;
                cursor: pointer;
            }

            .calender .gray {
                background-color: gray;
            }

            .calender .green {
                background-color: #38a5f8;
            }

            .calender .coursetd:hover {
                background-color: #58c5f8;
            }

            .calender .select {
                background-color: #38a5f8;
            }

            .calender .mark {
                background-color: #38a5f8;
            }

        .overview {
            width: 120px;
        }

        .calender .header {
            width: 100%;
            height: 30px;
            font-weight: bold;
            margin-top: 15px;
        }

            .calender .header div {
                float: left;
                border-top: 1px solid #ddd;
                border-right: 1px solid #ddd;
                border-bottom: 1px solid #ddd;
                padding: 3px;
            }

            .calender .header .prev {
                cursor: pointer;
                text-align: center;
                border-left: 1px solid #ddd;
            }

            .calender .header .content {
                width: 80px;
                text-align: center;
            }

            .calender .header .next {
                cursor: pointer;
                text-align: center;
            }

        .calender .body {
            margin-top: 20px;
            font-size: 24px;
            text-align: center;
            line-height: 60px;
            height: 60px;
        }

        .calender .activedate {
            font-size: 48px;
        }

        .calender .activeday {
            margin-left: 5px;
            font-size: 16px;
        }

        #calendar_course tr {
            height: 35px;
        }

            #calendar_course tr:first-child {
                font-weight: bold;
            }

        #calendar_course td {
            text-align: center;
            font-size: 15px;
        }

        #calendar_course .btn {
            padding: 3px 5px;
        }
    </style>
    <!--我的订单-->
    <style type="text/css">
        .orderform {
            height: 660px;
            width: 717px;
            padding-left: 23px;
        }

        .orderform_head_table {
            margin-top: 5px;
        }

            .orderform_head_table td {
                padding-left: 20px;
                height: 30px;
                background-color: #F5f5f5;
                font-weight: 400;
                padding-top: 3px;
                padding-bottom: 3px;
            }


        .order-list {
            margin-top: 5px;
            width: 100%;
            height: 480px;
        }

        .order-item {
            margin-top: 5px;
            border-bottom: 1px solid #ddd;
            border-left: 1px solid #ddd;
            border-right: 1px solid #ddd;
        }

            .order-item td {
                padding-bottom: 5px;
                padding-top: 5px;
            }

        .order-item-title {
            background-color: #ebf5ff;
            color: #333;
            font-weight: bold;
            height: 24px;
            font-size: 12px;
            padding: 5px 20px;
        }

            .order-item-title div {
                float: left;
            }

            .order-item-title .date {
                float: left;
                width: 180px;
                text-align: left;
                text-indent: 1em;
            }

            .order-item-title .no {
                float: left;
                width: 250px;
                text-align: left;
            }

            .order-item-title .trade {
                float: right;
                width: 280px;
                text-align: right;
                height: 30px;
            }

        .order-item-close {
            float: left;
            background-color: #afb;
            border-radius: 12px;
            cursor: pointer;
            width: 24px;
            height: 24px;
        }

        .order-body {
            float: left;
        }

        .order-body-name {
            width: 170px;
            overflow: hidden;
            padding-left: 5px;
        }

        .order-body-category {
            width: 170px;
            overflow: hidden;
        }

        .order-body-price {
            width: 100px;
        }

        .order-body-qty {
            width: 60px;
            overflow: hidden;
        }

        .order-item-total {
            width: 110px;
            float: left;
            height: 30px;
            line-height: 30px;
        }

        .order-item-operation {
            width: 60px;
            float: left;
            text-align: center;
            cursor: pointer;
            height: 30px;
            line-height: 30px;
        }

            .order-item-operation .operation {
                float: left;
                margin-right: 3px;
            }

                .order-item-operation .operation:hover {
                    color: #3396D9;
                }

        .order-body tr {
            height: 30px;
        }
    </style>

    <!--我的评价-->
    <style type="text/css">
        .myevaluate {
            height: 660px;
            width: 717px;
            padding-left: 23px;
        }

        .evaluate_item {
            width: 100%;
            height: 110px;
            padding-left: 15px;
            border-bottom: 1px solid #f5f5f5;
            padding-bottom: 5px;
        }

            .evaluate_item .course {
                height: 20px;
                width: 100%;
                color: #000;
            }

            .evaluate_item .remark {
                height: 20px;
                width: 100%;
                margin-bottom: 5px;
            }

                .evaluate_item .remark img {
                    float: left;
                    margin-left: 3px;
                }

            .evaluate_item .content {
                width: 100%;
                height: 40px;
                font-size: 13px;
                line-height: 20px;
            }

            .evaluate_item .sign {
                width: 100%;
                height: 20px;
                line-height: 20px;
                color: #919191;
                margin-bottom: 5px;
            }
    </style>

    <!--我的提问-->
    <style type="text/css">
        .myquestion {
            height: 660px;
            width: 717px;
            padding-left: 23px;
        }

        .question_item {
            width: 100%;
            height: 80px;
            padding-left: 15px;
            border-bottom: 1px solid #f5f5f5;
            padding-bottom: 5px;
        }

            .question_item .content {
                width: 100%;
                height: 40px;
                font-size: 13px;
                line-height: 20px;
                color: #000;
            }

            .question_item .sign {
                width: 100%;
                height: 20px;
                line-height: 20px;
                color: #919191;
                margin-bottom: 5px;
            }

            .question_item .answer {
                width: 100%;
                height: 20px;
                overflow: hidden;
                cursor: pointer;
            }

        .searchAnswer {
            text-decoration: underline;
            cursor: pointer;
        }
    </style>

    <!--问题答案-->
    <style type="text/css">
        .questionanswer {
            height: 660px;
            width: 717px;
            padding-left: 23px;
        }

        .questionanswer_item {
            width: 100%;
            height: 80px;
            padding-left: 15px;
            border-bottom: 1px solid #f5f5f5;
            padding-bottom: 5px;
        }

            .questionanswer_item .content {
                width: 100%;
                height: 40px;
                font-size: 13px;
                line-height: 20px;
                color: #000;
            }

            .questionanswer_item .sign {
                width: 100%;
                height: 20px;
                line-height: 20px;
                color: #919191;
                margin-bottom: 5px;
            }

            .questionanswer_item .accept {
                cursor: pointer;
                margin-left: 5px;
                text-decoration: underline;
            }

                .questionanswer_item .accept:hover {
                    color: blue;
                }
    </style>

    <!--我的答疑-->
    <style type="text/css">
        .myanswer {
            height: 660px;
            width: 717px;
            padding-left: 23px;
        }

        .answer_item {
            width: 100%;
            height: 100px;
            padding-left: 15px;
            border-bottom: 1px solid #f5f5f5;
            padding-bottom: 5px;
        }

            .answer_item .question {
                width: 100%;
                height: 40px;
                font-size: 13px;
                line-height: 20px;
                color: #000;
            }

            .answer_item .answer {
                width: 100%;
                height: 40px;
                font-size: 13px;
                line-height: 20px;
                color: #000;
            }

            .answer_item .sign {
                width: 100%;
                height: 20px;
                line-height: 20px;
                color: #919191;
                margin-bottom: 5px;
            }
    </style>

    <style type="text/css">
        .bbar {
            width: 160px;
            float: right;
            height: 20px;
        }

        .page_first, .page_next, .page_prev, .page_end {
            cursor: pointer;
            float: left;
            margin-left: 3px;
        }

        .page_nums, .page_count {
            float: left;
            margin-left: 3px;
            display: none;
        }

        .page_first:hover {
            font-weight: bold;
        }

        .page_next:hover {
            font-weight: bold;
        }

        .page_prev:hover {
            font-weight: bold;
        }

        .page_end:hover {
            font-weight: bold;
        }

        .layer {
            background-color: #2d2c2b;
            opacity: 0.1;
            z-index: 1;
        }

        .flt {
            float: left;
        }

        .frt {
            float: right;
        }

        .hidden {
            display: none;
        }
    </style>

</head>
<body>
    <div class="layer hidden" style="position: absolute; width: 100%; height: 100%;">
        <div style="width: 40px; height: 40px; margin: 40% auto;">
            <img src="" />
        </div>
    </div>
    <div class="main">
        <div class="side-menu flt">
            <p>
                <%--<img src="../../Images/menu-cjts.png" alt="个人设置">--%>
                个人设置
            </p>
            <ul>
                <li class="user-info-nav "><a action="single">个人信息</a></li>
                <li class="message-center-nav"><a action="safe">修改密码</a></li>
            </ul>
            <p class="hide4">
                <%--<img src="../../images/menu-cjts.png" alt="课程管理">--%>
                课程管理
            </p>
            <ul>
                <li class="message-center-nav hide4"><a action="courselist">我的课程</a></li>
                <li class="message-center-nav hide4"><a action="coursetable">我的课表</a></li>
                <li class="message-center-nav hide3 hide4"><a action="myevaluate">我的评价</a></li>

            </ul>
            <p class="hide3 hide4">
                <%--<img src="../../images/menu-cjts.png" alt="订单管理">--%>
                订单管理
            </p>
            <ul class="hide3 hide4">
                <li class="message-center-nav hide3 hide4"><a action="orderform">我的订单</a></li>
            </ul>
            <p class="hide3">
                <%--<img src="../../images/menu-cjts.png" alt="答疑管理">--%>
                答疑管理
            </p>
            <ul>
                <li class="message-center-nav hide3 hide4"><a action="myquestion">我的提问</a></li>
                <li class="message-center-nav hide3"><a action="myanswer">我的答疑</a></li>
            </ul>
        </div>

        <div class="flt" style="width: 800px; margin-left: 6px; border: 1px solid #ddd; border-radius: 6px; background: #fff;">
            <!--个人信息-->
            <div class="single flt">
                <div class="content_title">
                    基本信息
                </div>
                <table class="table" style="width: 100%; height: 400px;" cellpadding="0" cellspacing="0">
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
                        <td>
                            <div class="text_content">
                                <label class="label flt">性别:</label>
                                <div class="flt" style="height: 34px; text-align: left; vertical-align: middle; padding-top: 10px;">
                                    <input type="radio" value="0" name="sex" />男<input value="1" type="radio" name="sex" style="margin-left: 10px;" />女
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="text_content">
                                <label class="label flt">生日:</label>
                                <input type="text" class="input flt" readonly="readonly" name="birth" onclick="laydate()" /><div class="descibe hidden flt"></div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="text_content">
                                <label class="label flt">邮箱:</label>
                                <input type="text" class="input flt" name="email" /><div class="descibe gray flt">请输入有效的邮箱号码！</div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="text_content" style="height: 90px">
                                <label class="label flt" style="height: 90px; line-height: 90px;">学员心声:</label>
                                <div class="flt" style="height: 34px; text-align: left; vertical-align: middle; padding-top: 10px;">
                                    <textarea name="address" cols="40" rows="5" style="margin-top: 2px;"></textarea>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="text_content" style="height: 90px">
                                <label class="label flt" style="height: 90px; line-height: 90px;">详细地址:</label>
                                <div class="flt" style="height: 34px; text-align: left; vertical-align: middle; padding-top: 10px;">
                                    <textarea name="address" cols="40" rows="5" style="margin-top: 2px;"></textarea>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <button class="btn middle flt" style="margin-left: 280px;" method="saveSingle">保存</button>
                        </td>
                    </tr>
                </table>
            </div>

            <!--修改密码-->
            <div class="safe hidden flt">
                <div class="content_title">
                    修改密码
                </div>
                <div class="single-body">
                    <div class="form-group">
                        <label class="label"><span class="required">*</span>原密码：</label><br />
                        <input type="password" name="pwd" class="input flt" placeholder="请输入原密码" />
                    </div>

                    <div class="form-group">
                        <label class="label"><span class="required">*</span><span id="name">新密码：</span></label><br />
                        <input type="password" name="newpwd" class="input flt" placeholder="输入新密码" />
                        <div class="descibe gray flt">密码必须是以数字、字母或字符组成，且不能少于8位</div>
                    </div>
                    <div class="form-group">
                        <label class="label"><span class="required">*</span>重复密码：</label><br />
                        <input type="password" name="confirmpwd" class="input flt" placeholder="请再次输入新密码" />
                        <div class="descibe gray flt">重复密码与新密码必须相同</div>
                    </div>
                    <div class="form-group">
                        <button method="updatePassword" class="btn middle" style="margin-left: 160px;">保存</button>
                    </div>
                </div>
            </div>

            <!--我的课程-->
            <div class="courselist hidden flt">
                <div class="content_title">
                    我的课程
                </div>
                <div>
                    <ul class="nav-tabs">
                        <li class="focus" data="0">全部课程</li>
                        <li data="1">待约课</li>
                        <li data="2">待上课</li>
                        <li data="3">已完成</li>
                    </ul>
                </div>
                <div class="courselist-div">
                    <div class="courselist_table_container">
                        <table class="course_yueke" cellspacing="0">
                            <colgroup>
                                <col width="12%" />
                                <col width="12%" />
                                <col width="15%" />
                                <col width="15%" />
                                <col width="12%" />
                            </colgroup>
                            <thead>
                                <tr>
                                    <th>课程名称</th>
                                    <th>课程介绍</th>
                                    <th>开课日期</th>
                                    <th>进度</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>
                    </div>
                    <div style="width: 100%; height: 30px;">
                        <div class="bbar"></div>
                    </div>
                </div>
            </div>

            <!-- 课程详情 -->
            <div class="classlesson hidden">
                <div class="classhour">
                    <table width="100%">
                        <thead>
                            <tr>
                                <th>课时</th>
                                <th>上课老师</th>
                                <th>上课时间</th>
                                <th>课件下载</th>
                                <th>评价</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>

                <div class="classEvaluate hidden">
                    <div class="flt" style="width: 100%; height: 45px;">
                        <label class="label" style="height: 45px; line-height: 45px; float: left;">
                            打分:
                        </label>
                        <p class="rate">
                            <img src="<%=ViewBag.Path%>/Images/star-off.png" /><img src="<%=ViewBag.Path%>/Images/star-off.png" /><img src="<%=ViewBag.Path%>/Images/star-off.png" /><img src="<%=ViewBag.Path%>/Images/star-off.png" /><img src="<%=ViewBag.Path%>/Images/star-off.png" />
                        </p>
                    </div>
                    <div class="flt" style="width: 100%; height: 200px;">
                        <label class="label flt" style="height: 200px; line-height: 200px;">说明</label>
                        <textarea class="evaluatecontent flt" style="height: 200px; width: 375px;"></textarea>
                    </div>
                    <div style="width: 100%; height: 30px; float: left; margin-top: 10px;">
                        <a class="btntiny frt" style="margin-right: 10px;" action="evaluate">提交</a>
                    </div>
                </div>
            </div>

            <!--智能约课-->
            <div class="courseyuyue hidden flt">
                <div class="content_title">
                    <div class="flt">VIP1对1英语套餐课程</div>
                </div>
                <div class="content_left flt">
                    <ul class="ul_yueke_left">
                        <li style="height: 30px;">
                            <div class="list_text">
                                <div class="label flt">
                                    约课方式:
                                </div>
                                <div class="container flt">
                                    <div class="btn select flt" action="mode" data="1">按时间</div>
                                    <div class="btn flt" action="mode" data="2">按老师</div>
                                </div>
                            </div>
                        </li>
                        <li style="height: 30px;">
                            <div class="list_text">
                                <div class="label flt">
                                    约课次数:
                                </div>
                                <div class="container flt">
                                    <div class="btn select flt" action="times" data="1">按次约课</div>
                                    <div class="btn flt" action="times" data="2">连约两堂课</div>
                                    <div class="btn flt" action="times" data="3">连约三堂课</div>
                                </div>
                            </div>
                        </li>
                        <li style="height: 40px;">
                            <div class="list_text flt">
                                <div class="label flt" style="height: 60px; line-height: 60px;">上课日期:</div>
                                <div class="choicedate flt"></div>
                            </div>
                        </li>
                        <li style="height: 30px;" class="selteacher hidden">
                            <div class="list_text">
                                <div class="label flt">选择老师:</div>
                                <div class="input flt" style="cursor: pointer; height: 24px;" action="selectTeacher"></div>
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
                            <button class="btn flt" action="submit" style="margin-left: 664px;">预约</button>
                        </li>
                    </ul>
                </div>
                <div class="content_table flt">
                    <ul class="previewclass">
                        <li style="background-color: #F3F3F4;">
                            <div style="float: left; width: 25%; padding: 5px; text-align: left;">时间</div>
                            <div style="float: left; width: 45%; padding: 5px; text-align: left;">课程名称</div>
                            <div style="float: left; width: 20%; padding: 5px; text-align: left;">老师</div>
                        </li>
                    </ul>
                </div>

                <div class="win_grid hidden">
                    <div style="height: 30px; padding: 5px;">
                        <div class="label flt" style="width: inherit;">名称：</div>
                        <input class="input flt" style="height: 18px" type="text" />
                    </div>
                    <div style="width: 100%; padding: 0;">
                        <table class="win_table">
                            <thead>
                                <tr>
                                    <th>名称</th>
                                    <th>介绍</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                    </div>
                </div>

            </div>

            <!--我的课表-->
            <div class="coursetable hidden flt">
                <div class="content_title">
                    我的课表
                </div>
                <div class="calender">
                    <div class="table flt">
                    </div>
                    <div class="overview flt">
                        <div class="header">
                            <div class="prev">< </div>
                            <div class="content">2015年10月</div>
                            <div class="next">></div>
                        </div>
                        <div class="body"><strong class="activedate">31</strong><strong class="activeday">周六</strong></div>
                    </div>
                </div>

                <div class="content_title">
                    当日课程
                </div>
                <div style="min-height: 200px">
                    <table class="course_yueke" cellspacing="0">
                        <thead>
                            <tr>
                                <th>名称</th>
                                <th>老师</th>
                                <th>上课时间</th>
                                <th>进度</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>
            </div>

            <!--我的订单-->
            <div class="orderform hidden flt">
                <div class="content_title">
                    我的订单
                </div>
                <div>
                    <ul class="nav-tabs">
                        <li class="focus" data="0">全部</li>
                        <li data="1">待支付</li>
                        <li data="2">已完成</li>
                    </ul>
                    <table style="width: 100%;" class="course_yueke">
                        <colgroup>
                            <col width="24%" />
                            <col width="24%" />
                            <col width="14%" />
                            <col width="8%" />
                            <col width="16%" />
                            <col width="14%" />
                        </colgroup>
                        <thead>
                            <tr>
                                <th>卡名称</th>
                                <th>类型</th>
                                <th>价格</th>
                                <th>数量</th>
                                <th>订单金额</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                    </table>
                    <div class="order-list">
                    </div>
                    <div style="width: 100%; height: 30px;">
                        <div class="bbar"></div>
                    </div>
                </div>
            </div>

            <!--我的评价-->
            <div class="myevaluate hidden flt">
                <div class="content_title">
                    我的评价
                </div>
                <div>
                    <div class="order-list">
                    </div>
                    <div style="width: 100%; height: 30px;">
                        <div class="bbar"></div>
                    </div>
                </div>
            </div>

            <!--我的提问-->
            <div class="myquestion hidden flt">
                <div class="content_title">
                    我的提问
                </div>
                <div>
                    <div class="order-list">
                    </div>
                    <div style="width: 100%; height: 30px;">
                        <div class="bbar"></div>
                    </div>
                </div>
            </div>

            <!--问题答案-->
            <div class="questionanswer hidden flt">
                <div style="height: 40px">
                    <a class="searchAnswer" style="line-height: 40px; margin-bottom: 5px;">返回</a>
                </div>
                <div class="question"></div>
                <div class="order-list">
                </div>
                <div style="width: 100%; height: 30px;">
                    <div class="bbar"></div>
                </div>
            </div>

            <!--我的答疑-->
            <div class="myanswer hidden flt">
                <div class="content_title">
                    我的答疑
                </div>
                <div>
                    <div class="order-list">
                    </div>
                    <div style="width: 100%; height: 30px;">
                        <div class="bbar"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
<link href="<%=ViewBag.Path%>/js/laydate/need/laydate.css" rel="stylesheet" />
<link rel="stylesheet" type="text/css" href="<%=ViewBag.Path%>/Content/dist/components/input.css">
<link rel="stylesheet" type="text/css" href="<%=ViewBag.Path%>/Content/dist/components/label.css">
<script src="<%=ViewBag.Path%>/js/jquery-1.8.3.min.js"></script>
<script src="<%=ViewBag.Path%>/js/jquery.cookie.js"></script>
<script src="<%=ViewBag.Path%>/js/layer/layer.js"></script>
<script src="<%=ViewBag.Path%>/js/laydate/laydate.js"></script>
<script src="<%=ViewBag.Path%>/js/common.js"></script>
<script src="<%=ViewBag.Path%>/js/member.js" type="text/javascript"></script>
</html>
