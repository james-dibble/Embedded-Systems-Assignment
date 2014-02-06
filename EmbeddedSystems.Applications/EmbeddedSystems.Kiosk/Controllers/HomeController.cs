using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmbeddedSystems.Kiosk.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult KioskSignUp()
        {
            return View();
        }

        public ActionResult GetForm(string FirstName)
        {
            return this.Content("First Name =" + FirstName);
        }

    }
}
