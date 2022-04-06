using AppStarter.Data;
using CLIFramework;
using CLIReader;
using System;
using System.Collections.Generic;

namespace AppStarter.Lib;

public class AppInfoInsertCommand 
	: DataCommand<AppInfo>
{
	private readonly IAppStarterUnitOfWork unitOfWork;
	private readonly IReader<string> requiredTextReader;
    private ICommandRunner commandRunner;

	public AppInfoInsertCommand(
		TextCommand command
		, IAppStarterUnitOfWork unitOfWork
		, List<IReader<string>> textReaders)
		: base(command)
	{
		ArgumentNullException.ThrowIfNull(unitOfWork);
		ArgumentNullException.ThrowIfNull(textReaders);

		this.unitOfWork = unitOfWork;
		requiredTextReader = textReaders[0];
	}

	public void SetCommandRunner(ICommandRunner commandRunner)
	{
		ArgumentNullException.ThrowIfNull(commandRunner);
        this.commandRunner = commandRunner;
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
		commandRunner.RunCommand(TextCommand.TypeName.ToLowerInvariant());
	}
}