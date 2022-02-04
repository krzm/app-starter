using DotNetTool;
using Unity;

namespace AppStarter.ConsoleApp;

public class AppUtils 
    : CLIFramework.AppUtils
{
    public AppUtils(
        IUnityContainer container) 
        : base(container)
    {
    }

    public override void Register()
    {
        base.Register();
        Container
            .RegisterType<IProcessStarter, ProcessStarter>();
    }
}