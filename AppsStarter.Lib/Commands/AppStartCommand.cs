using AppStarter.Data.Repository;
using AutoMapper;
using Console.Lib;
using Core;
using System;
using System.Linq;

namespace AppsStarter.Lib
{
	public class AppStartCommand : IOCommand
	{
		private readonly IProcessStarter processStarter;
		private readonly IAppStarterUnitOfWork appStarterUnit;
		private readonly IMapper mapper;

		private string appName;
		private string[] appParams;
		private Model.AppInfoModel appInfo;

		public AppStartCommand(
			IConsoleIO consoleIO
			, IProcessStarter processStarter
			, IAppStarterUnitOfWork appStarterUnit
			, IMapper mapper) : base(consoleIO)
		{
			this.processStarter = processStarter;
			this.appStarterUnit = appStarterUnit;
			this.mapper = mapper;
		}

		public override bool CanExecute(object parameter)
		{
			if (parameter is not TextCommand textCommand)
				throw new Exception("No text command was passed.");
			if(textCommand.ParamList.Length == 0)
				throw new Exception("No arguments passed.");
			appName = textCommand.ParamList[0];
			if(textCommand.ParamList.Length > 1)
			{
				appParams = textCommand.ParamList.Skip(1).ToArray();
			}
			var appData = appStarterUnit.AppInfo.Get(x => x.Name == appName).FirstOrDefault();
			if (appData == null)
			{
				ConsoleIO.WriteLine("No app info in db.");
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
				ConsoleIO.WriteLine($"Start process : {appInfo.Name} in path {appInfo.Path}");
				if (appParams.Length > 0)
				{
					foreach (var param in appParams)
					{
						ConsoleIO.WriteLine($"with argument : {param}");
					}
					try
					{
						processStarter.StartProcess(appInfo.Path, appParams);
					}
					catch (Exception ex)
					{
						ConsoleIO.WriteLine(ex.Message);
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
						ConsoleIO.WriteLine(ex.Message);
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
					ConsoleIO.WriteLine(ex.Message);
				}
			}
		}
	}
}