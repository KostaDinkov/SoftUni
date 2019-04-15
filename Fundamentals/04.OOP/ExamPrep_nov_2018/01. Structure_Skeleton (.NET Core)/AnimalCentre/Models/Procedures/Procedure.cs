using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models
{
    public abstract class Procedure:IProcedure
    {

        protected IList<IAnimal> procedureHistory { get;  }

        public Procedure()
        {
            procedureHistory = new List<IAnimal>();
        }
        public string History()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(GetType().Name);
            foreach (var animal in procedureHistory)
            {
                result.AppendLine($"    - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }

            return result.ToString();
        }

        public abstract void DoService(IAnimal animal, int procedureTime);

        protected void CheckProcedureTime(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            
        }
        
    }
}
