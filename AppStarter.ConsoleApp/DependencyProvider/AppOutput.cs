using AppStarter.Data;
using DataToTable;
using DataToTable.Unity;
using Unity;

namespace AppStarter.ConsoleApp;

public class AppOutput 
    : DataToTableSet
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
            .RegisterType<ITableTextEditor, TableTextEditor>()
            .RegisterType<IDataToText<AppInfo>, ModelATable<AppInfo>>();
    }
}