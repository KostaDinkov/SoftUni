namespace _02.Bank
{
    public abstract class Account
    {
        private decimal interestRate;
        private decimal balance;
        private Customer customer;

        public Account(decimal balance, decimal interestRate, Customer customer)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer
        {
            get { return this.customer; }
            set { this.customer = value; }
        }

        public abstract decimal CalculateInterest(int months);

        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public decimal InterestRate
        {
            get { return this.interestRate; }
            set { this.interestRate = value; }
        }
    }
}