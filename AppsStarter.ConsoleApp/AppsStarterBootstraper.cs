using Console.Lib;
using Core;
using Unity;

namespace AppsStarter.ConsoleApp
{
	public class AppsStarterBootstraper : ConsoleBootstraper
	{
		protected override void RegisterDependencyProviders()
		{
			Container.RegisterSingleton<IDependencyProvider<IUnityContainer>, AppsStarterDependencyProvider>();
		}
	}
}