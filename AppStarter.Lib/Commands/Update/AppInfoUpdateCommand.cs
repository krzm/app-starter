using AppStarter.Data.Model;
using AppStarter.Data.Repository;
using AppStarter.Lib.Commands.Base;
using Console.Lib;

namespace AppStarter.Lib.Commands.Update
{
	public class AppInfoUpdateCommand : AppStarterReaderCommand<AppInfo>
	{
		public AppInfoUpdateCommand(
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
			var name = nameof(AppInfo.Name);
			var description = nameof(AppInfo.Description);
			var path = nameof(AppInfo.Path);

			ConsoleIO.WriteLine($"Select {TypeName} Id.");
			var id = int.Parse(ConsoleIO.ReadLine());
			var appInfo = AppStarterUnit.AppInfo.GetByID(id);

			ConsoleIO.WriteLine($"Select property number. 1-{name}, 2-{description}");
			var nr = int.Parse(ConsoleIO.ReadLine());
			if (nr == 1)
				appInfo.Name = TextReader.Read(name);
			if (nr == 2)
				appInfo.Description = TextReader.Read(description);
			if (nr == 3)
				appInfo.Path = TextReader.Read(path);

			UnitOfWork.Save();
			ConsoleIO.WriteLine($"{TypeName} updated.");
		}
	}
}