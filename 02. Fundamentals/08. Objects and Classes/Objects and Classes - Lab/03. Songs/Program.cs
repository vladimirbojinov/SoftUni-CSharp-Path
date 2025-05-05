namespace _03._Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Song> songs = new List<Song>();
            
            int songCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < songCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("_")
                    .ToArray();

				string type = input[0];
				string name = input[1];
				string duration = input[2];

				Song song = new Song(type, name, duration);
				songs.Add(song);
            }

            string songTypeFilter = Console.ReadLine();
            if (songTypeFilter == "all")
            {
                foreach (Song name in songs)
                {
                    Console.WriteLine(name.Name);
                }
            }
            else
            {
                foreach (Song name in songs)
                {
                    if (name.Type == songTypeFilter)
                    {
                        Console.WriteLine(name.Name);
                    }
                }
            }
        }
    }

    public class Song
    {
        public Song(string type, string name, string time)
        {
            Type = type;
            Name = name;
            Time = time;
        }

        public string Type { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}