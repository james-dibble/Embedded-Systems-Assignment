using EmbeddedSystems.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmbeddedSystems.DomainModel;

namespace EmbeddedSystems.Admin.Controllers
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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewRental()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewRental(Customer customer, int languageId, int knowledgeLevelId)
        {
            customer.Language = this._languageService.GetLanguage(languageId);
            customer.KnowledgeLevel = this._knowledgeLevelService.GetKnowledgeLevel(knowledgeLevelId);

            this._customerService.CreateCustomer(customer);
            this._handsetService.RentHandset(customer);
            return this.Content("COMPLETE");
        }

        public ActionResult GetRentalByCustomer(int customerId)
        {
            var Model = this._handsetService.GetAllRentalsForCustomer(customerId);

            return this.PartialView("~/Views/Rental/CustomerRental.cshtml", Model);
        }
    }
}
