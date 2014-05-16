using EmbeddedSystems.DomainModel;
using EmbeddedSystems.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmbeddedSystems.Admin.Controllers
{
    public class ExhibitController : Controller
    {
        private readonly IAudioFileService _audioFileService;
        private readonly IExhibitService _exhibitService;
        private readonly IKnowledgeLevelService _knowledgeLevelService;
        private readonly ILanguageService _languageService;

        public ExhibitController(IAudioFileService audioFileService, IExhibitService exhibitService, IKnowledgeLevelService knowledgeLevelService, ILanguageService languageService)
        {
            this._audioFileService = audioFileService;
            this._exhibitService = exhibitService;
            this._knowledgeLevelService = knowledgeLevelService;
            this._languageService = languageService;
        }

        public ActionResult Index()
        {
            var allExhibits = this._exhibitService.GetAll();

            return View(allExhibits);
        }

        public ActionResult GetAudioFilesByExhibit(int exhibitId)
        {
            var exhibitFiles = this._audioFileService.GetFilesForExhibit(exhibitId);

            return this.PartialView("~/Views/Audio/ExhibitAudio.cshtml", exhibitFiles);
        }

        public ActionResult AddExhibit(Exhibit exhibit)
        {
            this._exhibitService.CreateExhibit(exhibit);

            return this.RedirectToAction("Index", "Exhibit");
        }

        public ActionResult AudioUpload()
        {
            var model = this._knowledgeLevelService.GetAll();

            return this.PartialView("~/Views/Exhibit/AudioFiles.cshtml", model);
        }

        public ActionResult ExhibitSelect()
        {
            var exhibits = this._exhibitService.GetAll();

            return this.PartialView(exhibits);
        }
    }
}