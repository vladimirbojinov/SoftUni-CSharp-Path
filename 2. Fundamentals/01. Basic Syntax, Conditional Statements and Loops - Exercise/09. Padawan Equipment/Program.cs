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

            double studentsPercent = Math.Ceiling((studentsCount * 0.10) + studentsCount);
            double lightSaberBought = lightSaberPrice * studentsPercent;
            double robesBought = studentsCount * robesPrice;

            int freeBelts = 0;
            double students = studentsCount;

            if (studentsCount - 6 >= 0)
            {

                while (students - 6 >= 0)
                {
                    freeBelts++;
                    students -= 6;
                }
            }

            double beltsBought = studentsCount - freeBelts;
            beltsBought *= beltPrice;
            double total = lightSaberBought + robesBought + beltsBought;

            if (total - money <= 0)
            {
                Console.WriteLine($"The money is enough - it would cost {total:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {total - money:f2}lv more.");
            }
        }
    }
}