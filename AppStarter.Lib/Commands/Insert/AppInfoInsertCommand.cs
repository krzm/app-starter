using AppStarter.Data.Model;
using AppStarter.Data.Repository;
using Console.Lib;
using System.Collections.Generic;

namespace AppStarter.Lib.Commands.Insert
{
	public class AppInfoInsertCommand : DataCommand<AppInfo>
	{
		private readonly IAppStarterUnitOfWork unitOfWork;
		private readonly IReader<string> requiredTextReader;

		public AppInfoInsertCommand(
			IAppStarterUnitOfWork unitOfWork
			, List<IReader<string>> textReaders)
		{
			this.unitOfWork = unitOfWork;
			requiredTextReader = textReaders[0];
		}

		public override void Execute(object parameter)
		{
			unitOfWork.AppInfo.Insert(
				new AppInfo
				{
					Name = requiredTextReader.Read(new ReadConfig(50, nameof(AppInfo.Name)))
					, Description = requiredTextReader.Read(new ReadConfig(250, nameof(AppInfo.Description)))
					, Path = requiredTextReader.Read(new ReadConfig(250, nameof(AppInfo.Path)))
				});
			unitOfWork.Save();
		}
	}
}