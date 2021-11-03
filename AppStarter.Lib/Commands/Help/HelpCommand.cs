using Console.Lib;

namespace AppStarter.Lib.Commands
{
	public class HelpCommand : ConsoleCommand
	{
		private readonly IConsoleIO consoleIO;
		private readonly IOneWordNames oneWordNames;
		private readonly IOneWordNames actions;
		private readonly IOneWordNames models;

		public HelpCommand(
			IConsoleIO consoleIO
			, IOneWordNames oneWordNames
			, IOneWordNames actions
			, IOneWordNames models)
		{
			this.consoleIO = consoleIO;
			this.oneWordNames = oneWordNames;
			this.actions = actions;
			this.models = models;
		}

		public override void Execute(object parameter)
		{
			consoleIO.WriteLine($"One word commands: {string.Join(',', oneWordNames.GetInstance())},[model]");
			consoleIO.WriteLine($"Two word commands: [action] [model]");
			consoleIO.WriteLine($"Actions: {string.Join(',', actions.GetInstance())}");
			consoleIO.WriteLine($"Models: {string.Join(',', models.GetInstance())}");
		}
	}
}