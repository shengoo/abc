using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;

namespace mvcweb.Controllers
{
    public class TeamController : BascVirtualController
    {
        private TeamService teamService = new TeamService();
        public ActionResult Team()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }

        public ActionResult GetForeignTearcher()
        {
            return Json(teamService.GetForeignTeature(),JsonRequestBehavior.AllowGet);
        }
    }
}