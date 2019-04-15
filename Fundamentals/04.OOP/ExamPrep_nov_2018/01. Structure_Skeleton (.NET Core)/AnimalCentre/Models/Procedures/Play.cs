using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Play:Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            this.CheckProcedureTime(animal, procedureTime);

            animal.Happiness += 12;
            animal.Energy -= 6;
            animal.ProcedureTime -= procedureTime;

            procedureHistory.Add(animal);
        }
    }
}
