﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcweb.Controllers
{
    public class MemberSemController : BascVirtualController
    {
        //
        // GET: /MemberSem/

        public ActionResult MemberSem()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }

    }
}
