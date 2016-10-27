
using System.Web;
using System.Web.Mvc;

namespace mvcweb.Controllers
{
    public class PurchaseController : BascVirtualController
    {
        //
        // GET: /Purchase/

        public ActionResult Purchase()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }

        public ActionResult CourseList()
        {
            return View();
        }

        public ActionResult CourseTable()
        {
            return View();
        }

        public ActionResult Evaluate()
        {
            return View();
        }

        public ActionResult Buy()
        {
            return View();
        }

    }
}
