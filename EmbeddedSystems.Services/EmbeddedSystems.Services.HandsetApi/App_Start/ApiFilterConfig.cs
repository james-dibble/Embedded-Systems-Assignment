// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiFilterConfig.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.Services.HandsetApi
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Filters;

    using EmbeddedSystems.Security;

    public class ApiFilterConfig
    {
        public static void RegisterWebApiFilters(HttpFilterCollection filters)
        {
            var authorizationService =
                (IAuthorizationService)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IAuthorizationService));

            filters.Add(new RequiresAuthenticationFilter(authorizationService));
        } 
    }
    
    public class NullObjectActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if ((actionExecutedContext.Response != null) && actionExecutedContext.Response.IsSuccessStatusCode)
            {
                object contentValue = null;
                actionExecutedContext.Response.TryGetContentValue(out contentValue);
                if (contentValue == null)
                {
                    actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Object not found");
                }
            }
        }
    }
}