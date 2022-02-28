using AppStarter.Data;
using DataToTable;
using Unity;

namespace AppStarter.ConsoleApp;

public class AppOutput 
    : DIHelper.Unity.AppOutput
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
        Container.RegisterType<ITableTextEditor, TableTextEditor>();

        Container
            .RegisterType<IDataToText<AppInfo>, ModelATable<AppInfo>>();
    }
}