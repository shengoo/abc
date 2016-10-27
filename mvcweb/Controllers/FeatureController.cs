using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcweb.Controllers
{
    public class FeatureController : BascVirtualController
    {
        public ActionResult Feature()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }
    }
}