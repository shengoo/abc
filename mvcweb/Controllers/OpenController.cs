using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Model;

namespace mvcweb.Controllers
{
    public class OpenController : BascVirtualController
    {
        WebPageService pageService = new WebPageService();
        public ActionResult Open()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }

        public ActionResult GetOpenClass()
        {
            var tempbobj = pageService.GetOpenClass(Common.GetCurrentUser(HttpContext));
            return Json(tempbobj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DayWord(int id, string artcleCateTitle = "", string artcleTitle = "", bool isfirstpage = false)
        {
            ViewBag.Path = GetBaseVirtualPath;
            var article = pageService.GetArticle(id);
            ViewBag.Title = article.Title;
            ViewBag.Content = article.Content;
            if (isfirstpage)
            {
                ViewBag.ArtcleCateTitle = "首页";
                ViewBag.ArtcleTitle = article.Title;
            }
            else
            {
                ViewBag.ArtcleCateTitle = artcleCateTitle;
                ViewBag.ArtcleTitle = artcleTitle;
            }
            return View("DayWord");
        }

        public ActionResult HoldOpenClass(int classId)
        {
            var member = Common.GetCurrentUser(HttpContext);
            var res = new Response<bool>();
            if (classId == 0 || member.Id == 0)
            {
                res.ErrMsg = "传入参数错误！";
            }
            else if (member.Type != 1)
            {
                res.ErrMsg = "非学员不能占座！";
            }
            else
            {
                res = pageService.HoldOpenClass(member.Id, classId);
            }
            return Json(res);
        }

        public ActionResult GetArticle()
        {
            var article = pageService.GetArticle();
            return Json(article, JsonRequestBehavior.AllowGet);
        }
    }
}