using System.Reflection.Metadata.Ecma335;
namespace _02._Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] article = Console.ReadLine()
                .Split(", ")
                .ToArray();

            string title = article[0];
            string content = article[1];
            string author = article[2];

            int loops = int.Parse(Console.ReadLine());

            Articles articles = new Articles(title, content, author);

            for (int i = 0; i < loops; i++)
            {
                string[] arguments = Console.ReadLine().Split(": ");
                switch (arguments[0])
                {
                    case "Edit": 
                        string newContent = arguments[1];
                        articles.ChangeContent(newContent);
                        break;
                    case "ChangeAuthor":
                        string newAuthor = arguments[1];
                        articles.ChangeAuthor(newAuthor);
                        break;
                    case "Rename":
                        string newTitle = arguments[1];
                        articles.ChangeTitle(newTitle);
                        break;
                }
            }

            articles.Print();
        }
    }
    class Articles
    {
        public Articles(string title, string content, string autor)
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

        public void Print()
        {
            Console.WriteLine($"{Title} - {Content}: {Author}");
        }
    }

}