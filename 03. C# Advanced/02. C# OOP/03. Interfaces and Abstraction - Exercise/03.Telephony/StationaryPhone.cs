namespace _03.Telephony;

public class StationaryPhone : ICall
{
	public void Call(string phoneNumber)
	{
		Console.WriteLine($"Dialing... {phoneNumber}");
	}
}
