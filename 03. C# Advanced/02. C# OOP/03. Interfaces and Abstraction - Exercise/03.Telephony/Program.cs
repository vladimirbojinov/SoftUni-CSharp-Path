namespace _03.Telephony;

public class StartUp
{
	static void Main(string[] args)
	{
		Smartphone smartphone = new Smartphone();
		StationaryPhone stationaryPhone = new StationaryPhone();

		CallPhoneNumbers(smartphone, stationaryPhone);
		BrowseWebSites(smartphone, stationaryPhone);
	}

	private static void BrowseWebSites(Smartphone smartphone, StationaryPhone stationaryPhone)
	{
		string[] sites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

		foreach (string site in sites)
		{
			if (!site.Any(x => char.IsDigit(x))) smartphone.Browse(site);
			else Console.WriteLine("Invalid URL!");
		}
	}

	private static void CallPhoneNumbers(Smartphone smartphone, StationaryPhone stationaryPhone)
	{
		string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
		foreach (string phoneNumber in phoneNumbers)
		{
			if (!phoneNumber.Any(x => char.IsDigit(x)))
			{
				Console.WriteLine("Invalid number!");
				continue;
			}

			switch (phoneNumber.Length)
			{
				case 10: smartphone.Call(phoneNumber); break;
				case 7: stationaryPhone.Call(phoneNumber); break;
			}
		}
	}
}
