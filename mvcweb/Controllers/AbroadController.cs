using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcweb.Controllers
{
    public class AbroadController : Controller
    {
        //
        // GET: /Abroad/

        public ActionResult Index()
        {

            ViewBag.PicUrl = System.Configuration.ConfigurationManager.AppSettings["studyabroad"];
            return View();
        }

        public ActionResult Train()
        {
            return View();
        }
    }
}
