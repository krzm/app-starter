using System.Windows.Input;
using AppStarter.Data.Model;
using AppStarter.Lib;
using Console.Lib;
using Core.Lib;
using Unity;

namespace AppStarter.ConsoleApp
{
    public class AppStarterCommands
		: UnityDependencyProvider
    {
        public AppStarterCommands(
            IUnityContainer container) 
            : base(container)
        {
        }

        public override void RegisterDependencies()
		{
            Container
				.RegisterType<ICommand, AppStartCommand>("start");

			Container
				.RegisterType<ICommand, AppInfoInsertCommand>(Commands.Insert(nameof(AppInfo)))
				.RegisterType<ICommand, AppInfoReadCommand>(Commands.Read(nameof(AppInfo)))
				.RegisterType<ICommand, AppInfoUpdateCommand>(Commands.Update(nameof(AppInfo)));
		}
    }
}