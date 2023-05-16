namespace _09._Yard_Greening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            double metersForGreenaring = double.Parse(Console.ReadLine());
            //calculations
            double price = metersForGreenaring * 7.61;
            double discountedPrice = 0.18 * price;
            double finalPrice = price - discountedPrice;
            //output
            Console.WriteLine($"The final price is: {finalPrice} lv.");
            Console.WriteLine($"The discount is {discountedPrice} lv.");
        }
    }
}