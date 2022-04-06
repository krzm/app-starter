using CLIFramework;
using CLIHelper.Unity;
using CLIReader;
using Config.Wrapper.Unity;
using Serilog.Wrapper.Unity;
using Unity;

namespace AppStarter.ConsoleApp;

public class UnityDependencySuite 
	: CLIFramework.UnityDependencySuite
{
	public UnityDependencySuite(
		IUnityContainer container) 
		: base(container)
	{
	}

	protected override void RegisterAppData()
	{
		RegisterSet<AppLoggerSet>();
        RegisterSet<AppConfigSet>();
		RegisterSet<AppData>();
	}

	protected override void RegisterDatabase() => 
        RegisterSet<AppDatabase>();

	protected override void RegisterDataMappings() => 
		RegisterSet<AppMappings>();

	protected override void RegisterConsoleInput()
    {
        RegisterSet<CliIOSet>();
        RegisterSet<CLIReaderSet>();
    }

	protected override void RegisterConsoleOutput() => 
        RegisterSet<AppOutput>();

	protected override void RegisterUtils() => 
		RegisterSet<AppUtils>();

	protected override void RegisterCommands() => 
        RegisterSet<AppCommands>();

	protected override void RegisterCommandSystem() => 
		RegisterSet<AppCommandSystem<ParamCommandParser>>();
}