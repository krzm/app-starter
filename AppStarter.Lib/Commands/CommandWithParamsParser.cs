using Console.Lib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppStarter.Lib
{
	public class CommandWithParamsParser : ICommandParser
	{
		private readonly ICommandParser parser;
		private readonly List<TextCommand> commands;

		public CommandWithParamsParser(
			ITextCommands textCommands
			, ICommandParser parser)
		{
			this.parser = parser;
			commands = (from command in textCommands.Commands
				select new TextCommand(command)).ToList();
		}

		public TextCommand Parse(string input)
		{
			if(input.StartsWith("start"))
			{
				var split = input.Split(" ");
				var commandName = split[0];
				var command = commands.FirstOrDefault(c => c.Equals(new TextCommand(commandName)));
				if (command == null) throw new ArgumentException("No such command");
				return new TextCommand(commandName, split.Skip(1).ToArray());
			}
			else
			return parser.Parse(input);
			throw new ArgumentException("No such command");
		}
	}
}