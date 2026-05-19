using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Commands;

public class HelloCommand : ICommand
{
	public string Execute(string[] args)
		=> $"Hello, {args[0]}";
}
