using HomeWork5and6.Services.Interfaces;

namespace HomeWork5and6.services
{
    public class AccountService : IAccountServiceable
    {
        private decimal _balance;

        public decimal Balance => _balance;

        public void AddFunds(decimal amount)
        {
            if (amount > 0)
            {
                _balance += amount;
            }
        }
        public bool Withdraw(decimal withdraw)
        {
            if (withdraw > _balance)
            {
                return false;
            }
            else
            {
                _balance -= withdraw;

                return true;
            }
        }
    }
}
