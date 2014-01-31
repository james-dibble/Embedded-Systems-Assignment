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

        public ActionResult KnowledgeLevelSelect()
        {
            var knowledgeLevels = this._knowledgeLevelService.GetAll();

            return this.PartialView(knowledgeLevels);
        }
    }
}