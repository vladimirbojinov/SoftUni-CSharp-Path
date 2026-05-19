namespace CopyBinaryFile
{
    using System;
	using System.IO;

	public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream inputStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream outputStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                {
                    long fileLength = inputStream.Length;
                    ReadBytes(inputStream, outputStream, (int)fileLength);
                }
            }
        }

		private static void ReadBytes(FileStream inputStream, FileStream outputStream, int count)
		{
            byte[] buffer = new byte[1024];
            int totalReadBytes = 0;

			while (totalReadBytes < count)
			{
				int readBytes = inputStream.Read(buffer, 0, Math.Min(buffer.Length, count - totalReadBytes));

				outputStream.Write(buffer, 0, readBytes);
				totalReadBytes += readBytes;
			}
		}
	}
}
