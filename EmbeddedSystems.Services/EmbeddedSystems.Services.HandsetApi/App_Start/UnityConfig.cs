namespace EmbeddedSystems.Services.HandsetApi
{
    using System.Data.Entity;

    using EmbeddedSystems.Persistence;
    using EmbeddedSystems.ServiceLayer;

    using Microsoft.Practices.Unity;
    using System.Web.Http;
    using Unity.WebApi;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<DbContext, Context>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IAudioFileService, AudioFileService>();
            container.RegisterType<IExhibitService, ExhibitService>();
            container.RegisterType<ICustomerService, CustomerService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}