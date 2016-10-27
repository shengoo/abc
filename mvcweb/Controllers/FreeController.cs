using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcweb.Controllers
{
    public class FreeController : BascVirtualController
    {
        public ActionResult Free()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }
    }
}