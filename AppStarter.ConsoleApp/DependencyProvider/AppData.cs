using Console.Lib;
using Unity;

namespace AppStarter.ConsoleApp;

public class AppData : Console.Lib.AppData
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