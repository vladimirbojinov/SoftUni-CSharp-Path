namespace _02._From_Left_to_The_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());

            for (int i = 0; i < loops; i++)
            {
                string number = Console.ReadLine();
                int num1 = 0;
                int num2 = 0;
                bool isSpace = false;

                for (int j = 0; j < number.Length; j++)
                {
                    if (number[j] == ' ')
                    {
                        isSpace = true;
                    }

                    if (number[j] != ' ')
                    {
                        if (number[j] == ' ')
                        {
                            string temp = number[j].ToString();
                            temp = number[j+1].ToString();
                            if (isSpace == true)
                            {
                                num2 += int.Parse(temp);
                            }
                            else
                            {
                                num1 += int.Parse(temp);
                            }
                            j++;
                        }
                        else if (isSpace)
                        {
                            num2 += int.Parse(number[j].ToString());
                        }
                        else
                        {
                            num1 += int.Parse(number[j].ToString());
                        }
                    }
                }

                if (num1 > num2)
                {
                    Console.WriteLine(num1);
                }
                else
                {
                    Console.WriteLine(num2);
                }
            }
        }
    }
}