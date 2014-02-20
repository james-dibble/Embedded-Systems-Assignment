namespace EmbeddedSystems.Admin.Controllers
{
    using EmbeddedSystems.ServiceLayer;
    using System.Web.Mvc;

    public class KnowledgeLevelController : Controller
    {
        private readonly IKnowledgeLevelService _knowledgeLevelService;

        public KnowledgeLevelController(IKnowledgeLevelService knowledgeLevelService)
        {
            this._knowledgeLevelService = knowledgeLevelService;
        }

        public ActionResult Index()
        {
            var model = this._knowledgeLevelService.GetAll();

            return View(model);
        }

        public ActionResult KnowledgeLevelSelect()
        {
            var knowledgeLevels = this._knowledgeLevelService.GetAll();

            return this.PartialView(knowledgeLevels);
        }

        public ActionResult AddKnowledgeLevel(string description)
        {
            this._knowledgeLevelService.AddKnowledgeLevel(description);

            return RedirectToAction("Index", "KnowledgeLevel");
        }
    }
}