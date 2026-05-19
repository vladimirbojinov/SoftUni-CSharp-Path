namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
			int counter = 0;

			using (StreamReader reader = new StreamReader(inputFilePath))
			{
				using (StreamWriter writer = new StreamWriter(outputFilePath))
				{
					while (!reader.EndOfStream)
					{
						counter++;
						
						string line = reader.ReadLine();
						writer.WriteLine($"{counter}. {line}");
					}
				}
			}
		}
    }
}
