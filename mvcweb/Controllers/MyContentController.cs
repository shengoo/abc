
using System.Web;
using System.Web.Mvc;

namespace mvcweb.Controllers
{
    public class MyContentController : BascVirtualController
    {
        //
        // GET: /MyContent/

        public ActionResult MyContent()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }

    }
}
