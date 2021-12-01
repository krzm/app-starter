using System.Collections.Generic;
using AppStarter.Data.Model;
using AppStarter.Data.Repository;
using AppStarter.Lib;
using Console.Lib;
using Unity;

namespace AppStarter.ConsoleApp
{
    public class AppCommands : Console.Lib.AppCommands
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
            RegisterCommand<EntityHelpCommand<AppInfo>, AppInfo>(
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
                , Container.Resolve<ITextProvider<AppInfo>>());

            RegisterCommand<AppInfoInsertCommand, AppInfo>(
                "Insert AppInfo".ToLowerInvariant()
                , Container.Resolve<IAppStarterUnitOfWork>()
                , Container.Resolve<List<IReader<string>>>());

            RegisterCommand<AppInfoUpdateCommand, AppInfo>(
                "Update AppInfo".ToLowerInvariant()
                , Container.Resolve<IAppStarterUnitOfWork>()
                , Container.Resolve<List<IReader<string>>>());
        }
    }
}