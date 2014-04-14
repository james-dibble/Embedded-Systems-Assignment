using EmbeddedSystems.DomainModel;
using EmbeddedSystems.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmbeddedSystems.Admin.Controllers
{
    public class AudioController : Controller
    {
        private readonly IAudioFileService _audioFileService;
        private readonly ILanguageService _languageService;
        private readonly IKnowledgeLevelService _knowledgeLevelService;
        private readonly IExhibitService _exhibitService;

        public AudioController(IAudioFileService audioFileService, ILanguageService languageService, IKnowledgeLevelService knowledgeLevelService, IExhibitService exhibitService)
        {
            this._audioFileService = audioFileService;
            this._languageService = languageService;
            this._knowledgeLevelService = knowledgeLevelService;
            this._exhibitService = exhibitService;
        }

        public ActionResult Index()
        {
            var allfiles = this._audioFileService.GetAll();
            return View(allfiles);
        }

        public ActionResult AddAudioFile(AudioFile audioFile, int exhibitId, int languageId, int knowledgeLevelId, HttpPostedFileBase file)
        {
            //upload file & return file path
            string filePath = "test/test.mp3";
            
            this._audioFileService.CreateAudioFile(audioFile);
            
            audioFile.Exhibit = this._exhibitService.GetExhibit(exhibitId);
            audioFile.Language = this._languageService.GetLanguage(languageId);
            audioFile.KnowledgeLevel = this._knowledgeLevelService.GetKnowledgeLevel(knowledgeLevelId);
            audioFile.FilePath = filePath;

            return this.RedirectToAction("Index", "Audio");
        }
    }
}
