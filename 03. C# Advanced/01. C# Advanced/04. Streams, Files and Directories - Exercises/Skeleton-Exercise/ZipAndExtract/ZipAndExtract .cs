namespace ZipAndExtract
{
    using System;
    using System.IO;
	using System.IO.Compression;

	public class ZipAndExtract
    {
        static void Main()
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

			string fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            if (File.Exists(zipArchiveFilePath))
            {
                File.Delete(zipArchiveFilePath);
            }

            using (FileStream outputStream = new FileStream(zipArchiveFilePath, FileMode.Create, FileAccess.Write))
            {
                using (ZipArchive archive = new ZipArchive(outputStream, ZipArchiveMode.Create))
                {
                    string fileName = Path.GetFileName(inputFilePath);
					archive.CreateEntryFromFile(inputFilePath, fileName);
                }
            }
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using (FileStream outputStream = new FileStream(zipArchiveFilePath, FileMode.Open, FileAccess.Read))
            {
                using (ZipArchive archive = new ZipArchive(outputStream, ZipArchiveMode.Read))
                {
                    ZipArchiveEntry entry = archive.GetEntry(fileName);
                    entry.ExtractToFile(outputFilePath);
                }
            }
        }
    }
}
