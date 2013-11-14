// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileController.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.Services.HandsetApi.Controllers
{
    using System.Web.Http;

    using EmbeddedSystems.DomainModel;
    using EmbeddedSystems.ServiceLayer;

    public class FileController : ApiController
    {
        private readonly IAudioFileService _audioFileService;

        public FileController(IAudioFileService audioFileService)
        {
            this._audioFileService = audioFileService;
        }

        public AudioFile Get(int exhibitId)
        {
            return null;
        }
    }
}