using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmbeddedSystems.Kiosk.Controllers
{
    public class CultureController : Controller
    {
        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }

        public ActionResult SetCulture(string lang)
        {
            Session["Culture"] = new CultureInfo(lang);
            return RedirectToAction("KioskSignUp","Home");
        }
    }
}
