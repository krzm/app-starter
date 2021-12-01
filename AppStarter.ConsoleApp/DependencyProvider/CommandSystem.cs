using AppStarter.Lib;
using Console.Lib;
using Unity;

namespace AppStarter.ConsoleApp
{
    public class CommandSystem<TParser> : Console.Lib.CommandSystem<TParser>
        where TParser : ICommandParser
    {
        public CommandSystem(
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
}