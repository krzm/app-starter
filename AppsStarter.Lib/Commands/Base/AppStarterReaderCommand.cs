using AppStarter.Data.Repository;
using Console.Lib;

namespace AppsStarter.Lib.Commands.Base
{
	public abstract class AppStarterReaderCommand<TEntity> : DataReaderCommand<TEntity>
	{
		protected readonly IAppStarterUnitOfWork AppStarterUnit;

		protected AppStarterReaderCommand(
			IAppStarterUnitOfWork unitOfWork
			, IConsoleIO consoleIO
			, IReader<string> textReader) : base(unitOfWork, consoleIO, textReader)
		{
			AppStarterUnit = unitOfWork;
		}
	}
}