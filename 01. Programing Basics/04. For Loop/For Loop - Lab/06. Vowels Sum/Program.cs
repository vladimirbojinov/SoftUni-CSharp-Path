namespace _06._Vowels_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string txt = Console.ReadLine();

            int finalSum = 0;

            for (int i = 0; i < txt.Length; i++)
            {
                char letter = txt[i];

                switch (letter)
                {
                    case 'a': finalSum += 1; break;
                    case 'e': finalSum += 2; break;
                    case 'i': finalSum += 3; break;
                    case 'o': finalSum += 4; break;
                    case 'u': finalSum += 5; break;
                }
            }

            Console.WriteLine(finalSum);
        }
    }
}