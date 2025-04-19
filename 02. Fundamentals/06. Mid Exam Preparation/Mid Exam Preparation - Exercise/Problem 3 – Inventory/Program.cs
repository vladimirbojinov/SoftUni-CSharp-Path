namespace Problem_3___Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inventory = Console.ReadLine()
            .Split(", ")
            .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Craft!")
            {
                string[] arguments = command.Split(" - ");

                switch (arguments[0])
                {
                    case "Collect": inventory = CollectItem(inventory, arguments[1]); break;
                    case "Drop": inventory = DropItem(inventory, arguments[1]); break;
                    case "Combine Items": inventory = CombineItem(inventory, arguments[1]); break;
                    case "Renew": inventory = RenewItem(inventory, arguments[1]); break;
                }
            }

            Console.WriteLine(string.Join(", ", inventory));
        }

        static List<string> CollectItem(List<string> inventory, string item)
        {
            if (!inventory.Contains(item))
            {
                inventory.Add(item);
            }

            return inventory;
        }
        static List<string> DropItem(List<string> inventory, string item)
        {
            if (inventory.Contains(item))
            {
                inventory.Remove(item);
            }

            return inventory;
        }
        static List<string> CombineItem(List<string> inventory, string items)
        {
            string[] combinedItems = items.Split(':');

            if (inventory.Contains(combinedItems[0]))
            {
                int index = (inventory.IndexOf(combinedItems[0])) + 1;
                inventory.Insert(index, combinedItems[1]);
            }

            return inventory;
        }
        static List<string> RenewItem(List<string> inventory, string item)
        {
            if (inventory.Contains(item))
            {
                inventory.Add(item);
                inventory.Remove(item);
            }

            return inventory;
        }
    }
}