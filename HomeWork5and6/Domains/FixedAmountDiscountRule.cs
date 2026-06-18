using HomeWork5and6.services;

namespace HomeWork5and6.Domains
{
    public class FixedAmountDiscountRule : IDiscountRule
    {
        private readonly decimal _amount;

        public FixedAmountDiscountRule(decimal amount)
        {
            _amount = amount;
        }

        public void ApplyDiscount(OrderContext order)
        {
            if (order.TotalAmount >= _amount)
            {
                order.TotalAmount -= _amount;
                order.AppliedDiscounts.Add($"Фиксированная скидка {_amount}");
            }
        }
    }
}
