using Console.Lib;
using Unity;

namespace AppStarter.ConsoleApp
{
    public class DependencyCollection : Console.Lib.DependencyCollection
	{
		public DependencyCollection(
			IUnityContainer container) 
			: base(container)
		{
		}

        public override void RegisterDependencies()
        {
			RegisterDependencyProvider<AppDatabase>();
			base.RegisterDependencies();
        }

		protected override void RegisterAppData() => 
			RegisterDependencyProvider<AppData>();

		protected override void RegisterDataMappings() => 
			RegisterDependencyProvider<AppMappings>();

		protected override void RegisterConsoleOutput() => 
            RegisterDependencyProvider<AppOutput>();

		protected override void RegisterUtils() => 
			RegisterDependencyProvider<AppUtils>();

		protected override void RegisterCommands() => 
            RegisterDependencyProvider<AppCommands>();

		 protected override void RegisterCommandSystem() => 
			RegisterDependencyProvider<CommandSystem<ParamCommandParser>>();
    }
}