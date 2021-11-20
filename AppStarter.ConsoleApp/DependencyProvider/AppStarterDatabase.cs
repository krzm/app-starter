using AppStarter.Data.Repository;
using Core;
using Core.Lib;
using Unity;

namespace AppStarter.ConsoleApp
{
    public class AppStarterDatabase
        : UnityDependencyProvider
    {
        public AppStarterDatabase(
            IUnityContainer container) 
            : base(container)
        {
        }

        public override void RegisterDependencies()
        {
            var unitOfWork = Container.Resolve<AppStarterUnitOfWork>();
            Container.RegisterInstance<IUnitOfWork>(unitOfWork, InstanceLifetime.Singleton);
			Container.RegisterInstance<IAppStarterUnitOfWork>(unitOfWork, InstanceLifetime.Singleton);
        }
    }
}