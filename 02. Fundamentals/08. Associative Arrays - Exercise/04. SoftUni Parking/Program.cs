namespace _04._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> registeredCars = new Dictionary<string, string>();

            int registrationNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < registrationNumber; i++)
            {
                string[] arguments = Console.ReadLine().Split();
                string name = arguments[1];

                switch (arguments[0])
                {
                    case "register":
                        string licensePlate = arguments[2];
                        if (!registeredCars.ContainsKey(name))
                        {
                            registeredCars.Add(name, licensePlate);
                            Console.WriteLine($"{name} registered {licensePlate} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
                        }
                        break;
                    case "unregister":
                        if (registeredCars.ContainsKey(name))
                        {
                            registeredCars.Remove(name);
                            Console.WriteLine($"{name} unregistered successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: user {name} not found");
                        }
                        break;
                }
            }

            foreach (var kvp in registeredCars)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}