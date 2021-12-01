using AppStarter.Data.Model;
using AppStarter.Data.Repository;
using Console.Lib;
using System;
using System.Linq;

namespace AppStarter.Lib
{
	public class AppInfoReadCommand : DataCommand<AppInfo>
	{
		private readonly IAppStarterUnitOfWork unitOfWork;
		private readonly IOutput output;
		private readonly ITextProvider<AppInfo> textProvider;

		public AppInfoReadCommand(
			TextCommand command
			, IAppStarterUnitOfWork unitOfWork
			, IOutput output
			, ITextProvider<AppInfo> textProvider)
			: base(command)
		{
			ArgumentNullException.ThrowIfNull(unitOfWork);
			ArgumentNullException.ThrowIfNull(output);
			ArgumentNullException.ThrowIfNull(textProvider);

			this.unitOfWork = unitOfWork;
			this.output = output;
			this.textProvider = textProvider;
		}

		public override void Execute(object parameter)
		{
			output.Clear();
			output.WriteLine($"Read {TextCommand.TypeName}:");
			output.WriteLine(
				textProvider.GetText(
					unitOfWork.AppInfo.Get(
						orderBy: a => a.OrderBy(p => p.Name)).ToList()));
		}
	}
}