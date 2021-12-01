using AppStarter.Data.Repository;
using AutoMapper;
using Console.Lib;
using Core;
using System;
using System.Linq;

namespace AppStarter.Lib
{
	public class AppStartCommand : ConsoleCommand
	{
		private readonly IOutput output;
		private readonly IProcessStarter processStarter;
		private readonly IAppStarterUnitOfWork appStarterUnit;
		private readonly IMapper mapper;

		private string appName;
		private string[] appParams;
		private Model.AppInfoModel appInfo;

		public AppStartCommand(
			TextCommand textCommand
			, IOutput output
			, IProcessStarter processStarter
			, IAppStarterUnitOfWork appStarterUnit
			, IMapper mapper)
			: base(textCommand)
		{
			ArgumentNullException.ThrowIfNull(output);
			ArgumentNullException.ThrowIfNull(processStarter);
			ArgumentNullException.ThrowIfNull(appStarterUnit);
			ArgumentNullException.ThrowIfNull(mapper);

			this.output = output;
			this.processStarter = processStarter;
			this.appStarterUnit = appStarterUnit;
			this.mapper = mapper;
		}

		public override bool CanExecute(object parameter)
		{
			if (parameter is not TextCommand textCommand)
				throw new Exception("No text command was passed.");
			if(textCommand.Params.Length == 0)
				throw new Exception("No arguments passed.");
			appName = textCommand.Params[0];
			if(textCommand.Params.Length > 1)
			{
				appParams = textCommand.Params.Skip(1).ToArray();
			}
			var appData = appStarterUnit.AppInfo.Get(x => x.Name == appName).FirstOrDefault();
			if (appData == null)
			{
				output.WriteLine("No app info in db.");
			}
			else
			{
				appInfo = mapper.Map<Model.AppInfoModel>(appData);
			}
			return true;
		}

		public override void Execute(object parameter)
		{
			if(appInfo != null)
			{
				output.WriteLine($"Start process : {appInfo.Name} in path {appInfo.Path}");
				if (appParams?.Length > 0)
				{
					foreach (var param in appParams)
					{
						output.WriteLine($"with argument : {param}");
					}
					try
					{
						processStarter.StartProcess(appInfo.Path, appParams);
					}
					catch (Exception ex)
					{
						output.WriteLine(ex.Message);
					}
				}
				else
				{
					try
					{
						processStarter.StartProcess(appInfo.Path);
					}
					catch (Exception ex)
					{
						output.WriteLine(ex.Message);
					}
				}
			}
			else
			{
				try
				{
					processStarter.StartProcess(appName);
				}
				catch (Exception ex)
				{
					output.WriteLine(ex.Message);
				}
			}
		}
	}
}