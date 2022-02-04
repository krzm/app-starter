using AppStarter.Data;
using DIHelper.Unity;
using EFCoreHelper;
using Unity;

namespace AppStarter.ConsoleApp;

public class AppDatabase 
    : UnityDependencySet
{
    public AppDatabase(
        IUnityContainer container) 
        : base(container)
    {
    }

    public override void Register()
    {
        var unitOfWork = Container.Resolve<AppStarterUnitOfWork>();
        Container.RegisterInstance<IUnitOfWork>(unitOfWork, InstanceLifetime.Singleton);
		Container.RegisterInstance<IAppStarterUnitOfWork>(unitOfWork, InstanceLifetime.Singleton);
    }
}