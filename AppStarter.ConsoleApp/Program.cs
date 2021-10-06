using Console.Lib;

namespace AppStarter.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			IConsoleBootstraper booter = new AppStarterBootstraper();
			booter.Boot(args);
		}
	}
}