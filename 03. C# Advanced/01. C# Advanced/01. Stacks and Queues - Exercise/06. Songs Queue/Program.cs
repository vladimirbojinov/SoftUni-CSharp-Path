namespace _06._Songs_Queue
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Queue<string> queue = new Queue<string>(Console.ReadLine()
				.Split(", "));

			string songName = string.Empty;
			string command = string.Empty;

			while (queue.Count > 0)
			{
				string text = Console.ReadLine();

				if (text.Contains("Play"))
				{
					command = "Play";
				}
				else if (text.Contains("Add"))
				{
					command = "Add";
					songName = text.Replace("Add ", "");
				}
				else if (text.Contains("Show"))
				{
					command = "Show";
				}

				switch (command)
				{
					case "Play": PlaySong(queue); ; break;
					case "Add": AddSong(queue, songName) ; break;
					case "Show": ShowSongs(queue); break;
				}
			}

            Console.WriteLine("No more songs!");
        }

		public static void PlaySong(Queue<string> queue)
		{
			queue.Dequeue();
		}
		public static void AddSong(Queue<string> queue, string name)
		{
			bool isRepeated = queue.Any(x => x == name);

			if (!isRepeated)
			{
				queue.Enqueue(name);
				return;
			}

            Console.WriteLine($"{name} is already contained!");
        }
		public static void ShowSongs(Queue<string> queue)
		{
            Console.WriteLine(string.Join(", ", queue));
        }
	}
}
