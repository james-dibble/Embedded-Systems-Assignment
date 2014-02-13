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

        public ExhibitController(IAudioFileService audioFileService, IExhibitService exhibitService)
        {
            this._audioFileService = audioFileService;
            this._exhibitService = exhibitService;
        }

        public ActionResult Index()
        {
            var allExhibits = this._exhibitService.GetAllExhibits();

            return View(allExhibits);
        }

        public ActionResult GetAudioFilesByExhibit(int exhibitId)
        {
            var exhibitFiles = this._audioFileService.GetFilesForExhibit(exhibitId);

            return this.PartialView("~/Views/Audio/ExhibitAudio.cshtml", exhibitFiles);
        }
    }
}
