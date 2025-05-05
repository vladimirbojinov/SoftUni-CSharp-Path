namespace _06._Store_Boxes
{
	internal class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxList = new List<Box>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] input = command.Split();

                string boxSerialNum = input[0];
                string itemName = input[1];
                int itemQuantity = int.Parse(input[2]);
                double itemPrice = double.Parse(input[3]);

                Item item = new Item(itemName, itemPrice);
                double boxPrice = itemQuantity * itemPrice;
                Box box = new Box(boxSerialNum, item, itemQuantity, boxPrice);
                boxList.Add(box);
            }

            foreach (Box box in boxList.OrderByDescending(x => x.BoxPrice))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.BoxPrice:F2}");
            }
        }
    }

    public class Item
    {
        public Item(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class Box
    {
        public Box(string serialNumber, Item item, int itemQuantity, double boxPrice)
        {
            SerialNumber = serialNumber;
            Item = item;
            Quantity = itemQuantity;
            BoxPrice = boxPrice;
        }

        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public double BoxPrice { get; set; }
    }
}