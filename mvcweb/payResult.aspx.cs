using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
//using QianZhu.BLL;
//using QianZhu.Model;
//using QianZhu.Utility;

public partial class payResult : System.Web.UI.Page
{
    //建立业务逻辑层实例
    //private GlobalConfig bll_config = new GlobalConfig();
    //private Member bll_member = new Member();
    //private Orders bll_orders = new Orders();
    //private OrderDetail bll_orderDetail = new OrderDetail();
    //public OrdersModel myOrder = null;

    public string buyUrl = String.Empty;
    NumberFormatInfo nfi = new CultureInfo("zh-CN", false).NumberFormat;
    
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    WebUtility.MemberLoginAuth();

    //    myOrder = bll_orders.GetModelByTrackId(Request.QueryString["trackId"]);
    //    if (myOrder == null || myOrder.MemberId.ToString() != bll_member.CookieId || myOrder.Status != 1) WebUtility.Goto404();

    //    if (!Page.IsPostBack)
    //    {
    //        BindInfo();
    //    }
    //}

    ///// <summary>
    ///// 绑定信息
    ///// </summary>
    //private void BindInfo()
    //{
    //    GlobalConfigModel config = bll_config.GetModel();

    //    //Title
    //    Page.Title = "支付完成 - 购物车 - " + config.PageTitle;

    //    buyUrl = WebUtility.BuyUrl;

    //    List<OrderDetailModel> orderDetailList = bll_orderDetail.GetListByOrderId(myOrder.Pkid);
    //    Repeater1.DataSource = orderDetailList;
    //    Repeater1.DataBind();
    //}

    //protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    //{
    //    OrderDetailModel orderDetail = (OrderDetailModel)e.Item.DataItem;
    //    ((HtmlTableCell)e.Item.FindControl("Eval_Gift")).InnerHtml = bll_orderDetail.GetGiftNotes(orderDetail);
    //}
}
