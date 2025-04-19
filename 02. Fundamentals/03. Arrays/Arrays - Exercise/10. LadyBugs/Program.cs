namespace _10._LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] field = new int[fieldSize];

            int[] bugPositions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < bugPositions.Length; i++)
            {
                int index = bugPositions[i];

                if (index >= 0 && index < field.Length)
                {
                    field[index] = 1;
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] arguments = command.Split();

                switch (arguments[1])
                {
                    case "right":
                        int ladybugIndex = int.Parse(arguments[0]);
                        if (ladybugIndex >= 0 && ladybugIndex < field.Length)
                        {
                            if (field[ladybugIndex] == 0)
                            {
                                continue;
                            }

                            int flyLength = int.Parse(arguments[2]);

                            field[ladybugIndex] = 0;
                            int newLadybugIndex;

                            if (flyLength < 0)
                            {
                                flyLength = Math.Abs(flyLength);
                                newLadybugIndex = ladybugIndex - flyLength;
                            }
                            else
                            {
                                newLadybugIndex = ladybugIndex + flyLength;
                            }

                            if (newLadybugIndex < 0 || newLadybugIndex >= field.Length)
                            {
                                field[ladybugIndex] = 0;
                                continue;
                            }

                            while (field[newLadybugIndex] == 1)
                            {
                                newLadybugIndex++;

                                if (newLadybugIndex < 0 || newLadybugIndex >= field.Length)
                                {
                                    break;
                                }
                            }

                            if (newLadybugIndex < 0 || newLadybugIndex >= field.Length)
                            {
                                field[ladybugIndex] = 0;
                                continue;
                            }

                            field[newLadybugIndex] = 1;
                        }
                        break;

                    case "left":
                        ladybugIndex = int.Parse(arguments[0]);
                        if (ladybugIndex >= 0 && ladybugIndex < field.Length)
                        {
                            if (field[ladybugIndex] == 0)
                            {
                                continue;
                            }
                            int flyLength = int.Parse(arguments[2]);

                            field[ladybugIndex] = 0;
                            int newLadybugIndex;

                            if (flyLength < 0)
                            {
                                flyLength = Math.Abs(flyLength);
                                newLadybugIndex = ladybugIndex + flyLength;
                            }
                            else
                            {
                                newLadybugIndex = ladybugIndex - flyLength;
                            }

                            if (newLadybugIndex < 0 || newLadybugIndex >= field.Length)
                            {
                                field[ladybugIndex] = 0;
                                continue;
                            }

                            while (field[newLadybugIndex] == 1)
                            {
                                newLadybugIndex--;

                                if (newLadybugIndex >= 0 && newLadybugIndex < field.Length)
                                {
                                    break;
                                }
                            }

                            if (newLadybugIndex < 0 || newLadybugIndex >= field.Length)
                            {
                                field[ladybugIndex] = 0;
                                continue;
                            }

                            field[newLadybugIndex] = 1;
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", field));
        }
    }
}
