namespace _07._Hotel_Room
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int night = int.Parse(Console.ReadLine());

            double studioPrice = 0;
            double apartmentPrice = 0;

            switch (month)
            {
                case "May":
                case "October": studioPrice = 50; apartmentPrice = 65; ; break;
                case "June":
                case "September": studioPrice = 75.2; apartmentPrice = 68.70; break;
                case "July":
                case "August": studioPrice = 76; apartmentPrice = 77; break;
            }

            if (night > 7 && night <= 14)
            {
                if (month == "May" || month == "October")
                {
                    studioPrice *= 0.95;
                }
            }
            else if (night > 14)
            {
                if (month == "May" || month == "October")
                {
                    studioPrice *= 0.7;
                }
                else
                {
                    if (month == "June" || month == "September")
                    {
                        studioPrice *= 0.8;
                    }

                }
                apartmentPrice *= 0.9;
            }

            double finalStudioPrice = studioPrice * night;
            double finalApartamentPrice = apartmentPrice * night;

            Console.WriteLine($"Apartment: {finalApartamentPrice:f2} lv.");
            Console.WriteLine($"Studio: {finalStudioPrice:f2} lv.");
        }
    }
}