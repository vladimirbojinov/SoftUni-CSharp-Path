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
                string[] arguments = command.Split();
                if (arguments[0] == "Add")
                {
                    wagons.Add(int.Parse(arguments[1]));
                }
                else
                {
                    int incomingPassengers = int.Parse(arguments[0]);
                    int currentWagon = 0;

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (incomingPassengers + wagons[currentWagon] <= maxCapacity)
                        {
                            wagons[currentWagon] += incomingPassengers;
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