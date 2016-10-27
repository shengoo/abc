
using System.Web;
using System.Web.Mvc;

namespace mvcweb.Controllers
{
    public class PurchaseThController : BascVirtualController
    {
        //
        // GET: /PurchaseTh/

        public ActionResult PurchaseTh()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }

    }
}
