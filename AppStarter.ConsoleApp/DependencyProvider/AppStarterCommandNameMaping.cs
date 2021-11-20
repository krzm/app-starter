using Console.Lib;
using Unity;

namespace AppStarter.ConsoleApp
{
    public class AppStarterCommandNameMaping
        : CommandNameMaping
    {
        public AppStarterCommandNameMaping(
            IUnityContainer container) 
            : base(container)
        {
        }

		protected override void AddCommandNames()
		{
			base.AddCommandNames();
			AddNames(Container.Resolve<IOneWordNames>("Models").GetInstance());
			AddNames(Container.Resolve<ITwoWordNames>().GetInstance());
		}
    }
}