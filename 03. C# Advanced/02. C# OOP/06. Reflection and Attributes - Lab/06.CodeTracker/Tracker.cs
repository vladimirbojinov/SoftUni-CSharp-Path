using System.Reflection;

namespace AuthorProblem;

internal class Tracker
{
	public void PrintMethodsByAuthor()
	{
		Type type = typeof(StartUp);
		MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

		foreach (MethodInfo method in methods)
		{
			AuthorAttribute? customAttributes = method.GetCustomAttribute<AuthorAttribute>();
			if (customAttributes is not null)
			{
				Console.WriteLine($"{method.Name} is written by {customAttributes.Name}");
			}
		}
	}
}
