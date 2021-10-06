using Console.Lib;
using Core;
using Unity;

namespace AppStarter.ConsoleApp
{
	public class AppStarterBootstraper : ConsoleBootstraper
	{
		protected override void RegisterDependencyProviders()
		{
			Container.RegisterSingleton<IDependencyProvider<IUnityContainer>, AppStarterDependencyProvider>();
		}
	}
}