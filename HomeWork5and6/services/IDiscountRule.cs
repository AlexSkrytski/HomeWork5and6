using HomeWork5and6.Domains;

namespace HomeWork5and6.services
{
    public interface IDiscountRule
    {
        void ApplyDiscount(OrderContext order);
    }
}
