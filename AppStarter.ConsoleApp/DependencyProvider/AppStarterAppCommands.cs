using System.Windows.Input;
using Console.Lib;
using Unity;
using Unity.Injection;

namespace AppStarter.ConsoleApp
{
    public class AppStarterAppCommands
        : AppCommands
    {
        public AppStarterAppCommands(
            IUnityContainer container) 
            : base(container)
        {
        }

		protected override void RegisterHelpCommand()
        {
			Container
                .RegisterType<ICommand, AppStarter.Lib.HelpCommand>(
					Commands.Command("Help")
					, new InjectionConstructor(
						Container.Resolve<IConsoleIO>()
						, Container.Resolve<IOneWordNames>("AppCommands")
						, Container.Resolve<IOneWordNames>("Actions")
						, Container.Resolve<IOneWordNames>("Models")));
        }
    }
}