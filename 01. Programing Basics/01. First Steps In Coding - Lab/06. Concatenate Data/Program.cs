namespace _06._Concatenate_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            string firstname = Console.ReadLine();
            string lastname = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string town = Console.ReadLine();
            //output
            Console.WriteLine($"You are {firstname} {lastname}, a {age}-years old person from {town}.");
        }
    }
}