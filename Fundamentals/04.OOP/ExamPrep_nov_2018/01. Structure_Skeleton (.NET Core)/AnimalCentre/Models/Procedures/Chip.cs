using System;

using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Chip:Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            this.CheckProcedureTime(animal, procedureTime);

            animal.IsChipped = true;
            animal.Happiness -= 5;
            animal.ProcedureTime -= procedureTime;

            procedureHistory.Add(animal);


        }
    }
}
