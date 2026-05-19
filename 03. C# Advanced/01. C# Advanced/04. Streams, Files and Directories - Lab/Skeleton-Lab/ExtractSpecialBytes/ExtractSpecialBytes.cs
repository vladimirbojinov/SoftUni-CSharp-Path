namespace ExtractSpecialBytes
{
    using System;
	using System.Collections.Generic;
	using System.IO;
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            HashSet<byte> specialBytes = new HashSet<byte>();

            using (StreamReader reader = new StreamReader(bytesFilePath))
            {
                while (!reader.EndOfStream)
                {
                    byte currentSpecialByte = byte.Parse(reader.ReadLine());
                    specialBytes.Add(currentSpecialByte);
                }
            }

            using (FileStream inputStream = new FileStream(binaryFilePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
				    byte[] buffer = new byte[1000];

                    int readBytes = 0;
                    while ((readBytes = inputStream.Read(buffer)) != 0)
                    {
                        int specialsCount = 0;
                        for (int i = 0; i < readBytes; i++)
                        {
                            if (specialBytes.Contains(buffer[i]))
                            {
                                buffer[specialsCount++] = buffer[i];
                            }
                        }

                        outputStream.Write(buffer, 0, specialsCount);
                    }
                }

            }
        }
    }
}
