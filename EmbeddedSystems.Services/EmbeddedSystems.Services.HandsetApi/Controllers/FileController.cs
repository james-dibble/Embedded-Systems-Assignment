// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileController.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.Services.HandsetApi.Controllers
{
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;

    using EmbeddedSystems.DomainModel;
    using EmbeddedSystems.Security;
    using EmbeddedSystems.ServiceLayer;

    public class FileController : ApiController
    {
        private readonly IAudioFileService _audioFileService;
        private readonly IExhibitService _exhibitService;
        private readonly ICustomerService _customerService;

        public FileController(IAudioFileService audioFileService, IExhibitService exhibitService, ICustomerService customerService, IAuthorizationService authorizationService)
        {
            this._audioFileService = audioFileService;
            this._exhibitService = exhibitService;
            this._customerService = customerService;
        }

        [RequiresAuthentication]
        public AudioFile Get(int exhibitId)
        {
            var exhibit = this._exhibitService.GetExhibitByHandsetKey(exhibitId);

            var rental = (HttpContext.Current.User.Identity as IAuthenticatedHandset).Rental;
            
            var customer = this._customerService.GetCustomer(rental.Customer.Id);

            var file = this._audioFileService.GetFile(exhibit, customer.KnowledgeLevel, customer.Language);

            return file;
        }
    }
}