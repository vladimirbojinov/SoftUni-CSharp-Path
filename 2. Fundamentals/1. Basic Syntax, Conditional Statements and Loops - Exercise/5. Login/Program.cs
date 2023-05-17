namespace _5._Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = "";

            for (int i = username.Length - 1; i >= 0; i--)
            {
                char currentCharacter = username[i];
                password += currentCharacter;

            }

            string passAttempt = Console.ReadLine();
            int attempts = 1;

            for (int i = attempts; i <= 4; i++)
            {

                if (passAttempt == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                
                if (attempts >= 4 && passAttempt != password)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }

                attempts++;
                passAttempt = Console.ReadLine();
            }
        }
    }
}