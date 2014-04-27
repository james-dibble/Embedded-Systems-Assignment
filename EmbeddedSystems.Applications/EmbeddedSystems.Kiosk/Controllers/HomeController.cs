using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmbeddedSystems.DomainModel;
using EmbeddedSystems.ServiceLayer;
using System.Globalization;

namespace EmbeddedSystems.Kiosk.Controllers
{
    public class HomeController : Controller
    {
        private readonly IKnowledgeLevelService _knowledgeLevelService;

        public HomeController(IKnowledgeLevelService knowledgeLevelService)
        {
            this._knowledgeLevelService = knowledgeLevelService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult KioskSignUp()
        {
            //var language = (CultureInfo)Session["Culture"];
            //var displayName = language.DisplayName;
            return this.View();
        }

        public ActionResult KnowledgeLevelSelect()
        {
            var knowledgeLevels = this._knowledgeLevelService.GetAll();

            return this.PartialView(knowledgeLevels);
        }

        public ActionResult Language()
        { 
            return this.View();
        }

        public ActionResult KnowledgeRadio()
        {
            var knowledgeLevels = this._knowledgeLevelService.GetAll();
            return this.PartialView(knowledgeLevels);
        }

        public ActionResult GetForm(string Name, string Address, string Tel, string Email)
        {
            return this.Content("Name =" + Name + ", Address =" + Address + ", Tel =" + Tel + ", Email =" +
                Email);

        }
    }
}
