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

        public CustomerController(ILanguageService languageService)
        {
            this._languageService = languageService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditCustomer(Customer customer, int knowledgeLevelId, int languageId)
        {
            return View();
        }

    }
}
