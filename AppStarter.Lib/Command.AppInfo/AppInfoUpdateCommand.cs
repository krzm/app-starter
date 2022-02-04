using System;
using System.Collections.Generic;
using AppStarter.Data;
using CLIFramework;
using CLIHelper;
using CLIReader;

namespace AppStarter.Lib;

public class AppInfoUpdateCommand 
	: DataCommand<AppInfo>
{
	private readonly IAppStarterUnitOfWork unitOfWork;
	private readonly IReader<string> requiredTextReader;
    private ICommandRunner commandRunner;

	public AppInfoUpdateCommand(
		TextCommand textCommand
		, IAppStarterUnitOfWork unitOfWork 
		, List<IReader<string>> textReaders)
		: base(textCommand)
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
		var id = int.Parse(requiredTextReader.Read(
			new ReadConfig(6, $"Select {TextCommand.TypeName} Id.")));
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
		commandRunner.RunCommand(TextCommand.TypeName.ToLowerInvariant());
	}
}