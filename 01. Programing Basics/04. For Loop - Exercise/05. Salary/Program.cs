namespace _05._Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tabsOpened = int.Parse(Console.ReadLine());
            double salary = int.Parse(Console.ReadLine());

            for (int i = 0; i < tabsOpened; i++)
            {
                string tabName = Console.ReadLine();

                switch (tabName)
                {
                    case "Facebook": salary -= 150; break;
                    case "Instagram": salary -= 100; break;
                    case "Reddit": salary -= 50; break;
                    default:
                        break;
                }
                if (salary == 0)
                {
                    break;
                }
            }

            if (salary == 0)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine(salary);
            }
        }
    }
}