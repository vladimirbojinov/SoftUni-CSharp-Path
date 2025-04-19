using System.Text.RegularExpressions;

namespace _02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> racersDictionary = new Dictionary<string, int>();

            string namePattern = @"[A-Za-z]";
            string distancePattern = @"\d";

            string[] nameArray = Console.ReadLine().Split(", ");

            string command;
            while ((command = Console.ReadLine()) != "end of race")
            {
                string newName = string.Empty;
                int newDistance = 0;

                MatchCollection nameMatches = Regex.Matches(command, namePattern);

                foreach (Match name in nameMatches)
                {
                    newName += name;
                }
                MatchCollection numberMatches = Regex.Matches(command, distancePattern);
                foreach (Match distance in numberMatches)
                {
                    newDistance += int.Parse(distance.Value);
                }

                if (nameArray.Contains(newName) && !racersDictionary.ContainsKey(newName))
                {
                    racersDictionary.Add(newName, newDistance);
                }
                else if (racersDictionary.ContainsKey(newName))
                {
                    racersDictionary[newName] += newDistance;
                }
            }

            List<KeyValuePair<string, int>> orderedList = racersDictionary.OrderByDescending(x => x.Value).ToList();
            int count = 0;
            string place = string.Empty;

            for (int i = 0; i < 3; i++)
            {
                switch (i + 1)
                {
                    case 1: place = "1st"; break;
                    case 2: place = "2nd"; break;
                    case 3: place = "3rd"; break;
                }

                Console.WriteLine($"{place} place: {orderedList[i].Key}");
            }
        }
    }
}