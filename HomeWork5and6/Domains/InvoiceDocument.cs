namespace HomeWork5and6.Domains
{
    public class InvoiceDocument : Document
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "USD";
    }
}
