namespace _02._Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text1 = Console.ReadLine().Split();
            string[] text2 = Console.ReadLine().Split();

            for (int i = 0; i < text1.Length; i++)
            {
                for (int j = 0; j < text2.Length; j++)
                {
                    if (text1[i] == text2[j])
                    {
                        Console.Write(text2[j] + " ");
                    }
                }
            }
        }
    }
}