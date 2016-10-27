
using System.Web;
using System.Web.Mvc;

namespace mvcweb.Controllers
{
    public class OptionController : BascVirtualController
    {
        //
        // GET: /Option/

        public ActionResult Option()
        {
            ViewBag.Path = GetBaseVirtualPath;
            return View();
        }

    }
}
