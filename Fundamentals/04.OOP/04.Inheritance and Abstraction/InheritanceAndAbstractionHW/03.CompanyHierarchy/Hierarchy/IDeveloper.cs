using System.Collections.Generic;
using _03.CompanyHierarchy.Utils;

namespace _03.CompanyHierarchy.Hierarchy
{
    internal interface IDeveloper
    {
        List<Project> Projects { get; set; }
    }
}