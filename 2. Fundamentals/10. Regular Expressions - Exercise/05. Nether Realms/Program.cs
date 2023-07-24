using System.Text.RegularExpressions;

namespace _05._Nether_Realms
{
    class Demon
    {
        public Demon(string name, int health, decimal damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public decimal Damage { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Demon> demonList = new List<Demon>();
            string[] demonsNames = Console.ReadLine().Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < demonsNames.Length; i++)
            {
                string demonName = demonsNames[i];
                int demonHealth = HealthCalculator(demonName);
                decimal demonDamage = DamageCalculator(demonName);

                Demon demon = new Demon(demonName, demonHealth, demonDamage);
                demonList.Add(demon);
            }

            demonList = demonList.OrderBy(x => x.Name).ToList();

            foreach (Demon demon in demonList)
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:F2} damage");
            }
        }

        private static decimal DamageCalculator(string demonsName)
        {
            decimal damage = 0;
            string pattern = @"([-]|[+])*\d+[.]*\d*";

            Regex regex = new Regex(pattern);
            MatchCollection matchCollection = regex.Matches(demonsName);

            foreach (Match match in matchCollection)
            {
                damage += decimal.Parse(match.Value);
            }

            for (int i = 0; i < demonsName.Length; i++)
            {
                if (demonsName[i] == '*')
                {
                    damage *= 2;
                }
                else if (demonsName[i] == '/')
                {
                    damage /= 2;
                }
            }

            return damage;
        }

        static int HealthCalculator(string demonsName)
        {
            int health = 0;

            string wordPattern = @"[^0-9\*\/\+\-\.]";
            MatchCollection matches = Regex.Matches(demonsName, wordPattern);

            foreach (Match match in matches)
            {
                health += match.Value[0];
            }

            return health;
        }
    }
}