namespace _02.Bank
{
    using System.Runtime.InteropServices.ComTypes;

    public class LoanAccount : Account, IDepositable
    {
        public LoanAccount(decimal balance, decimal interestRate, Customer customer)
            : base(balance, interestRate, customer)
        {
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public override decimal CalculateInterest(int months)
        {
            decimal gratisPeriodBalance = this.Balance;
            if (this.Customer is Individual)
            {
                if (months <= 3) return gratisPeriodBalance;
                return this.Balance*(1 + this.InterestRate*(months - 3));
            }
            if (months <= 2) return gratisPeriodBalance;
            return this.Balance*(1 + this.InterestRate*(months - 2)) ;
        }
    }
}