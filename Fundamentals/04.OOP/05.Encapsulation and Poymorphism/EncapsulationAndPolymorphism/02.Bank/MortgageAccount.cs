namespace _02.Bank
{
    public class MortgageAccount : Account, IDepositable
    {
        public MortgageAccount(decimal balance, decimal interestRate, Customer customer)
            : base(balance, interestRate, customer)
        {
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public override decimal CalculateInterest(int months)
        {
            
            if (this.Customer is Individual)
            {
                decimal gratisPeriodBalance = this.Balance;
                if (months <= 6) return gratisPeriodBalance;
                return this.Balance*(1 + this.InterestRate*(months - 6));
            }
            if (months <= 12) return (this.Balance * (1 + (this.InterestRate/2) * (months )));
            return (this.Balance * (1 + this.InterestRate * (months-12))) + this.Balance*this.InterestRate*months;
        }
    }
}