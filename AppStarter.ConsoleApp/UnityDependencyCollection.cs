using CLIFramework;
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

    public override void Register()
    {
		RegisterSet<AppDatabase>();
		base.Register();
    }

	protected override void RegisterAppData() => 
		RegisterSet<AppData>();

	protected override void RegisterDataMappings() => 
		RegisterSet<AppMappings>();

	protected override void RegisterConsoleOutput() => 
        RegisterSet<AppOutput>();

	protected override void RegisterUtils() => 
		RegisterSet<AppUtils>();

	protected override void RegisterCommands() => 
        RegisterSet<AppCommands>();

	protected override void RegisterCommandSystem() => 
		RegisterSet<AppCommandSystem<ParamCommandParser>>();
}