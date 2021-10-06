using AppStarter.Data.Model;
using AppStarter.Data.Repository;
using AppStarter.Lib.Commands.Base;
using Console.Lib;

namespace AppStarter.Lib.Commands.Read
{
	public class AppInfoReadCommand : AppStarterIOCommand
	{
		public AppInfoReadCommand(
			IAppStarterUnitOfWork unitOfWork
			, IConsoleIO consoleIO) : base(unitOfWork, consoleIO)
		{
		}

		public override bool CanExecute(object parameter)
		{
			return true;
		}

		public override void Execute(object parameter)
		{
			foreach (var item in AppInfoUnitOfWork.AppInfo.Get())
			{
				ConsoleIO.WriteLine($"{nameof(AppInfo.Id)} : {item.Id}");
				ConsoleIO.WriteLine($"{nameof(AppInfo.Name)} : {item.Name}");
				ConsoleIO.WriteLine($"{nameof(AppInfo.Description)} : {item.Description}");
				ConsoleIO.WriteLine($"{nameof(AppInfo.Path)} : {item.Path}");
			}
		}
	}
}