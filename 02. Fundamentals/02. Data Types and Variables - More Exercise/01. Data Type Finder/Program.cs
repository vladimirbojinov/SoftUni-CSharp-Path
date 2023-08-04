namespace _01._Data_Type_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double inputDouble = 0;
            int inputInt = 0;
            string inputString = "";
            char inputChar = ' ';
            bool inputBool = false;

            while (input != "END")
            {
                if (int.TryParse(input, out inputInt))
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (double.TryParse(input, out inputDouble))
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (char.TryParse(input, out inputChar))
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (bool.TryParse(input, out inputBool))
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }

                input = Console.ReadLine();
            }
        }
    }
}