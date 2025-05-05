namespace _02._Articles
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] input = Console.ReadLine()
				.Split(", ")
				.ToArray();

			string title = input[0];
			string content = input[1];
			string author = input[2];

			Article article = new Article(title, content, author);

			int loops = int.Parse(Console.ReadLine());
			for (int i = 0; i < loops; i++)
			{
				string[] arguments = Console.ReadLine().Split(": ");
				switch (arguments[0])
				{
					case "Edit":
						string newContent = arguments[1];
						article.ChangeContent(newContent);
						break;
					case "ChangeAuthor":
						string newAuthor = arguments[1];
						article.ChangeAuthor(newAuthor);
						break;
					case "Rename":
						string newTitle = arguments[1];
						article.ChangeTitle(newTitle);
						break;
				}
			}

			Console.WriteLine(article);
		}
	}
	class Article
	{
		public Article(string title, string content, string autor)
		{
			Title = title;
			Content = content;
			Author = autor;
		}

		public string Title { get; set; }
		public string Content { get; set; }
		public string Author { get; set; }

		public void ChangeContent(string newContent)
		{
			Content = newContent;
		}
		public void ChangeAuthor(string newAuthor)
		{
			Author = newAuthor;
		}

		public void ChangeTitle(string newTitle)
		{
			Title = newTitle;
		}

		public override string ToString()
		{
			return $"{Title} - {Content}: {Author}";
		}
	}
}