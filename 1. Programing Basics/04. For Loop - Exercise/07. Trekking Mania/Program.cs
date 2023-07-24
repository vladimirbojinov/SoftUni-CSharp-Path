namespace _07._Trekking_Mania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groupCount = int.Parse(Console.ReadLine());
            int musala = 0, monblan = 0, kiliman = 0, k2 = 0, everest = 0;

            int amountOfppl = 0;
            for (int i = 0; i < groupCount; i++)
            {
                int ppl = int.Parse(Console.ReadLine());

                amountOfppl += ppl;

                if (ppl <= 5)
                {
                    musala += ppl;
                }
                else if (ppl <= 12)
                {
                    monblan += ppl;
                }
                else if (ppl <= 25)
                {
                    kiliman += ppl;
                }
                else if (ppl <= 40)
                {
                    k2 += ppl;
                }
                else
                {
                    everest += ppl;
                }
            }
            Console.WriteLine($"{musala * 1.0 / amountOfppl * 100:f2}%");
            Console.WriteLine($"{monblan * 1.0 / amountOfppl * 100:f2}%");
            Console.WriteLine($"{kiliman * 1.0 / amountOfppl * 100:f2}%");
            Console.WriteLine($"{k2 * 1.0 / amountOfppl * 100:f2}%");
            Console.WriteLine($"{everest * 1.0 / amountOfppl * 100:f2}%");
        }
    }
}