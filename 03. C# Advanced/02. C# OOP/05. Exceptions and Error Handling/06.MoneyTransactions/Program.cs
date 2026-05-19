namespace _06.MoneyTransactions;

internal class Program
{
	static void Main(string[] args)
	{
		Dictionary<int, double> bankAccounts = ProcessAccounts();
		ProcessCommands(bankAccounts);
	}

	private static void ProcessCommands(Dictionary<int, double> bankAccounts)
	{
		string command;
		while ((command = Console.ReadLine()) != "End")
		{
			try
			{
				string[] action = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

				int accountNumber = int.Parse(action[1]);
				double amount = double.Parse(action[2]);

				switch (action[0])
				{
					case "Deposit": Deposit(bankAccounts, accountNumber, amount); break;
					case "Withdraw": Withdraw(bankAccounts, accountNumber, amount); break;
					default: Console.WriteLine("Invalid command!"); break;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				Console.WriteLine("Enter another command");
			}
		}
	}

	private static void Withdraw(Dictionary<int, double> bankAccounts, int accountNumber, double amount)
	{
		if (!bankAccounts.ContainsKey(accountNumber)) throw new ArgumentException("Invalid account!");
		if (bankAccounts[accountNumber] < amount) throw new ArgumentException("Insufficient balance!");

		bankAccounts[accountNumber] -= amount;

		Console.WriteLine($"Account {accountNumber} has new balance: {bankAccounts[accountNumber]:F2}");
	}

	private static void Deposit(Dictionary<int, double> bankAccounts, int accountNumber, double amount)
	{
		if (!bankAccounts.ContainsKey(accountNumber)) throw new ArgumentException("Invalid account!");

		bankAccounts[accountNumber] += amount;

		Console.WriteLine($"Account {accountNumber} has new balance: {bankAccounts[accountNumber]:F2}");
	}

	private static Dictionary<int, double> ProcessAccounts()
	{
		Dictionary<int, double> bankAccounts = new();

		string[] accountsData = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
		foreach (string account in accountsData)
		{
			string[] accountData = account.Split("-", StringSplitOptions.RemoveEmptyEntries);
			int accountNumber = int.Parse(accountData[0]);
			double balance = double.Parse(accountData[1]);

			bankAccounts[accountNumber] = balance;
		}

		return bankAccounts;
	}
}
