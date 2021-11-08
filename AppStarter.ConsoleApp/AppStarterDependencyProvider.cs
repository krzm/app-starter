using AppStarter.Data.Model;
using AppStarter.Data.Repository;
using AppStarter.Lib;
using AppStarter.Lib.Commands;
using AppStarter.Lib.Commands.Insert;
using AppStarter.Lib.Commands.Update;
using AppStarter.Lib.Model;
using AutoMapper;
using Console.Lib;
using Core;
using Core.Lib.Utility;
using System.Collections.Generic;
using System.Windows.Input;
using Unity;
using Unity.Injection;

namespace AppStarter.ConsoleApp
{
	public class AppStarterDependencyProvider : ConsoleAppDependencyProvider
	{
		public override string AppName => "AppsStarter";

		public AppStarterDependencyProvider(
			IUnityContainer container) : 
				base(container)
		{
		}

		protected override void RegisterUtilities()
		{
			base.RegisterUtilities();
			Container
				.RegisterType<IColumnCalculator<AppInfo>, ColumnCalculator<AppInfo>>()
				.RegisterType<ITextProvider<AppInfo>, AppInfoTableProvider>()

				.RegisterType<IProcessStarter, ProcessStarter>();

			var config = new MapperConfiguration(
				cfg => 
				{
					cfg.CreateMap<AppInfo, AppInfoModel>();
				});
			Container.RegisterInstance(config.CreateMapper());
		}

		protected override void RegisterUnitOfWork()
		{
			var unitOfWork = Container.Resolve<AppStarterUnitOfWork>();
			Container.RegisterInstance<IUnitOfWork>(unitOfWork, InstanceLifetime.Singleton);
			Container.RegisterInstance<IAppStarterUnitOfWork>(unitOfWork, InstanceLifetime.Singleton);
		}

		protected override void RegisterCommandNameFactories()
		{
			base.RegisterCommandNameFactories();
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

		protected override List<string> RegisterOneWordCommandNames()
		{
			var list = base.RegisterOneWordCommandNames();
			list.Add("start".ToLowerInvariant());
			return list;
		}

		protected override void AddCommandNames()
		{
			base.AddCommandNames();
			AddNames(Container.Resolve<IOneWordNames>("Models").GetInstance());
			AddNames(Container.Resolve<ITwoWordNames>().GetInstance());
		}

		protected override void RegisterCommands()
		{
			base.RegisterCommands();

			Container
				.RegisterType<ICommand, Lib.Commands.HelpCommand>(
					Commands.Command("Help")
					, new InjectionConstructor(
						Container.Resolve<IConsoleIO>()
						, Container.Resolve<IOneWordNames>("AppCommands")
						, Container.Resolve<IOneWordNames>("Actions")
						, Container.Resolve<IOneWordNames>("Models")));

			Container
				.RegisterType<ICommand, AppStartCommand>("start");

			Container
				.RegisterType<ICommand, AppInfoInsertCommand>(Commands.Insert(nameof(AppInfo)))
				.RegisterType<ICommand, AppInfoReadCommand>(Commands.Read(nameof(AppInfo)))
				.RegisterType<ICommand, AppInfoUpdateCommand>(Commands.Update(nameof(AppInfo)));
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
	}
}