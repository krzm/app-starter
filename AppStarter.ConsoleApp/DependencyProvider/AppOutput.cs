using AppStarter.Data.Model;
using DataToTable;
using Unity;

namespace AppStarter.ConsoleApp;

public class AppOutput : CLI.Core.Lib.AppOutput
{
    public AppOutput(
        IUnityContainer container) 
        : base(container)
    {
    }

    protected override void RegisterColumnCalculators()
    {
        Container
            .RegisterType<IColumnCalculator<AppInfo>, ColumnCalculator<AppInfo>>();
    }

    protected override void RegisterTableProviders()
    {
        Container
            .RegisterType<IDataToText<AppInfo>, ModelATable<AppInfo>>();
    }
}