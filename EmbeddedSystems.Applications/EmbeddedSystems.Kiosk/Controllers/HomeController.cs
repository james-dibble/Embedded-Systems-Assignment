using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmbeddedSystems.DomainModel;
using EmbeddedSystems.ServiceLayer;

namespace EmbeddedSystems.Kiosk.Controllers
{
    public class HomeController : Controller
    {
        /*private readonly IHandsetService _handsetService;
        private readonly ILanguageService _languageService;
        private readonly IKnowledgeLevelService _knowledgeLevelService;
        private readonly ICustomerService _customerService;

        public HomeController(IHandsetService handsetService, ILanguageService languageService, IKnowledgeLevelService knowledgeLevelService, ICustomerService customerService)
        {
            this._handsetService = handsetService;

            this._languageService = languageService;
            this._knowledgeLevelService = knowledgeLevelService;
            this._customerService = customerService;
        }*/

        public ActionResult KioskSignUp()
        {
            return View();
        }

        public ActionResult Language()
        {
            return View();
        }

        public ActionResult GetForm(string FirstName, string Surname, string Address, string Tel, string Email)
        {
            return this.Content("First Name =" + FirstName + ", Surname =" + Surname + ", Address =" + Address + ", Tel =" + Tel + ", Email =" +
                Email);

        }
    }
}
