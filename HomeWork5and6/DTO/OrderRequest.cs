namespace HomeWork5and6.DTO
{
    public record OrderRequest
    {
        public decimal TotalAmount { get; set; }
        public List<DiscountRuleDto> DiscountRules { get; set; } = new();
    }
}
