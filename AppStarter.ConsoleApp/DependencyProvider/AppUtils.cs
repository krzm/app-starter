using Core;
using Core.Lib.Utility;
using Unity;

namespace AppStarter.ConsoleApp;

public class AppUtils : Console.Lib.AppUtils
{
    public AppUtils(
        IUnityContainer container) 
        : base(container)
    {
    }

    public override void RegisterDependencies()
    {
        base.RegisterDependencies();
        Container
            .RegisterType<IProcessStarter, ProcessStarter>();
    }
}