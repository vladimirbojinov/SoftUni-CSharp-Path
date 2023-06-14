using System.Diagnostics.CodeAnalysis;

namespace _01._Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine()
                .Split()
                .ToList();
            string text = Console.ReadLine();
            List<string> textToList = new List<string>();

            for (int i = 0; i < text.Length; i++)
            {
                textToList.Add(text[i].ToString());
            }


            for (int i = 0; i < numbers.Count; i++)
            {
                int sum = 0;
                string stringedNum = numbers[i];
                for (int j = 0; j < stringedNum.Length; j++)
                {
                    int n = int.Parse(stringedNum[j].ToString());
                    sum += n;
                }

                if (textToList.Count - 1 < sum)
                {
                    sum -= textToList.Count;
                    Console.Write(textToList[sum]);
                    textToList.RemoveAt(sum);
                }
                else
                {
                    Console.Write(textToList[sum]);
                    textToList.RemoveAt(sum);
                }
            }
        }
    }
}