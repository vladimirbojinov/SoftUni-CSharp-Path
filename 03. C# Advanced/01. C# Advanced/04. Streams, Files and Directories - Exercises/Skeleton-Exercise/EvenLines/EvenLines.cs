namespace EvenLines
{
    using System;
	using System.IO;
	using System.Linq;
	using System.Text;

	public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder result = new StringBuilder();
            int counter = 0;

			using (StreamReader reader = new StreamReader(inputFilePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    line = ReplaceSymbols(line);

                    if (counter % 2 == 0)
                    {
                        string[] words = line
                            .Split()
                            .Reverse()
                            .ToArray();

						result.AppendLine(string.Join(" ", words));
					}

                    counter++;
                }
            }

            return result.ToString();
        }

		private static string ReplaceSymbols(string line)
		{
            char[] chars = new char[] { '-', ',', '.', '!', '?' };

            foreach (char c in chars) 
            {
                line = line.Replace(c, '@');
            }

			return line;
		}
	}
}
