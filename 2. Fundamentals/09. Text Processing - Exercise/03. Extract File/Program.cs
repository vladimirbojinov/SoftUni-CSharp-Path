namespace _03._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();

            int backSlashLastIndex = filePath.LastIndexOf('\\');
            int dotIndex = filePath.IndexOf('.');

            string fileName = filePath.Substring(backSlashLastIndex + 1, dotIndex - backSlashLastIndex - 1);
            string extenstionName = filePath.Substring(dotIndex + 1);
            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extenstionName}");
        }
    }
}