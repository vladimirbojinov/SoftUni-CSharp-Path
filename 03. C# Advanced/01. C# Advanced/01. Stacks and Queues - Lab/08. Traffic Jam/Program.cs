namespace _08._Traffic_Jam
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int canPass = int.Parse(Console.ReadLine());
			Queue<string> queue = new Queue<string>();

			int passed = 0;

			string command = string.Empty;
			while ((command = Console.ReadLine()) != "end")
			{
				if (command == "green")
				{
					for (int i = 0; i < canPass; i++)
					{
						if (queue.Count == 0)
						{
							break;
						}

						passed++;
						string car = queue.Dequeue();
						Console.WriteLine($"{car} passed!");
					}
                }
                else
                {
					queue.Enqueue(command);
                }
			}

            Console.WriteLine($"{passed} cars passed the crossroads.");
        }
	}
}