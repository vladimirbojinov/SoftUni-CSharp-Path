namespace _05._Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Empty;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                string currentChar = username[i];
                password += currentChar;
            }

            string passwordInput = Console.ReadLine();
            int attempts = 1;

            for (int i = attempts; i <= 4; i++)
            {
                if (passwordInput == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }

                if (attempts >= 4 && passwordInput != password)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }

                Console.WriteLine("Incorrect password. Try again.");

                attempts++;
                passwordInput = Console.ReadLine();
            }
        }
    }
}