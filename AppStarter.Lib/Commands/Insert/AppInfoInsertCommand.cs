using AppStarter.Data.Model;
using AppStarter.Data.Repository;
using AppStarter.Lib.Commands.Base;
using Console.Lib;

namespace AppStarter.Lib.Commands.Insert
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