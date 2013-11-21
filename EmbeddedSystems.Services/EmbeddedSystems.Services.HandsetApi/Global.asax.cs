// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebApiApplication.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.Services.HandsetApi
{
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            ApiFilterConfig.RegisterWebApiFilters(GlobalConfiguration.Configuration.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}