
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class NailTrim:Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            this.CheckProcedureTime(animal, procedureTime);

            animal.Happiness -= 7;
            animal.ProcedureTime -= procedureTime;

            procedureHistory.Add(animal);
        }
    }
}
