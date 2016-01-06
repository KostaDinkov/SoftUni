namespace Capitalism.Interfaces
{
    public interface ISalaryCalculator
    {
        double CalculateSalary(double ceoSalary, double departmentBonus, double positionBonus);
    }
}