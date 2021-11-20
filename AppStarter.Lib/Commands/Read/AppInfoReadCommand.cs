using AppStarter.Data.Model;
using AppStarter.Data.Repository;
using Console.Lib;
using System.Linq;

namespace AppStarter.Lib
{
	public class AppInfoReadCommand : DataCommand<AppInfo>
	{
		private readonly IAppStarterUnitOfWork unitOfWork;
		private readonly IConsoleIO consoleIO;
		private readonly ITextProvider<AppInfo> textProvider;

		public AppInfoReadCommand(
			IAppStarterUnitOfWork unitOfWork
			, IConsoleIO consoleIO
			, ITextProvider<AppInfo> textProvider)
		{
			this.unitOfWork = unitOfWork;
			this.consoleIO = consoleIO;
			this.textProvider = textProvider;
		}

		public override void Execute(object parameter)
		{
			consoleIO.WriteLine(
				textProvider.GetText(
					unitOfWork.AppInfo.Get(
						orderBy: a => a.OrderBy(p => p.Name)).ToList()));
		}
	}
}