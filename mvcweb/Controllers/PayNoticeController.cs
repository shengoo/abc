using System;
using System.Text;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web;
using System.Net;
using System.IO;
using System.Security.Cryptography;

namespace mvcweb.Controllers
{
    using Model;
    using WxPayAPI;
    using System.Collections.Specialized;
    using Service;

    public class PayNoticeController : Controller
    {
        MemberService service = new MemberService();
        BuyClassService buyService = new BuyClassService();
       
        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestPost()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            coll = Request.Form;

            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }

            return sArray;
        }

        //查询订单
        private bool QueryOrder(string transaction_id)
        { 
            WxPayData req = new WxPayData();
            req.SetValue("transaction_id", transaction_id);
            WxPayData res = WxPayApi.OrderQuery(req); 
            if (res.GetValue("return_code").ToString() == "SUCCESS" &&
                res.GetValue("result_code").ToString() == "SUCCESS")
            {
                return true;
            }
            else
            {
                return false;
            }
 
        }

        public ActionResult NotifyWeiXin()
        {
            DataBase.DbHelperSQL.WriteLog("收到微信通知", default(Exception));
            //接收从微信后台POST过来的数据
            System.IO.Stream s = HttpContext.Request.InputStream;
            int count = 0;
            byte[] buffer = new byte[1024];
            StringBuilder builder = new StringBuilder();
            while ((count = s.Read(buffer, 0, 1024)) > 0)
            {
                builder.Append(Encoding.UTF8.GetString(buffer, 0, count));
            }
            s.Flush();
            s.Close();
            s.Dispose();

          //  DataBase.DbHelperSQL.WriteLog(builder.ToString(), new Exception());
            //转换数据格式并验证签名
            WxPayData data = new WxPayData();
            try
            {
                data.FromXml(builder.ToString());
            //    DataBase.DbHelperSQL.WriteLog(builder.ToString(), new Exception());
            }
            catch (WxPayException ex)
            {
                //若签名错误，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", ex.Message);
                Log.Error(this.GetType().ToString(), "Sign check error : " + res.ToXml());
                DataBase.DbHelperSQL.WriteLog("Sign check error", new Exception());
                return Content(res.ToXml());
            }

            //检查支付结果中transaction_id是否存在
            if (!data.IsSet("transaction_id"))
            {
                //若transaction_id不存在，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "支付结果中微信订单号不存在");
                Log.Error(this.GetType().ToString(), "The Pay result is error : " + res.ToXml());
                DataBase.DbHelperSQL.WriteLog("支付结果中微信订单号不存在", new Exception());
                return Content(res.ToXml());
            }

            string transaction_id = data.GetValue("transaction_id").ToString();

            //查询订单，判断订单真实性
            if (!QueryOrder(transaction_id))
            {
                //若订单查询失败，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "订单查询失败");
                Log.Error(this.GetType().ToString(), "Order query failure : " + res.ToXml());
                DataBase.DbHelperSQL.WriteLog("订单查询失败", new Exception());
                return Content(res.ToXml());
            }
            //查询订单成功
            else
            {
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "SUCCESS");
                res.SetValue("return_msg", "OK");
                Log.Info(this.GetType().ToString(), "order query success : " + res.ToXml()); 
                service.PaySuccess(transaction_id, data.GetValue("out_trade_no").ToString(), "wx");
                return Content(res.ToXml());
            }
        }

        public void ResultUnion()
        {
            DataBase.DbHelperSQL.WriteLog("来自银联异步通知", default(Exception));
            try
            { 
                var orderNo = Request.Form["orderNumber"];
                var trackId = Request.Form["signature"]; 
                if (!string.IsNullOrEmpty(orderNo) && !string.IsNullOrEmpty(trackId))
                {
                  Orders order =  service.GetOrderByOrderNo(orderNo);  
                } 
            }
            catch (Exception ex)
            {
                DataBase.DbHelperSQL.WriteLog("处理发生异常", ex);

            }
            DataBase.DbHelperSQL.WriteLog("处理结束", default(Exception));
        }

        public void NotifyUnion()
        {
            DataBase.DbHelperSQL.WriteLog("来自银联异步通知", default(Exception));
            try
            { 
                var orderId = Request.Form["orderNumber"];
                var trackId = Request.Form["signature"]; 
                if (!string.IsNullOrEmpty(orderId) && !string.IsNullOrEmpty(trackId))
                {
                    service.PaySuccess(trackId, orderId, "union");
                    DataBase.DbHelperSQL.WriteLog("验证成功！", new Exception());
                } 
            }
            catch (Exception ex)
            {
                DataBase.DbHelperSQL.WriteLog("处理发生异常", ex);

            }
            DataBase.DbHelperSQL.WriteLog("处理结束", default(Exception));
        }

        private static readonly AliPayNotice aliPay = new AliPayNotice();
        public void NotifyAop()
        {
            DataBase.DbHelperSQL.WriteLog("来自支付宝异步通知 回调开始\r\n" + Request.Url.ToString(), default(Exception));
            try
            {
                aliPay.PayNotice(HttpContext);
            }
            catch (Exception ex)
            {
                DataBase.DbHelperSQL.WriteLog("处理失败！", ex);
            }
        }
    }


    public class AliPayNotice
    {
        public void PayNotice(HttpContextBase context)
        {
            SortedDictionary<string, string> sPara = GetRequestPost(context);

            if (sPara.Count > 0)//判断是否有带返回参数
            {
                if (Verify(sPara, context.Request.Form["notify_id"], context.Request.Form["sign"]))//验证成功
                {
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //请在这里加上商户的业务逻辑程序代码
                    DataBase.DbHelperSQL.WriteLog("支付宝成功回调验证通过！", new Exception());
                    //商户订单号
                    string out_trade_no = context.Request.Form["out_trade_no"];

                    //支付宝交易号
                    string trade_no = context.Request.Form["trade_no"];

                    //交易状态
                    string trade_status = context.Request.Form["trade_status"];

                    if (trade_status == "TRADE_FINISHED")
                    {
                        //判断该笔订单是否在商户网站中已经做过处理
                        //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                        //请务必判断请求时的total_fee、seller_id与通知时获取的total_fee、seller_id为一致的
                        //如果有做过处理，不执行商户的业务程序

                        //注意：
                        //退款日期超过可退款期限后（如三个月可退款），支付宝系统发送该交易状态通知
                    }
                    else if (trade_status == "TRADE_SUCCESS")
                    {
                        MemberService service = new MemberService();
                        service.PaySuccess(trade_no, out_trade_no, "alipay");
                        DataBase.DbHelperSQL.WriteLog("交易成功！", new Exception());
                    }
                    else
                    {
                    }

                    //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

                    context.Response.Write("success");  //请不要修改或删除

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
                else//验证失败
                {
                    context.Response.Write("fail");
                    DataBase.DbHelperSQL.WriteLog("回调验证失败！", new Exception());
                }
            }
            else
            {
                context.Response.Write("无通知参数");
                DataBase.DbHelperSQL.WriteLog("回调无参数！", new Exception());
            }
            DataBase.DbHelperSQL.WriteLog("回调处理结束！", new Exception());
        }

        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestPost(HttpContextBase context)
        {
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            var requestItem = context.Request.Form.AllKeys;
            for (var i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], context.Request.Form[requestItem[i]]);
            }
            return sArray;
        }
        /// <summary>
        /// 获取返回时的签名验证结果
        /// </summary>
        /// <param name="inputPara">通知返回参数数组</param>
        /// <param name="sign">对比的签名结果</param>
        /// <returns>签名验证结果</returns>
        private bool GetSignVeryfy(SortedDictionary<string, string> inputPara, string sign)
        {
            Dictionary<string, string> sPara = new Dictionary<string, string>();

            //过滤空值、sign与sign_type参数
            sPara = Core.FilterPara(inputPara);

            //获取待签名字符串
            string preSignStr = Core.CreateLinkString(sPara);

            //获得签名验证结果
            return AlipayMD5.Verify(preSignStr, sign, PayConfig.Aop.AlipayKey, "utf-8");
        }

        public bool Verify(SortedDictionary<string, string> inputPara, string notify_id, string sign)
        {
            if (bool.Parse(GetResponseTxt(notify_id)) && GetSignVeryfy(inputPara, sign))//验证成功
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取是否是支付宝服务器发来的请求的验证结果
        /// </summary>
        /// <param name="notify_id">通知验证ID</param>
        /// <returns>验证结果</returns>
        private string GetResponseTxt(string notify_id)
        {
            string veryfy_url = "https://mapi.alipay.com/gateway.do?service=notify_verify&partner=" + PayConfig.Aop.AlipayPartner + "&notify_id=" + notify_id;

            //获取远程服务器ATN结果，验证是否是支付宝服务器发来的请求
            string responseTxt = Get_Http(veryfy_url, 120000);

            return responseTxt;
        }

        /// <summary>
        /// 获取远程服务器ATN结果
        /// </summary>
        /// <param name="strUrl">指定URL路径地址</param>
        /// <param name="timeout">超时时间设置</param>
        /// <returns>服务器ATN结果</returns>
        private string Get_Http(string strUrl, int timeout)
        {
            string strResult;
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(strUrl);
                myReq.Timeout = timeout;
                HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
                Stream myStream = HttpWResp.GetResponseStream();
                StreamReader sr = new StreamReader(myStream, Encoding.Default);
                StringBuilder strBuilder = new StringBuilder();
                while (-1 != sr.Peek())
                {
                    strBuilder.Append(sr.ReadLine());
                }

                strResult = strBuilder.ToString();
            }
            catch (Exception exp)
            {
                strResult = "错误：" + exp.Message;
            }

            return strResult;
        }
    }

    public sealed class AlipayMD5
    {
        public AlipayMD5()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 签名字符串
        /// </summary>
        /// <param name="prestr">需要签名的字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="_input_charset">编码格式</param>
        /// <returns>签名结果</returns>
        public static string Sign(string prestr, string key, string _input_charset)
        {
            StringBuilder sb = new StringBuilder(32);

            prestr = prestr + key;

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(prestr));
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }

            return sb.ToString();
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="prestr">需要签名的字符串</param>
        /// <param name="sign">签名结果</param>
        /// <param name="key">密钥</param>
        /// <param name="_input_charset">编码格式</param>
        /// <returns>验证结果</returns>
        public static bool Verify(string prestr, string sign, string key, string _input_charset)
        {
            string mysign = Sign(prestr, key, _input_charset);
            if (mysign == sign)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Core
    {
        public Core()
        {
        }

        /// <summary>
        /// 除去数组中的空值和签名参数并以字母a到z的顺序排序
        /// </summary>
        /// <param name="dicArrayPre">过滤前的参数组</param>
        /// <returns>过滤后的参数组</returns>
        public static Dictionary<string, string> FilterPara(SortedDictionary<string, string> dicArrayPre)
        {
            Dictionary<string, string> dicArray = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> temp in dicArrayPre)
            {
                if (temp.Key.ToLower() != "sign" && temp.Key.ToLower() != "sign_type" && temp.Value != "" && temp.Value != null)
                {
                    dicArray.Add(temp.Key, temp.Value);
                }
            }

            return dicArray;
        }

        /// <summary>
        /// 把数组所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串
        /// </summary>
        /// <param name="sArray">需要拼接的数组</param>
        /// <returns>拼接完成以后的字符串</returns>
        public static string CreateLinkString(Dictionary<string, string> dicArray)
        {
            StringBuilder prestr = new StringBuilder();
            foreach (KeyValuePair<string, string> temp in dicArray)
            {
                prestr.Append(temp.Key + "=" + temp.Value + "&");
            }

            //去掉最後一個&字符
            int nLen = prestr.Length;
            prestr.Remove(nLen - 1, 1);

            return prestr.ToString();
        }

        /// <summary>
        /// 把数组所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串，并对参数值做urlencode
        /// </summary>
        /// <param name="sArray">需要拼接的数组</param>
        /// <param name="code">字符编码</param>
        /// <returns>拼接完成以后的字符串</returns>
        public static string CreateLinkStringUrlencode(Dictionary<string, string> dicArray, Encoding code)
        {
            StringBuilder prestr = new StringBuilder();
            foreach (KeyValuePair<string, string> temp in dicArray)
            {
                prestr.Append(temp.Key + "=" + HttpUtility.UrlEncode(temp.Value, code) + "&");
            }

            //去掉最後一個&字符
            int nLen = prestr.Length;
            prestr.Remove(nLen - 1, 1);

            return prestr.ToString();
        }

        /// <summary>
        /// 获取文件的md5摘要
        /// </summary>
        /// <param name="sFile">文件流</param>
        /// <returns>MD5摘要结果</returns>
        public static string GetAbstractToMD5(Stream sFile)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(sFile);
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取文件的md5摘要
        /// </summary>
        /// <param name="dataFile">文件流</param>
        /// <returns>MD5摘要结果</returns>
        public static string GetAbstractToMD5(byte[] dataFile)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(dataFile);
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        } 
    }
}
