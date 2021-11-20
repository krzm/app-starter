using Console.Lib;
using Unity;

namespace AppStarter.ConsoleApp
{
    public class AppStarterConfig 
		: DependencyCollection
	{
		public AppStarterConfig(
			IUnityContainer container) 
			: base(container)
		{
		}

        public override void RegisterDependencies()
        {
			RegisterDependencyProvider<AppStarterDatabase>();
			base.RegisterDependencies();
        }

		protected override void RegisterAppData() => 
			RegisterDependencyProvider<AppStarterData>();

		protected override void RegisterDataMappings() => 
			RegisterDependencyProvider<AppStarterDataMappings>();

		protected override void RegisterConsoleOutput() => 
            RegisterDependencyProvider<AppStarterConsoleOutput>();

		protected override void RegisterUtils() => 
			RegisterDependencyProvider<AppStarterUtils>();

        protected override void RegisterOneWordMaping() =>
            RegisterDependencyProvider<AppStarterOneWordMaping>();

		protected override void RegisterTwoWordMaping() =>
            RegisterDependencyProvider<AppStarterTwoWordMaping>();

        protected override void RegisterCommandNameSystem() => 
            RegisterDependencyProvider<AppStarterCommandNameMaping>();

		protected override void RegisterCommands()
        {
			RegisterDependencyProvider<AppStarterAppCommands>();
			RegisterDependencyProvider<AppStarterCommands>();
        }
    }
}