using Console.Lib;
using Core;
using Core.Lib.Utility;
using Unity;

namespace AppStarter.ConsoleApp
{
    public class AppStarterUtils
        : Utils
    {
        public AppStarterUtils(
            IUnityContainer container) 
            : base(container)
        {
        }

        public override void RegisterDependencies()
        {
            base.RegisterDependencies();
            Container
                .RegisterType<IProcessStarter, ProcessStarter>();
        }
    }
}