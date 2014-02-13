using EmbeddedSystems.DomainModel;
using EmbeddedSystems.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmbeddedSystems.Admin.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILanguageService _languageService;
        private readonly ICustomerService _customerService;
        private readonly IKnowledgeLevelService _knowledgeLevelService;

        public CustomerController(ICustomerService customerService, ILanguageService languageService, IKnowledgeLevelService knowledgeLevelService)
        {
            this._customerService = customerService;
            this._languageService = languageService;
            this._knowledgeLevelService = knowledgeLevelService;
        }

        public ActionResult Index()
        {
            var Model = this._customerService.GetAllCustomers();
            return View(Model);
        }

        public ActionResult AddCustomer(Customer customer, int languageId, int knowledgeLevelId)
        {
            this._customerService.CreateCustomer(customer);

            customer.Language = this._languageService.GetLanguage(languageId);
            customer.KnowledgeLevel = this._knowledgeLevelService.GetKnowledgeLevel(knowledgeLevelId);

            return View();
        }

        public ActionResult GetCustomerById(int customerId)
        {
            var Model = this._customerService.GetCustomer(customerId);

            return this.PartialView("~/Views/Rental/CustomerRental.cshtml", Model);
        }

        public ActionResult CustomerSelect()
        {
            var customers = this._customerService.GetAllCustomers();

            return this.PartialView(customers);
        }
    }
}
