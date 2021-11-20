using Console.Lib;
using Core.Lib;
using Unity;

namespace AppStarter.ConsoleApp
{
    public class AppStarterBootstraper : ConsoleBootstraper
	{
		protected override void RegisterDependencyCollection()
		{
			Container.RegisterSingleton<IUnityDependencyCollection, AppStarterConfig>("DefaultConfig");
		}
	}
}