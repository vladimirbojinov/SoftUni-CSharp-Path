namespace _05._Login
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string username = Console.ReadLine();
			string correctPassword = string.Empty;

			for (int i = username.Length - 1; i >= 0; i--)
			{
				char currentChar = username[i];
				correctPassword += currentChar;
			}

			int attempts = 0;
			while (attempts != 4)
			{
				string passwordInput = Console.ReadLine();

				if (passwordInput == correctPassword)
				{
					Console.WriteLine($"User {username} logged in.");
					break;
				}

				attempts++;
				if (attempts >= 4)
				{
					Console.WriteLine($"User {username} blocked!");
					break;
				}

				Console.WriteLine("Incorrect password. Try again.");
			}
		}
	}
}