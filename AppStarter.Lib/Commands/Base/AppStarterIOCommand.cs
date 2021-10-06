using AppStarter.Data.Repository;
using Console.Lib;

namespace AppStarter.Lib.Commands.Base
{
	public abstract class AppStarterIOCommand : DataIOCommand
	{
		protected readonly IAppStarterUnitOfWork AppInfoUnitOfWork;

		protected AppStarterIOCommand(
			IAppStarterUnitOfWork unitOfWork
			, IConsoleIO consoleIO) : base(unitOfWork, consoleIO)
		{
			AppInfoUnitOfWork = unitOfWork;
		}
	}
}