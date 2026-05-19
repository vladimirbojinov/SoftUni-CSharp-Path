namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader readerFileOne = new StreamReader(firstInputFilePath))
            {
				using (StreamReader readerFileTwo = new StreamReader(secondInputFilePath))
				{
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        while (!readerFileOne.EndOfStream || !readerFileTwo.EndOfStream)
                        {
                            if (!readerFileOne.EndOfStream)
                            {
                                string line = readerFileOne.ReadLine();
                                writer.WriteLine(line);
                            } 

                            if (!readerFileTwo.EndOfStream)
                            {
                                string line = readerFileTwo.ReadLine();
                                writer.WriteLine(line);
                            }
                        }
                    }
				}
			}
        }
    }
}
