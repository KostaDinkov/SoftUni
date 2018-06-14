namespace _09.TeamworkProjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class TeamWorkProjects
    {
        private static void Main()
        {
            //Console.SetIn(new StreamReader("input.txt"));
            var teams = new Dictionary<string, Team>();
            var creators = new HashSet<string>();
            var usersInTeams = new HashSet<string>();

            //Read teams
            var teamCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < teamCount; i++)
            {
                var inputTokens = Console.ReadLine().Split("-");
                var creator = inputTokens[0].Trim();
                var teamName = inputTokens[1].Trim();

                if (teams.ContainsKey(teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (creators.Contains(creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }


                teams.Add(teamName, new Team(teamName, creator));
                creators.Add(creator);
                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            }

            //Assign members
            while (true)
            {
                var inputLine = Console.ReadLine();
                if (inputLine == "end of assignment") break;

                var inputTokens = inputLine.Split("->");
                var user = inputTokens[0].Trim();
                var team = inputTokens[1].Trim();

                if (!teams.ContainsKey(team))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                    continue;
                }

                if (usersInTeams.Contains(user) || creators.Contains(user))
                {
                    Console.WriteLine($"Member {user} cannot join team {team}!");
                    continue;
                }

                teams[team].Members.Add(user);
                usersInTeams.Add(user);
            }

            //Print results
            var validTeams = teams
                .Where(t => t.Value.Members.Count > 0)
                .OrderByDescending(t => t.Value.Members.Count)
                .ThenBy(t => t.Key);

            var disbandTeams = teams.Where(t => t.Value.Members.Count == 0).OrderBy(t => t.Key);

            foreach (var teamPair in validTeams)
            {
                Console.WriteLine(teamPair.Key);
                Console.WriteLine($"- {teamPair.Value.Creator}");
                var membersSorted = teamPair.Value.Members.OrderBy(m => m);
                foreach (var member in membersSorted) Console.WriteLine($"-- {member}");
            }

            Console.WriteLine("Teams to disband:");
            foreach (var teamPair in disbandTeams) Console.WriteLine(teamPair.Key);
        }
    }

    internal class Team
    {
        public Team(string name, string creator)
        {
            this.Name = name;
            this.Creator = creator;
            this.Members = new List<string>();
        }

        public string Name { get; set; }
        public List<string> Members { get; set; }
        public string Creator { get; set; }
    }
}