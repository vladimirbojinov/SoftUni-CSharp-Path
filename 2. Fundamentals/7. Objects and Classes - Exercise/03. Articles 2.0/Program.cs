namespace _03._Articles_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Articles> articleList = new List<Articles>();

            int loops = int.Parse(Console.ReadLine());
            for (int i = 0; i < loops; i++)
            {
                string[] article = Console.ReadLine().Split(", ");

                string title = article[0];
                string content = article[1];
                string author = article[2];

                Articles articles = new Articles(title, content, author);
                articleList.Add(articles);
            }

            Console.WriteLine(string.Join("\n", articleList));
        }
    }

    class Articles
    {
        public Articles(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}