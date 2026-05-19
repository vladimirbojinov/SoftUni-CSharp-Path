namespace _03.Telephony;

public class Smartphone : ICall, IBrowse
{
	public void Browse(string site)
	{
		Console.WriteLine($"Browsing: {site}!");
	}

	public void Call(string phoneNumber)
	{
		Console.WriteLine($"Calling... {phoneNumber}");
	}
}
