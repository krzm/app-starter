using AppStarter.Lib;
using CLIFramework;
using Unity;

namespace AppStarter.ConsoleApp;

public class AppCommandSystem<TParser> 
    : CLIFramework.AppCommandSystem<TParser>
    where TParser : ICommandParser
{
    public AppCommandSystem(
        IUnityContainer container) 
        : base(container)
    {
    }

    protected override void SetCommandDependencies()
    {
        var commandRunner = Container.Resolve<ICommandRunner>();

        (Container.Resolve<IAppCommand>("insert appinfo") as AppInfoInsertCommand).SetCommandRunner(commandRunner);
        (Container.Resolve<IAppCommand>("update appinfo") as AppInfoUpdateCommand).SetCommandRunner(commandRunner);
    }
}