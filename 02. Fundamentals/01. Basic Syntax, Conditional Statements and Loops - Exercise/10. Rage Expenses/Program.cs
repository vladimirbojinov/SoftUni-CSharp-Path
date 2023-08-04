namespace _10._Rage_Expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int gamesLost = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int trashedHeadset = 0;
            int trashedMouse = 0;
            int trashedKeyboard = 0;
            int trashedDisplay = 0;

            for (int i = 1; i <= gamesLost; i++)
            {
                if (i % 2 == 0)
                {
                    trashedHeadset++;
                }

                if (i % 3 == 0)
                {
                    trashedMouse++;
                }

                if (i % 3 == 0 && i % 2 == 0)
                {
                    trashedKeyboard++;
                    if (trashedKeyboard % 2 == 0)
                    {
                        trashedDisplay++;
                    }
                }
            }

            double headsetExpenses = trashedHeadset * headsetPrice;
            double mouseExpenses = trashedMouse * mousePrice;
            double keyboardExpenses = trashedKeyboard * keyboardPrice;
            double monitorExpenses = trashedDisplay * displayPrice;

            double totalExpenses = headsetExpenses + mouseExpenses + keyboardExpenses + monitorExpenses;

            Console.WriteLine($"Rage expenses: {totalExpenses:f2} lv.");
        }
    }
}