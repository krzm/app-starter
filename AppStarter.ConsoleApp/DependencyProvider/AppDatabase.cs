using AppStarter.Data;
using DIHelper.Unity;
using EFCore.Helper;
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
        Container
            .RegisterSingleton<AppStarterDbContext>()

            .RegisterSingleton<IRepository<Data.AppInfo>, EFRepository<Data.AppInfo, AppStarterDbContext>>()

            .RegisterSingleton<IAppStarterUnitOfWork, AppStarterUnitOfWork>();
    }
}