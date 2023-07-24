namespace _01._Old_Books
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();

            int bookCount = 0;

            while (true)
            {
                string searchedBooks = Console.ReadLine();

                if (searchedBooks == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {bookCount} books.");
                    break;
                }

                if (searchedBooks == book)
                {
                    Console.WriteLine($"You checked {bookCount} books and found it.");
                    break;
                }

                bookCount++;
            }
        }
    }
}