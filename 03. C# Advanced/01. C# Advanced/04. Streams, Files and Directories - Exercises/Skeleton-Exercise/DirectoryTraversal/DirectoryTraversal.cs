namespace DirectoryTraversal
{
    using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;

	public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            Dictionary<string, List<FileInfo>> dictionary = new Dictionary<string, List<FileInfo>>();  

            foreach (string file in Directory.GetFiles(inputFolderPath))
            {
                FileInfo fileInfo = new FileInfo(file);

                if (!dictionary.ContainsKey(fileInfo.Extension))
                {
					dictionary[fileInfo.Extension] = new List<FileInfo>();
                }

				dictionary[fileInfo.Extension].Add(fileInfo);
			}

            dictionary = dictionary
                .OrderBy(x => x.Key)
                .ThenBy(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            StringBuilder stringBuilder = new StringBuilder();
            foreach ((string fileExtension, var files) in dictionary)
            {
                stringBuilder.AppendLine(fileExtension);
                foreach (FileInfo fileInfo in files)
                {
					stringBuilder.AppendLine($"--{fileInfo.Name} - {fileInfo.Length}kb");
                }
            }

            return stringBuilder.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (StreamWriter writer = new StreamWriter(desktopPath))
            {
                writer.Write(textContent);
            }
        }
    }
}
