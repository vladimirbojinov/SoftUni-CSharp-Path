namespace _02._Sum_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                string stringedNumber = numbers[i].ToString();

                sum += int.Parse(stringedNumber);
            }

            Console.WriteLine(sum);
        }
    }
}