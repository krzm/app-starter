using AppStarter.Data.Model;
using AppStarter.Data.Repository;
using AppStarter.Lib;
using AppStarter.Lib.Commands.Insert;
using AppStarter.Lib.Model;
using AutoMapper;
using Console.Lib;
using Core;
using Core.Lib.Utility;
using System.Windows.Input;
using Unity;
using Unity.Injection;

namespace AppStarter.ConsoleApp
{
	public class AppStarterDependencyProvider : ConsoleAppDependencyProvider
	{
		public override string AppName => "AppsStarter";

		public AppStarterDependencyProvider(IUnityContainer container) : base(container)
		{
		}

		protected override void RegisterUnitOfWork()
		{
			Container.RegisterType<IAppStarterUnitOfWork, AppStarterUnitOfWork>();
		}

		protected override void RegisterUtilities()
		{
			base.RegisterUtilities();
			Container.RegisterType<IProcessStarter, ProcessStarter>();

			var config = new MapperConfiguration(cfg => {
				cfg.CreateMap<AppInfo, AppInfoModel>();
			});
			Container.RegisterInstance(config.CreateMapper());
		}

		protected override void RegisterCommandsParser()
		{
			base.RegisterCommandsParser();
			Container.RegisterType<ICommandParser, CommandWithParamsParser>(nameof(CommandWithParamsParser)
				, new InjectionConstructor(new object[] {
					Container.Resolve<ITextCommands>()
					, Container.Resolve<ICommandParser>(nameof(CommandParser))
					}));
		}

		protected override void RegisterProgram()
		{
			RegisterProgram<ConsoleAppProgram>(nameof(CommandWithParamsParser));
		}

		protected override void RegisterCommandNameFactories()
		{
			Container
				.RegisterType<IFactory<string[]>, OneWordNameFactory>(
					"one word"
					, new InjectionConstructor(new object[] {
						new string[]
						{
							"help".ToLowerInvariant()
							, "exit".ToLowerInvariant()
							, "start".ToLowerInvariant()
						}}));
			Container
				.RegisterType<IFactory<string[]>, DataCommandNameFactory>(
					"two word"
					, new InjectionConstructor(new object[] {
						new string[]
						{
							//""
							//,
							"insert"
						}
						, new string[]
						{
							nameof(AppInfo).ToLowerInvariant()
						}}));
		}

		protected override void RegisterCommands()
		{
			base.RegisterCommands();
			Container
				.RegisterType<ICommand, AppStartCommand>("start");

			Container
				.RegisterType<ICommand, AppInfoInsertCommand>(Commands.Insert(nameof(AppInfo)));
		}
	}
}