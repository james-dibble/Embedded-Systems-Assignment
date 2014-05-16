using EmbeddedSystems.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmbeddedSystems.Admin.Controllers
{
    public class HandsetController : Controller
    {
        private readonly IHandsetService _handsetService;

        public HandsetController(IHandsetService handsetService)
        {
            this._handsetService = handsetService;
        }

        public ActionResult Index()
        {
            var model = this._handsetService.GetAllHandsets();
            return View(model);
        }

        public ActionResult HandsetSelect()
        {
            var handsets = this._handsetService.GetAllHandsets();

            return this.PartialView(handsets);
        }

        public ActionResult ExpireRental(int handsetId)
        {
            var rental = this._handsetService.GetCurrentRentalForHandset(handsetId);
            if (rental != null)
            {
                this._handsetService.ExpireRental(rental);
                return RedirectToAction("Index", "Handset");
            }
            return RedirectToAction("Index", "Handset");
        }

        public ActionResult AddHandset(string handsetNumber)
        {
            this._handsetService.CreateHandset(handsetNumber);
            return RedirectToAction("Index", "Handset");
        }
    }
}