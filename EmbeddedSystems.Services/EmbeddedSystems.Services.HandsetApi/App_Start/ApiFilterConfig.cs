// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiFilterConfig.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.Services.HandsetApi
{
    using System.Web.Http;

    using EmbeddedSystems.Security;

    public class ApiFilterConfig
    {
        public static void RegisterWebApiFilters(System.Web.Http.Filters.HttpFilterCollection filters)
        {
            var authorizationService =
                (IAuthorizationService)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IAuthorizationService));

            filters.Add(new RequiresAuthenticationFilter(authorizationService));
        } 
    }
}