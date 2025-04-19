using System.Numerics;
using System.Text;

namespace _05._Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            string multiplier = Console.ReadLine();

            Console.WriteLine(BigIntWithString(number, multiplier));
        }

        static string BigIntWithString(string number, string multiplier)
        {
            if (number == "0" || multiplier == "0")
            {
                return "0";
            }

            StringBuilder sb = new StringBuilder();
            int resultRemain1 = 0;
            int remain = 0;

            int parsedMultiplier = int.Parse(multiplier);
            for (int i = number.Length - 1; i >= 0; i--)
            {
                int parsedNumber = int.Parse(number[i].ToString());
                int result = parsedNumber * parsedMultiplier;

                if (number.Length > 1)
                {
                    int resultRemain = (result % 10) + remain;
                    if (resultRemain > 9)
                    {
                        resultRemain1 = resultRemain / 10;
                        resultRemain %= 10;
                    }
                    remain = result / 10;
                    remain += resultRemain1;
                    sb.Insert(0, resultRemain);

                    resultRemain1 = 0;
                }
                else
                {
                    return result.ToString();
                }

                if (i == 0 && remain > 0)
                {
                    sb.Insert(0, remain);
                }

            }

            return sb.ToString();
        }
    }
}