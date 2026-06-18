using HomeWork5and6.DTO;

namespace HomeWork5and6.services
{
    public class DynamicDiscountService
    {
        public OrderResponse Calculate(OrderRequest request)
        {
            var response = new OrderResponse { FinalAmount = request.TotalAmount };

            foreach (var rule in request.DiscountRules)
            {
                // Обработка процентной скидки
                if (rule.Type.Equals("percentage", StringComparison.OrdinalIgnoreCase))
                {
                    var discount = response.FinalAmount * (rule.Value / 100); // rule.Value/100 вычисление процента 
                    response.FinalAmount -= discount;
                    response.AppliedDiscounts.Add($"Процентная скидка {rule.Value}%");
                }
                // Обработка фиксированной скидки
                else if (rule.Type.Equals("fixed", StringComparison.OrdinalIgnoreCase))
                {
                    if (response.FinalAmount >= rule.Value)
                    {
                        response.FinalAmount -= rule.Value;
                        response.AppliedDiscounts.Add($"Фиксированная скидка {rule.Value}");
                    }
                }
            }

            return response;
        }
    }
}
