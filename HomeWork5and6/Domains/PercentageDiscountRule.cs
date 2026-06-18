using HomeWork5and6.services;

namespace HomeWork5and6.Domains
{
    public class PercentageDiscountRule : IDiscountRule
    {
        private readonly decimal _percentage;

        public PercentageDiscountRule(decimal percentage)
        {
            _percentage = percentage;
        }

        public void ApplyDiscount(OrderContext order)
        {
            if (order.TotalAmount > 100)
            {
                var discount = order.TotalAmount * (_percentage / 100);
                order.TotalAmount -= discount;
                order.AppliedDiscounts.Add($"Скидка {_percentage}%");
            }
        }
    }
}
