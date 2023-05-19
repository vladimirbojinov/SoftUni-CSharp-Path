namespace _10._Lower_or_Upper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char text = char.Parse(Console.ReadLine());

            bool isUpperCase = char.IsUpper(text);

            if (isUpperCase )
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}