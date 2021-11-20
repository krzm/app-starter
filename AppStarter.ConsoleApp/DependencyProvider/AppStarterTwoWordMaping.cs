using AppStarter.Data.Model;
using Console.Lib;
using Unity;
using Unity.Injection;

namespace AppStarter.ConsoleApp
{
    public class AppStarterTwoWordMaping
        : TwoWordMaping
    {
        public AppStarterTwoWordMaping(
            IUnityContainer container) 
            : base(container)
        {
        }

        protected override void RegisterTwoWordNames()
        {
            Container.RegisterSingleton<IOneWordNames, OneWordNameFactory>("Actions"
				, new InjectionConstructor(
					new object[] {
                        new string[]
                        {
                            "Help".ToLowerInvariant()
                            ,"Insert".ToLowerInvariant()
                            ,"Update".ToLowerInvariant()
                        }}));

			Container.RegisterSingleton<IOneWordNames, OneWordNameFactory>("Models"
				, new InjectionConstructor(
					new object[] {
						new string[]
						{
							nameof(AppInfo).ToLowerInvariant()
						}}));

			Container.RegisterType<ITwoWordNames, TwoWordNameFactory>(
				new InjectionConstructor(
					Container.Resolve<IOneWordNames>("Actions")
					, Container.Resolve<IOneWordNames>("Models")));
        }
    }
}