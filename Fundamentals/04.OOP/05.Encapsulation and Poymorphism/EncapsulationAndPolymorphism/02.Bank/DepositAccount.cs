namespace _02.Bank
{
    public class DepositAccount : Account, IDepositable, IWithdrowable
    {
        public DepositAccount(decimal balance, decimal interestRate, Customer customer)
            : base(balance, interestRate, customer)
        {
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public void Withdrow(decimal amount)
        {
            this.Balance -= amount;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Balance < 1000) return this.Balance;
            return this.Balance*(1 + this.InterestRate*months);
        }
    }
}