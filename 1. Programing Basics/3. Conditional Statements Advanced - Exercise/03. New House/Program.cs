namespace _03._New_House
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double totalSum = 0;

            switch (flowerType)
            {
                case "Roses": totalSum = quantity * 5; break;
                case "Dahlias": totalSum = quantity * 3.8; break;
                case "Tulips": totalSum = quantity * 2.8; break;
                case "Narcissus": totalSum = quantity * 3; break;
                case "Gladiolus": totalSum = quantity * 2.5; break;
            }

            if (quantity > 80 && flowerType == "Roses")
            {
                totalSum *= 0.9;
            }
            else if (quantity > 90 && flowerType == "Dahlias")
            {
                totalSum *= 0.85;
            }
            else if (quantity > 80 && flowerType == "Tulips")
            {
                totalSum *= 0.85;
            }
            else if (quantity < 120 && flowerType == "Narcissus")
            {
                totalSum *= 1.15;
            }
            else if (quantity < 80 && flowerType == "Gladiolus")
            {
                totalSum *= 1.2;
            }

            if (totalSum <= budget)
            {
                Console.WriteLine($"Hey, you have a great garden with {quantity} {flowerType} and {budget - totalSum:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {totalSum - budget:f2} leva more.");
            }
        }
    }
}