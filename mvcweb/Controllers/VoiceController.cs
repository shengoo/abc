using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcweb.Controllers
{
    using Service;

    public class VoiceController:BascVirtualController
    {
        public ActionResult Voice()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }

        public ActionResult GetVoice(string siteType="0")
        {
            return Json(new WebPageService().GetVoice(siteType));
        }

        /// <summary>
        /// 少儿版获取明星学员
        /// </summary>
        /// <returns></returns>
        public ActionResult GetStarStudent()
        {
            return Json(new WebPageService().GetStarStudent());
        }
    }
}