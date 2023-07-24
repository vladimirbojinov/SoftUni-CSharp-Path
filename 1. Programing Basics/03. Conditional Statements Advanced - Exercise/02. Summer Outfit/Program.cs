namespace _02._Summer_Outfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int degree = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();

            string outfit = "";
            string shoes = "";

            if (10 <= degree && degree <= 18)
            {
                switch (time)
                {
                    case "Morning": outfit = "Sweatshirt"; shoes = "Sneakers"; break;
                    case "Afternoon": outfit = "Shirt"; shoes = "Moccasins"; break;
                    case "Evening": outfit = "Shirt"; shoes = "Moccasins"; break;
                }
            }
            else if (degree <= 24)
            {
                switch (time)
                {
                    case "Morning": outfit = "Shirt"; shoes = "Moccasins"; break;
                    case "Afternoon": outfit = "T-Shirt"; shoes = "Sandals"; break;
                    case "Evening": outfit = "Shirt"; shoes = "Moccasins"; break;
                }
            }
            else if (degree >= 25)
            {
                switch (time)
                {
                    case "Morning": outfit = "T-Shirt"; shoes = "Sandals"; break;
                    case "Afternoon": outfit = "Swim Suit"; shoes = "Barefoot"; break;
                    case "Evening": outfit = "Shirt"; shoes = "Moccasins"; break;
                }
            }

            Console.WriteLine($"It's {degree} degrees, get your {outfit} and {shoes}.");
        }
    }
}