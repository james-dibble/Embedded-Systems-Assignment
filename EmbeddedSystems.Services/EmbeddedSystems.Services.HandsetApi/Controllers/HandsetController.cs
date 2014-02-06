// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HandsetController.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.Services.HandsetApi.Controllers
{
    using System.Web;
    using System.Web.Http;

    using EmbeddedSystems.DomainModel;
    using EmbeddedSystems.Security;

    public class HandsetController : ApiController
    {
        private readonly IAuthorizationService _authorizationService;

        public HandsetController(IAuthorizationService authorizationService)
        {
            this._authorizationService = authorizationService;
        }

        [HttpGet]
        [RequiresAuthentication]
        public HandsetRental Authenticate()
        {
            var handset = HttpContext.Current.User.Identity as AuthenticatedHandset;

            return handset.Rental;
        }
    }
}