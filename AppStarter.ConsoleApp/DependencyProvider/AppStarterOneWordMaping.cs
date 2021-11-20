using Console.Lib;
using Unity;

namespace AppStarter.ConsoleApp
{
    public class AppStarterOneWordMaping
        : OneWordMaping
    {
        public AppStarterOneWordMaping(
            IUnityContainer container) 
            : base(container)
        {
        }
    }
}