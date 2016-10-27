using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using ThoughtWorks.QRCode.Codec;
using System.Drawing;
using System.Text;
using System.Drawing.Imaging;
using WxPayAPI;

namespace mvcweb.Controllers
{
    public class HomeController : BascVirtualController
    {
        MemberService service = new MemberService();
        WebPageService pageSrv = new WebPageService();
        BuyClassService bugService = new BuyClassService();


        public ActionResult WeiXinPayImgPath(int OrderId)
        {
 
          //  var str = Common.GetDistanceInfo("http://www.gistoyou.com/MOBILE/pay/GetQRCode", "{\"OrderId\":\"" + OrderId + "\"}");
            var str = GetPayUrl(OrderId.ToString());
 
            //string url = System.Configuration.ConfigurationManager.AppSettings["SsoUrl"];
            //var str = Common.GetDistanceInfo(url+"/pay/GetQRCode", "{\"OrderId\":\"" + OrderId + "\"}");
 

            //初始化二维码生成工具
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            qrCodeEncoder.QRCodeVersion = 0;
            qrCodeEncoder.QRCodeScale = 4;

            //将字符串生成二维码图片
         //   Bitmap image = qrCodeEncoder.Encode(JObject.Parse(str).Last.Last.Last.Values().First().ToString(), Encoding.Default);

            Bitmap image = qrCodeEncoder.Encode(str, Encoding.Default);

            //保存为PNG到内存流  
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);

            return File(ms.GetBuffer(), "image/png");
        }

        public ActionResult Index()
        {
            var usercookies = HttpContext.Request.Cookies.Get("logininfo");
            var userId = "";
            if (usercookies != null)
            {
                if (!string.IsNullOrEmpty(usercookies.Value))
                {
                    var userinfo = Common.DesEncrypt(usercookies.Value);
                    userinfo = HttpUtility.UrlDecode(userinfo, System.Text.Encoding.GetEncoding("UTF-8"));
                    var usemerminfo = JsonConvert.DeserializeObject<MemberDto>(userinfo);
                    userId = usemerminfo.Id.ToString();
                }
            }
            ViewBag.Id = userId;
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }

        public ActionResult Home()
        {
            ViewBag.Path = GetBaseVirtualPath;
            ViewBag.VideoUrl = System.Configuration.ConfigurationManager.AppSettings["videourl"];
            return View();
        }

        public ActionResult TeacherLogin()
        {
            var path= GetBaseVirtualPath;
            ViewBag.Path = path;
            return View();
        }

        public ActionResult Teacher()
        {
            var path = GetBaseVirtualPath;
            return View();
        }

        public ActionResult GetWebSiteImages(int siteType, int typeId)
        {
            return Json(pageSrv.GetPageImages(siteType, typeId));
        }

        [HttpPost]
        public ActionResult GetArtcleForFooter()
        {
            var list = pageSrv.GetArtListForFooter();
            var ret = list != null && list.Count > 0;
            return Json(new { ret = ret, obj = list });
        }
        public ActionResult Login(string userName, string Pwd, bool isSave)
        {
            var member = new Member()
            {
                UserName = userName,
                Pwd = Common.Encrypt(Pwd)
            };
            var obj = service.Login(member);

            if (obj.IsSuccess)
            {
                SignCookie(obj.Result, isSave);
            }

            return Json(new Response<MemberDto> { Result = obj.IsSuccess ? ConvertMember(obj.Result) : null, ErrMsg = obj.ErrMsg });
        }

        public ActionResult MemberTeacherLogin(string userName, string Pwd, bool isSave)
        {
            var member = new Member()
            {
                UserName = userName,
                Pwd = Common.Encrypt(Pwd)
            };
            var obj = service.TeacherLogin(member);

            if (obj.IsSuccess)
            {
                SignCookie(obj.Result, isSave);
            }

            return Json(new Response<MemberDto> { Result = obj.IsSuccess ? ConvertTeacherMember(obj.Result) : null, ErrMsg = obj.ErrMsg });
        }

        private MemberDto ConvertMember(Member member)
        {
            return new MemberDto
            {
                Id = member.Id,
                Name = !string.IsNullOrEmpty(member.CNName) ? member.CNName : !string.IsNullOrEmpty(member.ENName) ? member.ENName : member.Mobile,
                Type = member.MemberType,
                Logo = member.Logo
            };
        }

        private MemberDto ConvertTeacherMember(Member member)
        {
            return new MemberDto
            {
                Id = member.Id,
                Name = !string.IsNullOrEmpty(member.ENName) ? member.ENName :member.UserName,
                Type = member.MemberType,
                Logo = member.Logo
            };
        }

        public ActionResult LoginOut()
        {
            var cookie = HttpContext.Response.Cookies.Get("logininfo");
            cookie.Expires = DateTime.Now;
            HttpContext.Response.SetCookie(cookie);
            return Json(new Response<bool>());
        }

        public ActionResult GetLogin()
        {
            var obj = new Response<MemberDto>();
            try
            {
                obj.Result = Common.GetCurrentUser(HttpContext);

                if (obj.Result == null)
                {
                    obj.ErrMsg = "未登录";
                }
                else
                {
                    obj.Result = ConvertMember(new MemberService().GetMember(obj.Result.Id).Result);
                }
            }
            catch (Exception ex)
            {
                DataBase.DbHelperSQL.WriteLog("用户自动登录异常", ex);
                obj.ErrMsg = "未登录";
            }
            return Json(obj);
        }

        public ActionResult GetTeacherLogin()
        {
            var obj = new Response<MemberDto>();
            try
            {
                obj.Result = Common.GetCurrentUser(HttpContext);

                if (obj.Result == null)
                {
                    obj.ErrMsg = "Not signed";
                }
                else
                {
                    obj.Result = ConvertMember(new MemberService().GetMember(obj.Result.Id).Result);
                }
            }
            catch (Exception ex)
            {
                DataBase.DbHelperSQL.WriteLog("用户自动登录异常", ex);
                obj.ErrMsg = "Not signed";
            }
            return Json(obj);
        }
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Register(string user, string pwd, int userType, string valid)
        {
            var res = new Response<MemberDto>();
            if (Session["uuid"] != null && service.ExistMemberValid(user, Session["uuid"].ToString(), valid))
            {
                if (!service.ExistMember(user))
                {
                    var obj = service.Register(new Member
                    {
                        Mobile = user,
                        UserName = user,
                        MemberType = userType,
                        Pwd = Common.Encrypt(pwd)
                    });

                    if (obj.IsSuccess)
                    {
                        SignCookie(obj.Result);
                    }
                    res.ErrMsg = obj.ErrMsg;
                    res.Result = obj.IsSuccess ? ConvertMember(obj.Result) : null;
                }
                else
                {
                    res.ErrMsg = "用户电话号码已注册！您可以找回密码!";
                }
            }
            else
            {
                res.ErrMsg = "验证码无效！请重新获取验证码！";
            }
            return Json(res);
        }

        public ActionResult ModifyPassword(string user, string pwd, string valid)
        {
            var res = new Response<MemberDto>();
            if (Session["uuid"] != null && service.ExistMemberValid(user, Session["uuid"].ToString(), valid))
            {
                var member = DataBase.DbHelperSQL.ExcuteScaler<Member>("select * from Member where username=@0", user).FirstOrDefault();
                if (member != null)
                {
                    var obj = service.UpdatePassword(member.Id, member.Pwd, Common.Encrypt(pwd));
                    if (obj.IsSuccess)
                    {
                        SignCookie(member);
                    }
                    res.Result = obj.IsSuccess ? ConvertMember(member) : null;
                    res.ErrMsg = obj.ErrMsg;
                }
                else
                {
                    res.ErrMsg = "用户名不存在！";
                }
            }
            else
            {
                res.ErrMsg = "验证码无效！请重新获取验证码！";
            }
            return Json(res);
        }

        public ActionResult ModifyPasswordForTeacher(string user, string pwd, string valid)
        {
            var res = new Response<MemberDto>();
            if (Session["uuid"] != null && service.ExistMemberValid(user, Session["uuid"].ToString(), valid))
            {
                var member = DataBase.DbHelperSQL.ExcuteScaler<Member>("select * from Member where username=@0", user).FirstOrDefault();
                if (member != null)
                {
                    var obj = service.UpdatePassword(member.Id, member.Pwd, Common.Encrypt(pwd),true);
                    if (obj.IsSuccess)
                    {
                        SignCookie(member);
                    }
                    res.Result = obj.IsSuccess ? ConvertMember(member) : null;
                    res.ErrMsg = obj.ErrMsg;
                }
                else
                {
                    res.ErrMsg = "Username does not exist！";
                }
            }
            else
            {
                res.ErrMsg = "Invalid verification code! Please get verification codes again!";
            }
            return Json(res);
        }

        [HttpPost]
        public ActionResult SendValid(string mobile, bool isupdate = true)
        {
            var res = new Response<bool>();
            //注册时 isupdate为true 验证电话号码存在时 不通过
            //找回密码时 isupdate为false 无需验证
            if (!isupdate && !service.ExistMember(mobile))
            {
                res.ErrMsg = "该手机号未注册！";
            }
            else if (isupdate && service.ExistMember(mobile))
            {
                res.ErrMsg = "该手机号已注册！";
            }
            else
            {
                var mobileValid = JsonConvert.DeserializeObject<MobileValid>(Common.GetDistanceInfo(Common.MessageUrl,
                    "{\"Mobile\":\"" + mobile + "\",\"SendTime\":\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\"}"));
                Session["uuid"] = mobileValid.UUID;
                if (mobileValid.UUID == null)
                {
                    res.ErrMsg = "短信发送失败！";
                }
                else {
                    res.ErrMsg = mobileValid.Result[0].Code == "1" ? null : mobileValid.Result[0].Message;
                }
            }
            return Json(res);
        }

        private void SignCookie(Member member, bool isSave = false)
        {
            var cookie = new HttpCookie("logininfo", Common.Encrypt(HttpUtility.UrlEncode(JsonConvert.SerializeObject(new MemberDto
            {
                Id = member.Id,
                Name = string.IsNullOrEmpty(member.ENName) ? string.IsNullOrEmpty(member.UserName) ? member.Mobile : member.UserName : member.ENName,
                Type = member.MemberType
            }), System.Text.Encoding.GetEncoding("UTF-8"))));
            cookie.HttpOnly = true;
            cookie.Expires = isSave ? DateTime.Now.AddMonths(1) : DateTime.Now.AddHours(4);
            HttpContext.Response.AppendCookie(cookie);
        }

        public string GetPayUrl(string productId)
        {
            DataBase.DbHelperSQL.WriteLog("进入GetPayUrl方法", new Exception());
             string url =null;
             Orders order = bugService.GetOrderById(Convert.ToInt32(productId));

            WxPayData data = new WxPayData();
            data.SetValue("body", "ABC在线课程");//商品描述
            //data.SetValue("attach", "test");//附加数据
            data.SetValue("out_trade_no", productId);//随机字符串
            data.SetValue("total_fee", Convert.ToInt32(order.TotalAmount*100));//总金额
            // data.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));//交易起始时间
            //data.SetValue("time_expire", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss"));//交易结束时间
            //data.SetValue("goods_tag", "jjj");//商品标记
            data.SetValue("trade_type", "NATIVE");//交易类型
            data.SetValue("product_id", productId);//商品ID 
            WxPayData result =null;

            try
            {
                result = WxPayApi.UnifiedOrder(data);//调用统一下单接口
                url = result.GetValue("code_url").ToString();//获得统一下单接口返回的二维码链接 
            }
            catch (Exception)
            {
                result = WxPayApi.UnifiedOrder(data);//调用统一下单接口
                url = result.GetValue("code_url").ToString();//获得统一下单接口返回的二维码链接 
            } 

           

            DataBase.DbHelperSQL.WriteLog("生成图片路径url："+url, new Exception());

            return url;
        }
    }
}
