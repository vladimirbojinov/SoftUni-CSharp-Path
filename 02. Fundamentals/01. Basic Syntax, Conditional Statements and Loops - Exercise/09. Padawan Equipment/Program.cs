namespace _09._Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            double studentsCount = double.Parse(Console.ReadLine());
            double lightSaberPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double studentsCountWithPercent = Math.Ceiling((studentsCount * 0.10) + studentsCount);
            double lightSaberBought = lightSaberPrice * studentsCountWithPercent;
            double robesBought = studentsCount * robesPrice;

            int freeBelts = 0;
            double remainingStudents = studentsCount;

            if (studentsCount >= 6)
            {
                while (remainingStudents >= 6)
                {
                    freeBelts++;
                    remainingStudents -= 6;
                }
            }

            double beltsBought = (studentsCount - freeBelts) * beltPrice;
            double totalPrice = lightSaberBought + robesBought + beltsBought;

            if (totalPrice - money <= 0)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalPrice - money:f2}lv more.");
            }
        }
    }
}