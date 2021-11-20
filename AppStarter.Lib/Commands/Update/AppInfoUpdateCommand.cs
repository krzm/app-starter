using AppStarter.Data.Model;
using AppStarter.Data.Repository;
using Console.Lib;
using System.Collections.Generic;

namespace AppStarter.Lib
{
	public class AppInfoUpdateCommand : DataCommand<AppInfo>
	{
		private readonly IAppStarterUnitOfWork unitOfWork;
		private readonly IReader<string> requiredTextReader;

		public AppInfoUpdateCommand(
			IAppStarterUnitOfWork unitOfWork, 
			List<IReader<string>> textReader)
		{
			this.unitOfWork = unitOfWork;
			requiredTextReader = textReader[0];
		}

		public override void Execute(object parameter)
		{
			var id = int.Parse(requiredTextReader.Read(new ReadConfig(6, $"Select {TypeName} Id.")));
			var model = unitOfWork.AppInfo.GetByID(id);

			var name = nameof(AppInfo.Name);
			var description = nameof(AppInfo.Description);
			var path = nameof(AppInfo.Path);

			var nr = int.Parse(
				requiredTextReader.Read(
					new ReadConfig(6
					, $"Select property number. 1-{name}, 2-{description}, 3-{path}")));

			if (nr == 1)
				model.Name = requiredTextReader.Read(new ReadConfig(50, name));
			if (nr == 2)
				model.Description = requiredTextReader.Read(new ReadConfig(250, description));
			if (nr == 3)
				model.Path = requiredTextReader.Read(new ReadConfig(250, path));

			unitOfWork.Save();
		}
	}
}