namespace HomeWork5and6.DTO
{
    public record OrderResponse
    {
        public decimal FinalAmount { get; set; }
        public List<string> AppliedDiscounts { get; set; } = new();
    }
}
