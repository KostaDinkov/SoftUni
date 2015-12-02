using System;

namespace _03.CompanyHierarchy.Utils
{
    public enum ProjectState
    {
        Open,
        Closed
    }

    internal class Project
    {
        public Project(string name, DateTime startDate)
        {
            this.Name = name;
            this.StartDate = startDate;
        }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Details { get; set; }
        public ProjectState State { get; set; } = ProjectState.Open;

        public void CloseProject()
        {
            this.State = ProjectState.Closed;
        }
    }
}