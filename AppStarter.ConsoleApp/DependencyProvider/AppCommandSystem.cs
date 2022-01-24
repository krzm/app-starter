using AppStarter.Lib;
using Console.Lib;
using Unity;

namespace AppStarter.ConsoleApp;

public class AppCommandSystem<TParser> : Console.Lib.AppCommandSystem<TParser>
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