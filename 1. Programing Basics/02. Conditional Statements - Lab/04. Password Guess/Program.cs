namespace _04._Password_Guess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool correctPassword = password == "s3cr3t!P@ssw0rd";

            if (correctPassword)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}