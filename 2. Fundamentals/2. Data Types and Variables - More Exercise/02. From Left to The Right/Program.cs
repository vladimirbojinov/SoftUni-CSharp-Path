namespace _02._From_Left_to_The_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());

            bool isSpace = false;

            long n1 = 0L;
            long n2 = 0L;
            string stringedN1 = "";
            string stringedN2 = "";

            for (int i = 0; i < loops; i++)
            {
                string numColum = Console.ReadLine();

                for (int j = 0; j < numColum.Length; j++)
                {
                    char currentNum = numColum[j];
                    string stringedNum = currentNum.ToString();

                    if (stringedNum == " ")
                    {
                        isSpace = true;
                    }

                    if (isSpace && stringedNum != " ")
                    {

                        if (stringedNum == "-")
                        {
                            stringedN2 += stringedNum;
                        }
                        else
                        {
                            stringedN2 += stringedNum;
                            n2 += long.Parse(stringedN2);
                            stringedN2 = "";
                        }
                    }
                    else if (stringedNum != " ")
                    {
                        if (stringedNum == "-")
                        {
                            stringedN1 += stringedNum;
                        }
                        else
                        {
                            stringedN1 += stringedNum;
                            n1 += long.Parse(stringedN1);
                            stringedN1 = "";
                        }
                    }
                }

                if (n1 > n2)
                {
                    Console.WriteLine(n1);
                }
                else
                {
                    Console.WriteLine(n2);
                }

                isSpace = false;

                stringedN1 = "";
                stringedN2 = "";
                n1 = 0;
                n2 = 0;
            }
        }
    }
}