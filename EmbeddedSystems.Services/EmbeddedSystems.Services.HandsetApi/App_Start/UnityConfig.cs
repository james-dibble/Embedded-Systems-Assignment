namespace EmbeddedSystems.Services.HandsetApi
{
    using System.Data.Entity;
    using System.Web.Http;

    using EmbeddedSystems.Persistence;
    using EmbeddedSystems.Security;
    using EmbeddedSystems.ServiceLayer;

    using Microsoft.Practices.Unity;

    using Unity.WebApi;

    public static class UnityConfig
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            
            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<DbContext, Context>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IAudioFileService, AudioFileService>();
            container.RegisterType<IExhibitService, ExhibitService>();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<IHandsetService, HandsetService>();
            container.RegisterType<IAuthorizationService, AuthorizationService>();
        }
    }
}