namespace _01._Extract_Person_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int textNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < textNumber; i++)
            {
                string text = Console.ReadLine();

                int nameStartIndex = (text.IndexOf('@')) + 1;
                int nameEndIndex = (text.IndexOf('|')) - nameStartIndex;

                int ageStartIndex = (text.IndexOf('#')) + 1;
                int ageEndIndex = (text.IndexOf('*')) - ageStartIndex;

                string name = text.Substring(nameStartIndex, nameEndIndex);
                string age = text.Substring(ageStartIndex, ageEndIndex);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}