namespace _03._Santas_Holiday
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daysToStay = int.Parse(Console.ReadLine()) - 1;
            string roomType = Console.ReadLine();
            string review = Console.ReadLine();

            double roomPrice = 0;

            switch (roomType)
            {
                case "room for one person": roomPrice = 18.00; roomPrice *= daysToStay; break;
                case "apartment":
                    roomPrice = 25.00;
                    if (daysToStay < 10)
                    {
                        roomPrice *= daysToStay;
                        roomPrice *= 0.70;
                    }
                    else if (daysToStay < 15)
                    {
                        roomPrice *= daysToStay;
                        roomPrice *= 0.65;
                    }
                    else
                    {
                        roomPrice *= daysToStay;
                        roomPrice *= 0.50;
                    }
                    break;
                case "president apartment":
                    roomPrice = 35.00;
                    if (daysToStay < 10)
                    {
                        roomPrice *= daysToStay;
                        roomPrice *= 0.90;
                    }
                    else if (daysToStay < 15)
                    {
                        roomPrice *= daysToStay;
                        roomPrice *= 0.85;
                    }
                    else
                    {
                        roomPrice *= daysToStay;
                        roomPrice *= 0.80;
                    }
                    ; break;
            }
            
            if (review == "positive")
            {
                roomPrice += roomPrice * 0.25;
            }
            else
            {
                roomPrice *= 0.90;
            }

            Console.WriteLine($"{roomPrice:f2}");
        }
    }
}