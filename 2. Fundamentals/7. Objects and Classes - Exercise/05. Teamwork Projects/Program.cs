using System.Xml.Linq;
namespace _05._Teamwork_Projects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Teams> teamsList = new List<Teams>();

            int teamCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < teamCount; i++)
            {
                string[] teamInfo = Console.ReadLine().Split("-");
                string owner = teamInfo[0];
                string teamName = teamInfo[1];

                Teams isTeamExisting = teamsList.FirstOrDefault(x => x.Name == teamName);
                Teams isOwnerExisting = teamsList.FirstOrDefault(x => x.Owner == owner);
                if (isTeamExisting == null && isOwnerExisting == null)
                {
                    Console.WriteLine($"Team {teamName} has been created by {owner}!");
                    Teams team = new Teams(teamName, owner);
                    teamsList.Add(team);
                }
                if (isTeamExisting != null)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                if (isOwnerExisting != null)
                {
                    Console.WriteLine($"{owner} cannot create another team!");
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] members = command.Split("->");
                string member = members[0];
                string teamName = members[1];

                Teams isTeamExisting = teamsList.FirstOrDefault(x => x.Name == teamName);
                Teams isMemberExisting = teamsList.FirstOrDefault(x => x.Members.Contains(member));
                Teams isOwnerExisting = teamsList.FirstOrDefault(x => x.Owner == member);
                if (isTeamExisting != null && isMemberExisting == null && isOwnerExisting == null)
                {
                    teamsList.Find(x => x.Name == teamName)
                        .Members.Add(member);
                }
                if (isTeamExisting == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                if (isMemberExisting != null || isOwnerExisting != null)
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                }
            }

            teamsList = teamsList
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.Name)
                .ToList();

            List<Teams> leftTeams = teamsList.Where(team => team.Members.Count > 0).ToList();
            List<Teams> disbandTeams = teamsList.Where(team => team.Members.Count == 0).ToList();

            Console.WriteLine(string.Join("\n", leftTeams));
            Console.WriteLine("Teams to disband:");
            disbandTeams.ForEach(team => Console.WriteLine(team.Name));
        }
    }

    class Teams
    {
        public Teams(string name, string owner)
        {
            Name = name;
            Owner = owner;
            Members = new List<string>();
        }

        public string Name { get; set; }
        public string Owner { get; set; }
        public List<string> Members { get; set; }

        public override string ToString()
        {
            string members = string.Empty;

            Members = Members
                .OrderBy(x => x)
                .ToList();

            foreach (string member in Members)
            {
                members += $"-- {member} \n";
            }
            return $"{Name}\n- {Owner}\n{members.Trim()}";
        }
    }
}