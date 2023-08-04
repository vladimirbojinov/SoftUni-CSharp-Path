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
                int n1 = 0;
                int n2 = 0;
                bool isSpace = false;

                for (int j = 0; j < number.Length; j++)
                {
                    if (number[j].ToString() == " ")
                    {
                        isSpace = true;
                    }

                    if (number[j].ToString() != " ")
                    {
                        if (number[j].ToString() == "-")
                        {
                            string temp = number[j].ToString();
                            temp = number[j+1].ToString();
                            if (isSpace == true)
                            {
                                n2 += int.Parse(temp);
                            }
                            else
                            {
                                n1 += int.Parse(temp);
                            }
                            j++;
                        }
                        else if (isSpace)
                        {
                            n2 += int.Parse(number[j].ToString());
                        }
                        else
                        {
                            n1 += int.Parse(number[j].ToString());
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
            }
        }
    }
}