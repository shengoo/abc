<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="payResult.aspx.cs" Inherits="payResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main mb30">
        <div class="m2pos">
            <a class="cor_666" href="/">ABC首页</a> > <a class="cor_666" href="<%= buyUrl %>">购买课程</a> > <span class="cor_999">支付完成</span>
        </div>
        <div class="m2c_bx1"><img src="/images/m3br_img.jpg" width="980" height="45" /></div>
        <div class="m2c_t1 cor_red">恭喜您，支付成功！</div>
        
        <div class="m2c_st1">
            订单号：<%= myOrder.TrackId %>　　
            <a href="<%= buyUrl %>">再去看看喜欢的课程</a>
            <a href="/user/member/bookClass.aspx">我要约课</a>
        </div>
        
        <div class="m2c_tab">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr class="m2c_th">
                    <td>序号</td>
                    <td>已购课程</td>
                    <td>消费卡说明</td>
                    <td>赠品</td>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" EnableTheming="false" onitemdatabound="Repeater1_ItemDataBound">
                  <ItemTemplate>
                    <tr>
                        <td><strong class="cor_org"><%# Container.ItemIndex + 1 %></strong></td>
                        <td><%#Eval("Title")%></td>
                        <td><%#Eval("Notes")%></td>
                        <td id="Eval_Gift" runat="server" enableviewstate="false"></td>
                    </tr>
                  </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        
        <div class="clear"></div>
    </div>
</asp:Content>--%>