
using System.Web;
using System.Web.Mvc;

namespace mvcweb.Controllers
{
    public class PurchaseNoController : BascVirtualController
    {
        //
        // GET: /PurchaseNo/

        public ActionResult PurchaseNo()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }

    }
}
