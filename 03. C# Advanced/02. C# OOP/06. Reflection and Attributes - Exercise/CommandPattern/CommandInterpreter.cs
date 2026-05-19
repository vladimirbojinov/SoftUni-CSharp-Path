using CommandPattern.Core.Contracts;
using System.Reflection;
using System;
using System.Linq;

namespace CommandPattern;

public class CommandInterpreter : ICommandInterpreter
{
	public string Read(string args)
	{
		string[] data = args.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);

		string commandName = $"{data[0]}Command";
		Type commandType = Assembly.GetCallingAssembly().GetTypes().SingleOrDefault(t => t.Name == commandName);

		ICommand command;
		try
		{
			command = Activator.CreateInstance(commandType) as ICommand;
			return command.Execute(data[1..]);
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}

		return null;
	}
}