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
        private readonly IExhibitService _exhibitService;
        private readonly ICustomerService _customerService;

        public FileController(IAudioFileService audioFileService, IExhibitService exhibitService, ICustomerService customerService)
        {
            this._audioFileService = audioFileService;
            this._exhibitService = exhibitService;
            this._customerService = customerService;
        }

        public AudioFile Get(int id)
        {
            var exhibit = this._exhibitService.GetExhibitByHandsetKey(id);

            // TODO - JD: Use some sort of authentication mechanism to get the customer using this
            //            the handset making this request.
            var customer = this._customerService.GetCustomer(1);

            var file = this._audioFileService.GetFile(exhibit, customer.KnowledgeLevel, customer.Language);

            return file;
        }
    }
}