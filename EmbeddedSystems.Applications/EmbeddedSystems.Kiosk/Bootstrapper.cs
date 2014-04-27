using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using EmbeddedSystems.ServiceLayer;
using EmbeddedSystems.Persistence;
using System.Data.Entity;

namespace EmbeddedSystems.Kiosk
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
        /*container.RegisterType<IHandsetService, HandsetService>();
        container.RegisterType<ILanguageService, LanguageService>();
        container.RegisterType<IKnowledgeLevelService, KnowledgeLevelService>();
        container.RegisterType<ICustomerService, CustomerService>();*/

        container.RegisterType<DbContext, Context>(new HierarchicalLifetimeManager());
        container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
        container.RegisterType<IAudioFileService, AudioFileService>();
        container.RegisterType<IExhibitService, ExhibitService>();
        container.RegisterType<ICustomerService, CustomerService>();
        container.RegisterType<IHandsetService, HandsetService>();
        container.RegisterType<IKnowledgeLevelService, KnowledgeLevelService>();
        container.RegisterType<ILanguageService, LanguageService>();
    }
  }
}