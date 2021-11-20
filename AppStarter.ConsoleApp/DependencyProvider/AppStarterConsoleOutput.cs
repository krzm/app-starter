using AppStarter.Data.Model;
using AppStarter.Lib;
using Console.Lib;
using Unity;

namespace AppStarter.ConsoleApp
{
    public class AppStarterConsoleOutput
        : ConsoleOutput
    {
        public AppStarterConsoleOutput(
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
                .RegisterType<ITextProvider<AppInfo>, AppInfoTableProvider>();
        }
    }
}