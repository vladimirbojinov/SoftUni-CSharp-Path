namespace OddLines
{
    using System.IO;
	
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            int counter = 0;

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        if (counter % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }

                        counter++;
                    }
                }
            }
        }
    }
}
