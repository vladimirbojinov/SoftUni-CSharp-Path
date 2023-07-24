namespace _08._Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] gameNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            decimal total = 0;

            foreach (string stringGameNum in gameNumbers)
            {
                string stringNumber = string.Join("", stringGameNum.Where(char.IsDigit));
                decimal number = decimal.Parse(stringNumber);

                for (int i = 1; i < stringGameNum.Length; i++)
                {
                    if (char.IsLetter(stringGameNum[i - 1]))
                    {
                        char c = stringGameNum[i - 1];
                        int index = char.ToUpper(c) - 64;

                        if (char.IsUpper(c))
                        {
                            number /= index;
                        }
                        else
                        {
                            number *= index;
                        }
                    }
                    else if (char.IsLetter(stringGameNum[i]))
                    {
                        char c = stringGameNum[i];
                        int index = char.ToUpper(c) - 64;

                        if (char.IsUpper(c))
                        {
                            number -= index;
                        }
                        else
                        {
                            number += index;
                        }
                    }
                }

                total += number;
            }

            Console.WriteLine($"{total:F2}");
        }
    }
}