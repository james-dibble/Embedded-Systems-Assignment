using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EmbeddedSystems.Admin
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "RentalCustomerId",
                url: "Rental/GetRentalByCustomer/{customerId}",
                defaults: new { controller = "Rental", action = "GetRentalByCustomer" }
            );

            routes.MapRoute(
                name: "AudioFileId",
                url: "Exhibit/GetAudioFilesByEXHIBIT/{exhibitId}",
                defaults: new { controller = "Exhibit", action = "GetAudioFilesByExhibit" }
            );

            routes.MapRoute(
                name: "GetCustomerId",
                url: "Customer/GetCustomerById/{customerId}",
                defaults: new { controller = "Customer", action = "GetCustomerById" }
            );

            routes.MapRoute(
                name: "AddNewRental",
                url: "NewRental",
                defaults: new { controller = "Rental", action = "NewRental" }
            );

            routes.MapRoute(
                name: "CreateNewUser",
                url: "NewUser",
                defaults: new { controller = "Account", action = "NewUser" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}