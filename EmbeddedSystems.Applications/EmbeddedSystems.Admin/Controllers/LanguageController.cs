namespace EmbeddedSystems.Admin.Controllers
{
    using EmbeddedSystems.ServiceLayer;
    using System.Web.Mvc;

    public class LanguageController : Controller
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService LanguageService)
        {
            this._languageService = LanguageService;
        }

        public ActionResult Index()
        {
            var languages = this._languageService.GetAll();

            return View(languages);
        }

        public ActionResult LanguageSelect()
        {
            var languages = this._languageService.GetAll();

            return this.PartialView(languages);
        }

        public ActionResult AddLanguage(string name)
        {
            this._languageService.AddLanguage(name);

            return RedirectToAction("Index", "Language");
        }
    }
}