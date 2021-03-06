﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterConfig.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.Services.HandsetApi
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Filters;
    using System.Web.Mvc;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}