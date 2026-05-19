namespace _07._Truck_Tour
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int pumpsCount = int.Parse(Console.ReadLine());
			
			Queue<int[]> queue = new Queue<int[]>();

			ReadData(queue, pumpsCount);
			SearchRoute(queue);
		}

		public static void ReadData(Queue<int[]> queue, int pumpsCount)
		{
			for (int i = 0; i < pumpsCount; i++)
			{
				int[] routeData = Console.ReadLine()
					.Split()
					.Select(int.Parse)
					.ToArray();

				queue.Enqueue(routeData);
			}
		}
		public static void SearchRoute(Queue<int[]> queue) 
		{
			int bestRoute = 0;

			while (true)
			{
				int truckFuel = 0;

				foreach (int[] routeData in queue)
				{
					int currentPump = routeData[0];
					int routeDistance = routeData[1];

					truckFuel += currentPump;

					if (truckFuel < routeDistance)
					{
						truckFuel = -1;
						break;
					}
					
					truckFuel -= routeDistance;
				}

				if (truckFuel != -1)
				{
                    Console.WriteLine(bestRoute);
                    break;
				}

				queue.Enqueue(queue.Dequeue());
				bestRoute++;
			}
		}
	}
}
