using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Fitness:Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            this.CheckProcedureTime(animal, procedureTime);

            animal.Happiness -= 3;
            animal.Energy += 10;
            animal.ProcedureTime -= procedureTime;

            procedureHistory.Add(animal);
        }
    }
}
