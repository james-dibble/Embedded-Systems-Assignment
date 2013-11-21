// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterConfig.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.Services.HandsetApi
{
    using System.Web.Http;
    using System.Web.Mvc;

    using EmbeddedSystems.Security;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}