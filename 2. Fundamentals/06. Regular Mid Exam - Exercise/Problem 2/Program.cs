using System;

namespace Problem_2
{
    /*
Arabica Liberica Charrieriana Magnistipula Robusta BulkCoffee StrongCoffee
5
Include TurkishCoffee
Remove first 2
Remove last 1
Prefer 3 1
Reverse

     */
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> coffeeList = Console.ReadLine()
                .Split()
                .ToList();

            int orderAmount = int.Parse(Console.ReadLine());

            for (int i = 0; i < orderAmount; i++)
            {
                string[] arguments = Console.ReadLine().Split().ToArray();
                switch (arguments[0])
                {
                    case "Include": coffeeList = IncludeCoffee(coffeeList, arguments[1]); break;
                    case "Remove":
                        switch (arguments[1])
                        {
                            case "last": coffeeList = RemoveLastCoffee(coffeeList, int.Parse(arguments[2])); break;
                            case "first": coffeeList = RemoveFirstCoffee(coffeeList, int.Parse(arguments[2])); break;
                        }
                        break;
                    case "Prefer": coffeeList = PreferCoffee(coffeeList, int.Parse(arguments[1]), int.Parse(arguments[2])); break;
                    case "Reverse": coffeeList = ReverseCoffee(coffeeList); break;
                }
            }

            Console.WriteLine("Coffees:");
            Console.WriteLine(string.Join(" ", coffeeList));
        }

        private static List<string> ReverseCoffee(List<string> coffeeList)
        {
            coffeeList.Reverse();
            return coffeeList;
        }
        private static List<string> PreferCoffee(List<string> coffeeList, int index1, int index2)
        {
            bool isIndex1 = false;
            bool isIndex2 = false;

            if (isInRange(index1, coffeeList))
            {
                isIndex1 = true;
            }
            if (isInRange(index2, coffeeList))
            {
                isIndex2 = true;
            }

            if (isIndex1 && isIndex2)
            {
                string temp = coffeeList[index1];
                coffeeList[index1] = coffeeList[index2];
                coffeeList[index2] = temp;
            }
            return coffeeList;
        }
        private static List<string> RemoveFirstCoffee(List<string> coffeeList, int index)
        {
            if (isInRange(index, coffeeList))
            {
                for (int i = 0; i < index; i++)
                {
                    coffeeList.RemoveAt(0);
                }
            }
            return coffeeList;
        }
        private static List<string> RemoveLastCoffee(List<string> coffeeList, int index)
        {
            int lastIndex = coffeeList.Count - 1;
            int until = (coffeeList.Count - 1) - index;
            if (isInRange(index, coffeeList))
            {
                for (int i = lastIndex; i > until; i--)
                {
                    coffeeList.RemoveAt(i);
                }
            }

            return coffeeList;
        }
        private static List<string> IncludeCoffee(List<string> coffeeList, string coffee)
        {
            coffeeList.Add(coffee);
            return coffeeList;
        }
        private static bool isInRange(int index, List<string> coffeeList)
        {
            if (index < 0 || index >= coffeeList.Count)
            {
                return false;
            }

            return true;
        }
    }
}