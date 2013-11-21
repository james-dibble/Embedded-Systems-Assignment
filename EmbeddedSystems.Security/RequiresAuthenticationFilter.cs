// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequiresAuthenticationFilter.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.Security
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Principal;
    using System.Text;
    using System.Web;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    using EmbeddedSystems.DomainModel;

    /// <summary>
    /// An attribute to define methods that require basic authentication to be used by the <see cref="Handset"/>.
    /// </summary>
    public class RequiresAuthenticationFilter : ActionFilterAttribute
    {
        private readonly IAuthorizationService _authorizationService;

        /// <summary>
        /// Initialises a new instance of the <see cref="RequiresAuthenticationFilter"/> class.
        /// </summary>
        /// <param name="authorizationService">An a service to process handset authentication.</param>
        public RequiresAuthenticationFilter(IAuthorizationService authorizationService)
        {
            this._authorizationService = authorizationService;
        }

        /// <summary>
        /// Occurs before the action method is invoked.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ActionDescriptor.GetCustomAttributes<RequiresAuthenticationAttribute>().Any())
            {
                return;
            }

            var authorizationToken = actionContext.Request.Headers.Authorization;

            if (authorizationToken == null)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return;
            }

            var tokens = Encoding.UTF8.GetString(Convert.FromBase64String(authorizationToken.Parameter)).Split(':');

            try
            {
                var handsetNumber = Convert.ToInt32(tokens.ElementAt(0));
                var handsetPin = Convert.ToInt32(tokens.ElementAt(1));

                var rental = this._authorizationService.AuthenticateHandsetRental(handsetNumber, handsetPin);

                if (rental == null)
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                    return;
                }

                HttpContext.Current.User = new GenericPrincipal(new AuthenticatedHandset(rental), new string[] { });
            }
            catch
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}