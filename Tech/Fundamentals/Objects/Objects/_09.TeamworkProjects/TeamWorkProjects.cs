using System;

namespace _09.TeamworkProjects
{
    using System.Collections.Generic;
    using System.IO;


    class TeamWorkProjects
    {
        static void Main()
        {
            Console.SetIn(new StreamReader("input.txt"));
            var teams = new Dictionary<string,Team>();
            var creators = new HashSet<string>();
            
            //Read teams
            int teamCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < teamCount; i++)
            {
                var inputTokens = Console.ReadLine().Split("-");
                var creator = inputTokens[0].Trim();
                var teamName = inputTokens[1].Trim();

                if (teams.ContainsKey(teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    break;
                }
                else if (creators.Contains(creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    break;
                }
                teams.Add(teamName, new Team(teamName,creator));
                Console.WriteLine($"Team {teamName} has been created by {creator}!");
                
            }
            
            //Assign members
            while (true)
            {
                var inputLine = Console.ReadLine();
                if (inputLine == "end of assignment")
                {
                    break;
                }

                var inputTokens = inputLine.Split("->");
                var user = inputTokens[0].Trim();
                var team = inputTokens[1].Trim();

                if (!teams.ContainsKey(team))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                    break;
                }

                if (!teams[team].AddMember(user))
                {
                    Console.WriteLine($"Member {user} cannot join team {team}!");
                    break;
                }
            }
            
            //Print results
            
        }
    }

    class Team
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

        public bool AddMember(string username)
        {
            if (this.Members.Contains(username) || this.Creator == username)
            {
                return false;
            }
            this.Members.Add(username);
            return true;
        }
        
        
    }
}