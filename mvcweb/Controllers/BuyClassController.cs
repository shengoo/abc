using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Newtonsoft.Json;
using Model;
using QianZhu.API.Alipay;
using QianZhu.API.Unionpay;
using com.unionpay.upop.sdk;

namespace mvcweb.Controllers
{
    using Filters;

    public class BuyClassController : BaseController
    {
        BuyClassService service = new BuyClassService();
        public ActionResult BuyClass()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }

        public ActionResult BuyWeiXinPay()
        {
            return View();
        }
         [HttpPost]
        public ActionResult GetOrderEnable(int orderId)
        {
            var obj = new Response<bool>();
            int flag = service.GetOrderEnabled(orderId); 
            if (flag == 1)
            {
                obj.Result = true;
            }
            else {
                obj.Result = false;
            }
            
            return Json(obj); 
        }

        public ActionResult PayConfirm()
        {
            return View();
        }

        public ActionResult PayAccount(string orderNo, string payType)
        {
            try
            {
                HttpContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
                HttpContext.Response.Headers.Add("content_type", "utf-8");
                Orders order = service.GetOrder(orderNo, member.Id);
                if (order != null)
                {
                    switch (payType)
                    {
                        //支付
                        case "alipay":
                            if (Common.GetConfigValue("IsTest") == "1")
                            {
                                order.TotalAmount = 0.01M;
                            }
                            ViewBag.SubmitHtml = PayByAlipay(order.OrderNo, order.TotalAmount.Value);
                            break;
                        //微信
                        case "weixin":
                            if (Common.GetConfigValue("IsTest") == "1")
                            {
                                order.TotalAmount = 0.01M;
                            }
                            ViewBag.OrderId = order.OrderId;
                            ViewBag.Price = order.TotalAmount;
                            ViewBag.Time = order.OrderTime;
                            ViewBag.Path = GetBaseVirtualPath; 
                            
                            return View("BuyWeiXinPay");
                        //银联
                        case "unionpay":
                            if (Common.GetConfigValue("IsTest") == "1")
                            {
                                order.TotalAmount = 0.01M;
                            }
                            ViewBag.SubmitHtml = PayByUnion(order.OrderNo, order.TotalAmount.Value);
                            DataBase.DbHelperSQL.WriteLog(ViewBag.SubmitHtml, new Exception());
                            break;
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                DataBase.DbHelperSQL.WriteLog("进入支付", ex);
                return View("/Home/Error");
            }
        }

        public ActionResult BuyCar()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }

        public ActionResult GetCourseCategory()
        {
            return Json(service.GetCategory());
        }

        public ActionResult GetCourseCard(int type,int cardTypeId)
        {
            return Json(service.GetCourseCard(type,cardTypeId));
        }

        public ActionResult GetCourseGift(string cardId)
        {
            return Json(service.GetCardGift(cardId));
        }

        public ActionResult BuyCart(int cardId, int number)
        {
            if (member == null || member.Type != 1) return Json(new Response<bool> { ErrMsg = "非学员不能购买课程卡！" });
            return Json(service.BuyCart(cardId,
                number, Common.GetCurrentUser(HttpContext).Id));
        }

        public ActionResult GetBuyCart()
        {
            return Json(service.GetCart(Common.GetCurrentUser(HttpContext).Id));
        }

        public ActionResult DelCart(string carts)
        {
            return Json(service.DelCart(Common.GetCurrentUser(HttpContext).Id, carts.Split(',').Select(t => int.Parse(t)).ToArray()));
        }

        /// <summary>
        /// 计算订单
        /// </summary>
        /// <param name="carts"></param>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult AccountCart(string carts)
        {
            if (string.IsNullOrEmpty(carts))
            {
                return Json(new Response<bool> { ErrMsg = "请选择至少一张课程卡！" });
            }
            return Json(service.AccountCart(Common.GetCurrentUser(HttpContext).Id, JsonConvert.DeserializeObject<List<Model.Cart>>(carts)));
        }

        public ActionResult BuyCarSubmit(string orderNo)
        {
            List<MyOrder> orders = service.GetOrders(orderNo, member.Id).OrderByDescending(c => c.CardType).ThenByDescending(c => c.Category).ThenByDescending(c=>c.Price).ToList();
            string details = "";
            int count = 0;
            decimal price = 0;
            if (orders != null && orders.Count != 0)
            {
                ViewBag.OrderNo = orders.First().No;
                foreach (var x in orders)
                {
                    var classss = orders.IndexOf(x)%2==1 ? "odd":"";
                    price += x.Price;
                    count += x.Qty;
                    details += string.Format("<tr class='" + classss + "'><td class=\"add_l_p35\">{0}</td><td><b class=\"f-fs2\">{1}</b></td><td class=\"f-fs3 add_f_fs3\"><b>{2}</b></td><td><i class=\"f-ff1\">¥</i>{3}</td></tr>",x.CardType==1?" 青少卡":"成人卡", x.CardName, x.Qty, x.Amount);
                }
                //orders.ForEach(x =>
                //{
                //    price += x.Price ;
                //    count += x.Qty;
                //    details += string.Format("<tr height=\"65px\"><td class=\"add_l_p35\">{0}</td><td><b class=\"f-fs2\">{1}</b></td><td class=\"f-fs3 add_f_fs3\"><b>{2}</b></td><td><i class=\"f-ff1\">¥</i>{3}</td></tr>", x.CardType == 1 ? "次卡" : "月卡", x.CardName, x.Qty, x.Price);
                //});
            }
            else
            {
                ViewBag.OrderNo = "<script>document.write('无效的订单号！')</script>";
            }
            ViewBag.Price = price;
            ViewBag.Count = count;
            ViewBag.OrderDetails = details;
            return View("BuyCarSubmit");
        }

        private string PayByUnion(string orderNo, decimal orderPrice)
        {
            UPOPSrv.LoadConf(UnionpayConfig.Path);
            Dictionary<string, string> param = new Dictionary<string, string>();
            UnionpayConfigModel unionpayConfig = UnionpayConfig.GetParams();

            //交易类型，前台只支持 CONSUME 和 PRE_AUTH
            param["transType"] = UPOPSrv.TransType.CONSUME;

            //商品URL
            param["commodityUrl"] = Common.ServiceUrl;

            //商品名称
            string subject = unionpayConfig.CommodityName;
            //if (String.IsNullOrEmpty(subject)) subject = "订单 - " + orderNo;
            param["commodityName"] = subject;

            //商品单价(分为单位)
            param["commodityUnitPrice"] = (orderPrice * 100).ToString("F0");

            //商品数量
            param["commodityQuantity"] = "1";

            //订单号(必须唯一)
            param["orderNumber"] = orderNo;

            //交易金额
            param["orderAmount"] = param["commodityUnitPrice"];

            //币种
            param["orderCurrency"] = UPOPSrv.CURRENCY_CNY;

            //交易时间
            param["orderTime"] = DateTime.Now.ToString("yyyyMMddHHmmss");

            //用户IP
            param["customerIp"] = HttpContext.Request.UserHostAddress;

            //后台通知URL
            param["backEndUrl"] =  "http://zaixian.abc.com.cn/PayNotice/NotifyUnion";

            //前台返回URL
            param["frontEndUrl"] = "http://zaixian.abc.com.cn/PayNotice/NotifyUnion"; 
             
            FrontPaySrv srv = new FrontPaySrv(param);
            return srv.CreateHtml();
        }

        private string PayByAlipay(string orderNo, decimal orderPrice)
        {
            //合作身份者ID
            Config.Partner = PayConfig.Aop.AlipayPartner;

            //安全检验码
            Config.Key = PayConfig.Aop.AlipayKey;

            //服务器异步通知页面路径
          //  string notify_url = Common.ServiceUrl + "MOBILE/NotifyUrl.aspx";
            string notify_url = Common.ServiceUrl + "/PayNotice/NotifyAop";
            //需http://格式的完整路径，不能加?id=123这类自定义参数

            //付款金额
            string price = orderPrice.ToString("F2");

            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("service", "create_direct_pay_by_user");
            sParaTemp.Add("partner", Config.Partner);
            sParaTemp.Add("_input_charset", Config.Input_charset);
            sParaTemp.Add("notify_url", notify_url);

            sParaTemp.Add("out_trade_no", orderNo);
            sParaTemp.Add("subject", PayConfig.Aop.AlipayOrderTitle);
            sParaTemp.Add("payment_type", "1");
            sParaTemp.Add("seller_id", Config.Partner);
            sParaTemp.Add("total_fee", price);

            //建立请求
            return Submit.BuildRequest(sParaTemp, "post", "确认");
        } 

    }
}