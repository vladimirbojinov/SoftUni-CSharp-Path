namespace _01._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");

            foreach (string username in usernames)
            {
                if (username.Length < 3 || username.Length > 16)
                {
                    continue;
                }

                bool validUsername = username.All(x => char.IsLetterOrDigit(x) || x == '-' || x == '_');

                if (validUsername)
                {
                    Console.WriteLine(username);
                }
            }
        }
    }
}