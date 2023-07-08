namespace _03._MOBA_Challenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            while ((command = Console.ReadLine()) != "Season end")
            {
                string[] parts = command.Split(new string[] { " vs ", " -> " }, StringSplitOptions.None);
                Console.WriteLine(string.Join(parts));
            }
        }
    }
}