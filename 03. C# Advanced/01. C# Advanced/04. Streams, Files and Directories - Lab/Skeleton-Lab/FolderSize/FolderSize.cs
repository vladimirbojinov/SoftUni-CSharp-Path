namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            double fileSize = 0;

            DirectoryInfo directory = new DirectoryInfo(folderPath);
            FileInfo[] info = directory.GetFiles("*", SearchOption.AllDirectories);

            foreach (FileInfo infoItem in info)
            {
                fileSize += infoItem.Length;
            }

            fileSize = fileSize / 1024 / 1024;
            File.WriteAllText("output.txt", fileSize.ToString());
        }
    }
}
