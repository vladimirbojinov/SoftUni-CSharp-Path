namespace _05._HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fullHtlm = string.Empty;

            string article = Console.ReadLine();
            article = string.Concat("<h1>\n", article, "\n", "</h1>", "\n");

            fullHtlm += article;

            string content = Console.ReadLine();
            content = string.Concat("<article>\n", content, "\n", "</article>", "\n");

            fullHtlm += content;

            string comment;
            while ((comment = Console.ReadLine()) != "end of comments")
            {
                comment = string.Concat("<div>\n", comment, "\n", "</div>", "\n");
                fullHtlm += comment;
            }

            Console.WriteLine(fullHtlm);
        }
    }
}