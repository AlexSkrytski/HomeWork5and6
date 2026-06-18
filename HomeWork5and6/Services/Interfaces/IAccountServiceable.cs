namespace HomeWork5and6.Services.Interfaces
{
    public interface IAccountServiceable
    {
        public decimal Balance { get; }

        public void AddFunds(decimal amount);

        public bool Withdraw(decimal withdraw);

    }
}
