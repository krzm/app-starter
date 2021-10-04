using AppsStarter.Lib.Commands.Base;
using AppStarter.Data.Model;
using AppStarter.Data.Repository;
using Console.Lib;

namespace AppsStarter.Lib.Commands.Insert
{
	public class AppInfoInsertCommand : AppStarterReaderCommand<AppInfo>
	{
		public AppInfoInsertCommand(
			IAppStarterUnitOfWork unitOfWork
			, IConsoleIO consoleIO
			, IReader<string> textReader) : base(unitOfWork, consoleIO, textReader)
		{
		}

		public override bool CanExecute(object parameter)
		{
			return true;
		}

		public override void Execute(object parameter)
		{
			AppStarterUnit.AppInfo.Insert(
				new AppInfo
				{
					Name = TextReader.Read(nameof(AppInfo.Name))
					, Description = TextReader.Read(nameof(AppInfo.Description))
					, Path = TextReader.Read(nameof(AppInfo.Path))
				});
			AppStarterUnit.Save();
		}
	}
}