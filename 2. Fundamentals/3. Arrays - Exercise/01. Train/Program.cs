namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wagon = int.Parse(Console.ReadLine());
            int[] numberOfPeople = new int[wagon];

            for (int i = 0; i < numberOfPeople.Length; i++)
            {
                numberOfPeople[i] = int.Parse(Console.ReadLine());
            }

            Console.Write(string.Join(" ", numberOfPeople));
            Console.WriteLine();
            Console.WriteLine(numberOfPeople.Sum());
        }
    }
}