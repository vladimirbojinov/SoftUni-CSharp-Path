namespace _03._Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int songsNumber = int.Parse(Console.ReadLine());
            List<Songs> songsList = new List<Songs>();
            for (int i = 0; i < songsNumber; i++)
            {
                string[] songs = Console.ReadLine()
                    .Split("_")
                    .ToArray();
                string type = songs[0];
                string name = songs[1];
                string time =songs[2];

                Songs song = new Songs(type, name, time);
                songsList.Add(song);
            }

            string command = Console.ReadLine();
            if (command == "all")
            {
                foreach (Songs name in songsList)
                {
                    Console.WriteLine(name.Name);
                }
            }
            else
            {
                foreach (Songs name in songsList)
                {
                    if (name.Type == command)
                    {
                        Console.WriteLine(name.Name);
                    }
                }
            }
        }
    }

    public class Songs
    {
        public Songs(string type, string name, string time)
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