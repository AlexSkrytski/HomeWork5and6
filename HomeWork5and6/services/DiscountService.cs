using HomeWork5and6.Domains;

namespace HomeWork5and6.services
{
    public class DiscountService
    {
        private readonly IEnumerable<IDiscountRule> _rules;

        public DiscountService(IEnumerable<IDiscountRule> rules)
        {
            _rules = rules;
        }

        public decimal CalculateFinalPrice(OrderContext order)
        {
            foreach (var rule in _rules)
            {
                rule.ApplyDiscount(order);
            }
            return order.TotalAmount;
        }
    }
}
