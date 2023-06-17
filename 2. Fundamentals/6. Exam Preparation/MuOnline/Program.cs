namespace MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoins = 0;
            bool isDead = false;

            string[] roomType = Console.ReadLine()
                .Split("|")
                .ToArray();

            for (int i = 0; i < roomType.Length; i++)
            {
                string[] room = roomType[i].Split();

                switch (room[0])
                {
                    case "potion": health = PotionRoom(room, health); break;
                    case "chest": bitcoins = ChestRoom(room, bitcoins); break;
                    default:
                        isDead = MonsterRoom(room, health, isDead);
                        int monsterAttack = int.Parse(room[1]);
                        health -= monsterAttack;
                        break;
                }

                if (isDead)
                {
                    Console.WriteLine($"You died! Killed by {room[0]}.");
                    Console.WriteLine($"Best room: {i + 1}");
                    break;
                }
            }

            if (!isDead)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }

        }

        static int PotionRoom(string[] room, int health)
        {
            int addedHealth = int.Parse(room[1]);
            if (health + addedHealth > 100)
            {
                Console.WriteLine($"You healed for {100 - health} hp.");
                health = 100;
                Console.WriteLine($"Current health: {health} hp.");
            }
            else
            {
                health += addedHealth;
                Console.WriteLine($"You healed for {addedHealth} hp.");
                Console.WriteLine($"Current health: {health} hp.");
            }

            return health;
        }
        static int ChestRoom(string[] room, int bitcoins)
        {
            int addedBitcoins = int.Parse(room[1]);
            bitcoins += addedBitcoins;

            Console.WriteLine($"You found {addedBitcoins} bitcoins.");
            return bitcoins;
        }
        static bool MonsterRoom(string[] room, int health, bool isDead)
        {
            int monsterAttack = int.Parse(room[1]);
            health -= monsterAttack;

            if (health <= 0)
            {
                return isDead = true;
            }
            else
            {
                Console.WriteLine($"You slayed {room[0]}.");
                return isDead = false;
            }
        }
    }
}