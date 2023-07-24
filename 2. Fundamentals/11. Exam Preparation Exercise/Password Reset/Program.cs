namespace Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string oldPassword = Console.ReadLine();
            string newPassword = oldPassword;

            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] arguments = command.Split();

                switch (arguments[0])
                {
                    case "TakeOdd": newPassword = TakeOdd(newPassword); break;
                    case "Cut": 
                        int index = int.Parse(arguments[1]);
                        int length = int.Parse(arguments[2]);
                        newPassword = Cut(newPassword, index, length); break;
                    case "Substitute": 
                        string oldString = arguments[1];
                        string newString = arguments[2];
                        newPassword = Substitute(newPassword, oldString, newString); break;
                }
            }

            Console.WriteLine($"Your password is: {newPassword}");
        }

        static string Substitute(string oldPassword, string oldString, string newString)
        {
            string newPassword = oldPassword;

            if (oldPassword.Contains(oldString))
            {
                newPassword = oldPassword.Replace(oldString, newString);
                Console.WriteLine(newPassword);
            }
            else
            {
                Console.WriteLine("Nothing to replace!");
            }

            return newPassword;
        }
        static string Cut(string oldPassword, int index, int length)
        {
            string newPassword = oldPassword.Remove(index, length);

            Console.WriteLine(newPassword);
            return newPassword;
        }
        static string TakeOdd(string oldPassword)
        {
            string newPassword = string.Empty;

            for (int i = 1; i < oldPassword.Length; i += 2)
            {
                newPassword += oldPassword[i].ToString();
            }

            Console.WriteLine(newPassword);
            return newPassword;
        }
    }
}