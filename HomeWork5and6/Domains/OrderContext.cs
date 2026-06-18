namespace HomeWork5and6.Domains
{
    public class OrderContext
    {
        public decimal TotalAmount { get; set; }
        public List<string> AppliedDiscounts { get; set; } = new();
    }

}
