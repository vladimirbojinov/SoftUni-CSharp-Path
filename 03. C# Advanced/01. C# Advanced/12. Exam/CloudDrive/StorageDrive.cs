using System.Text;

namespace CloudDrive;

public class StorageDrive
{
	public StorageDrive(string name, int capacity)
	{
		Name = name;
		Capacity = capacity;
		Files = new List<File>();
	}

	public string Name { get; set; }
	public int Capacity { get; set; }
	public List<File> Files { get; set; }

	public void AddFile(File file)
	{
		int totalFilesSize = Files.Sum(x => x.Size);
		File? searchedFile = Files.FirstOrDefault(x => x.Name == file.Name && x.Extension == file.Extension);

		if (totalFilesSize + file.Size <= Capacity && searchedFile == null) Files.Add(file);
	}

	public bool DeleteFile(string name, string extension)
	{
		File? file = Files.FirstOrDefault(x => x.Name == name && x.Extension == extension);
		return Files.Remove(file!);
	}

	public File GetLargestFile()
		=> Files.MaxBy(x => x.Size)!;

	public string GetFileDetails(string name, string extension)
	{
		File? file = Files.FirstOrDefault(x => x.Name == name && x.Extension == extension);

		if (file == null) return "File not found!";
		else return file.ToString();
	}

	public int GetFilesCount()
		=> Files.Count();

	public List<File> GetFilesByType(string extension)
		=> Files.Where(x => x.Extension == extension).OrderBy(x => x.Size).ToList();

	public string StorageReport()
	{
		StringBuilder sb = new StringBuilder();
		List<File> orderedList = Files.OrderBy(x => x.Size).ToList();

		sb.AppendLine($"Storage Drive: {Name}");
		foreach (File file in orderedList)
		{
			sb.AppendLine(file.ToString());
		}

		return sb.ToString().Trim();
	}
}