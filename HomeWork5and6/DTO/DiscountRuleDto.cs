namespace HomeWork5and6.DTO
{
    public class DiscountRuleDto
    {
        public string Type { get; set; } = string.Empty; // "percentage" или "fixed"
        public decimal Value { get; set; }
    }
}
