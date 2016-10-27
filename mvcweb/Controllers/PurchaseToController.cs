
using System.Web;
using System.Web.Mvc;

namespace mvcweb.Controllers
{
    public class PurchaseToController : BascVirtualController
    {
        //
        // GET: /PurchaseTo/

        public ActionResult PurchaseTo()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }

    }
}
