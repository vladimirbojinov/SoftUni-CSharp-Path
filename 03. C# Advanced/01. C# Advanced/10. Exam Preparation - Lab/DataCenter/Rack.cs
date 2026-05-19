using System.Text;

namespace DataCenter
{
	public class Rack
	{
		public Rack(int slots)
		{
			Slots = slots;
			Servers = new List<Server>();
		}

		public int Slots { get; set; }
		public List<Server> Servers { get; set; }
		public int GetCount { get => Servers.Count; }

		public void AddServer(Server server)
		{
			Server? serverSearch = Servers.FirstOrDefault(x => x.SerialNumber == server.SerialNumber);
			if (Servers.Count == Slots || serverSearch != null) return;
			Servers.Add(server);
		}

		public bool RemoveServer(string serialNumber)
		{
			Server? serverSearch = Servers.FirstOrDefault(x => x.SerialNumber == serialNumber);
			return Servers.Remove(serverSearch);
		}

		public string GetHighestPowerUsage()
			=> Servers.MaxBy(x => x.PowerUsage).ToString();

		public int GetTotalCapacity()
			=> Servers.Sum(x => x.Capacity);

		public string DeviceManager()
		{
			StringBuilder stringBuilder = new StringBuilder();

			stringBuilder.AppendLine($"{Servers.Count} servers operating:");
			foreach (Server server in Servers)
			{
				stringBuilder.AppendLine($"{server}");
			}

			return stringBuilder.ToString().Trim();
		}
	}
}
