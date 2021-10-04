using Console.Lib;

namespace AppsStarter.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			IConsoleBootstraper booter = new AppsStarterBootstraper();
			booter.Boot(args);
		}
	}
}