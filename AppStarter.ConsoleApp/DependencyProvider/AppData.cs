using CLIFramework;
using Unity;

namespace AppStarter.ConsoleApp;

public class AppData 
    : CLIFramework.AppData
{
    public AppData(
        IUnityContainer container) 
        : base(container)
    {
    }

    protected override void SetAppConfigData()
    {
        Config["AppName"] = "AppStarter";
        Config["CommandParser"] = nameof(ParamCommandParser);
    }
}