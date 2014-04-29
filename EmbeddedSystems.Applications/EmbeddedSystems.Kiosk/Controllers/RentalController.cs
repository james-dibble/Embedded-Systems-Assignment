using EmbeddedSystems.DomainModel;
using EmbeddedSystems.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmbeddedSystems.Kiosk.Controllers
{
    public class RentalController : Controller
    {
        private readonly IHandsetService _handsetService;
        private readonly ILanguageService _languageService;
        private readonly IKnowledgeLevelService _knowledgeLevelService;
        private readonly ICustomerService _customerService;

        public RentalController(IHandsetService handsetService, ILanguageService languageService, IKnowledgeLevelService knowledgeLevelService, ICustomerService customerService)
        {
            this._handsetService = handsetService;
            this._languageService = languageService;
            this._knowledgeLevelService = knowledgeLevelService;
            this._customerService = customerService;
        }


        public ActionResult NewRental(Customer customer, string DisplayName, int knowledgeLevelId)
        {
            customer.Language = this._languageService.GetByName(DisplayName);
            customer.KnowledgeLevel = this._knowledgeLevelService.GetKnowledgeLevel(knowledgeLevelId);

            this._customerService.CreateCustomer(customer);
            var rental = this._handsetService.RentHandset(customer);
            return View("~/Views/Home/Confirm.cshtml", rental);
        }

    }
}
