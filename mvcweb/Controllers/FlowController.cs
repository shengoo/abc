using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcweb.Controllers
{
    public class FlowController:BascVirtualController
    {
        public ActionResult Flow()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }
    }
}