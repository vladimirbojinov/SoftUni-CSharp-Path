using System.Text;

namespace _07._String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            int strength = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '>')
                {
                    strength += int.Parse(text[i + 1].ToString());
                    sb.Append(text[i]);
                }
                else if (strength == 0)
                {
                    sb.Append(text[i]);
                }
                else
                {
                    strength--;
                }
            }

            Console.WriteLine(sb);
        }
    }
}