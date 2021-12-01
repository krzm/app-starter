using AppStarter.Data.Model;
using Console.Lib;
using Unity;

namespace AppStarter.ConsoleApp
{
    public class AppOutput : Console.Lib.AppOutput
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
                .RegisterType<ITextProvider<AppInfo>, ModelATableProvider<AppInfo>>();
        }
    }
}