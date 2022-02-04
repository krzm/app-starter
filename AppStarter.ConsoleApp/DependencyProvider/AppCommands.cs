using System.Collections.Generic;
using AppStarter.Data;
using AppStarter.Lib;
using AutoMapper;
using CLIFramework;
using CLIHelper;
using CLIReader;
using DataToTable;
using DotNetTool;
using Unity;

namespace AppStarter.ConsoleApp;

public class AppCommands 
    : CLIFramework.AppCommands
{
    public AppCommands(
        IUnityContainer container) 
        : base(container)
    {
    }

    protected override void RegisterCommands()
    {
        base.RegisterCommands();
        RegisterAppInfoCommands();
    }

    private void RegisterAppInfoCommands()
    {
        RegisterCommand<HelpCommand<AppInfo>, AppInfo>(
			"Help AppInfo".ToLowerInvariant()
			, Container.Resolve<IOutput>()
			, new string[]
			{
				nameof(AppInfo.Name)
				, nameof(AppInfo.Description)
				, nameof(AppInfo.Path)
			});

        RegisterCommand<AppInfoReadCommand, AppInfo>(
            "AppInfo".ToLowerInvariant()
            , Container.Resolve<IAppStarterUnitOfWork>()
            , Container.Resolve<IOutput>()
            , Container.Resolve<IDataToText<AppInfo>>());

        RegisterCommand<AppInfoInsertCommand, AppInfo>(
            "Insert AppInfo".ToLowerInvariant()
            , Container.Resolve<IAppStarterUnitOfWork>()
            , Container.Resolve<List<IReader<string>>>());

        RegisterCommand<AppInfoUpdateCommand, AppInfo>(
            "Update AppInfo".ToLowerInvariant()
            , Container.Resolve<IAppStarterUnitOfWork>()
            , Container.Resolve<List<IReader<string>>>());
            
        RegisterCommand<AppStartCommand>(
            "Start".ToLowerInvariant()
            , Container.Resolve<IOutput>()
            , Container.Resolve<IProcessStarter>()
            , Container.Resolve<IAppStarterUnitOfWork>()
            , Container.Resolve<IMapper>());
    }
}