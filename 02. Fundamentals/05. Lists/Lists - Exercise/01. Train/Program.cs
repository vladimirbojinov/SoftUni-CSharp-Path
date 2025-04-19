namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] argument = command.Split();
                if (argument[0] == "Add")
                {
                    wagons.Add(int.Parse(argument[1]));
                }
                else
                {
                    int addedPassengers = int.Parse(argument[0]);
                    int currentWagon = 0;

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (addedPassengers + wagons[currentWagon] <= maxCapacity)
                        {
                            wagons[currentWagon] += addedPassengers;
                            break;
                        }

                        currentWagon++;

                    }
                }
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}