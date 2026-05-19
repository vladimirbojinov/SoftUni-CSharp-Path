namespace LineNumbers
{
    using System;
	using System.IO;

	public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    int counter = 1;

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
						string result = CountLettersAndPunctuation(counter, line);
                        
                        writer.WriteLine(result);

                        counter++;
                    }
                }
            }
        }

		private static string CountLettersAndPunctuation(int counter, string text)
		{
            int letterCount = 0;
            int punctuationCount = 0;

			foreach (char c in text)
            {
                if (char.IsLetter(c)) letterCount++;
                if (char.IsPunctuation(c)) punctuationCount++;
            }

            return $"Line {counter}: {text} ({letterCount})({punctuationCount})";
        }
	}
}
