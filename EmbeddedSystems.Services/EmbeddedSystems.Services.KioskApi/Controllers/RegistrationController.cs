namespace EmbeddedSystems.Services.KioskApi.Controllers
{
    using EmbeddedSystems.DomainModel;
    using EmbeddedSystems.ServiceLayer;
    using EmbeddedSystems.Services.KioskApi.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class RegistrationController : ApiController
    {
        private readonly ILanguageService _languageService;
        private readonly IKnowledgeLevelService _knowledgeLevelService;
        private readonly ICustomerService _customerService;
        private readonly IHandsetService _handsetService;

        public RegistrationController(ILanguageService languageService, IKnowledgeLevelService knowledgeLevelService, ICustomerService customerService, IHandsetService handsetService)
        {
            this._languageService = languageService;
            this._knowledgeLevelService = knowledgeLevelService;
            this._customerService = customerService;
            this._handsetService = handsetService;
        }

        public HandsetRental Post([FromBody] RegisterCustomerModel customerDetails)
        {
            var language = this._languageService.GetLanguage(customerDetails.LanguageId);
            var knowledgeLevel = this._knowledgeLevelService.GetKnowledgeLevel(customerDetails.KnowledgeLevelId);

            var customer = this._customerService.CreateCustomer(customerDetails.Name, customerDetails.Mobile, customerDetails.Address, language, knowledgeLevel);

            var rental = this._handsetService.RentHandset(customer);

            return rental;
        }
    }
}
