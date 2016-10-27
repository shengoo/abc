using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcweb.Controllers
{
    public class YoungController : BascVirtualController
    {
        //
        // GET: /Young/

        public ActionResult Feature()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }

        public ActionResult Home()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }

        public ActionResult Flow()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }
        public ActionResult Free()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
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
        public ActionResult Model()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }
        public ActionResult Open()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }
        public ActionResult Team()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }
        public ActionResult Voice()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }
    }
}
