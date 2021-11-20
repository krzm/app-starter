using Console.Lib;
using Unity;

namespace AppStarter.ConsoleApp
{
    public class AppStarterData 
        : AppData
    {
        public AppStarterData(
            IUnityContainer container) 
            : base(container)
        {
        }

        public override void RegisterDependencies()
        {
            base.RegisterDependencies();

            Container.RegisterSingleton<IOneWordNames, OneWordCommandNames>("OneWordCommands");
        }

        protected override void SetAppConfigData()
        {
            Config["AppName"] = "AppStarter";
            Config["OneWordCommands"] = "OneWordCommands";
            Config["CommandParser"] = nameof(ParamCommandParser);
        }
    }
}