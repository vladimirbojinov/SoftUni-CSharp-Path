namespace _01._Sort_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            if (num1 > num2)
            {
                int temp = num1;
                num1 = num2;
                num2 = temp;
            }

            if (num2 > num3)
            {
                int temp = num2;
                num2 = num3;
                num3 = temp;
            }

            if (num1 > num2)
            {
                int temp = num1;
                num1 = num2;
                num2 = temp;
            }

            Console.WriteLine(num3);
            Console.WriteLine(num2);
            Console.WriteLine(num1);
        }
    }
}