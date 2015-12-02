using System.Collections.Generic;
using _03.CompanyHierarchy.Utils;

namespace _03.CompanyHierarchy.Hierarchy
{
    internal interface ISalesRmployee
    {
        List<Sale> Sales { get; set; }
    }
}