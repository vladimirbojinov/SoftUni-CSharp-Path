namespace CloudDrive
{
    public class File
    {
		public File(string name, string extension, int size)
		{
			Name = name;
			Extension = extension;
			Size = size;
		}

		public string Name { get; set; }
		public string Extension { get; set; }
		public int Size { get; set; }

		public override string ToString()
		{
			return $"File: '{Name}.{Extension}' - {Size}KB";
		}
	}
}
