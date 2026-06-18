namespace HomeWork5and6.Domains
{
    public class ContractDocument : Document
    {
        public string ContractNumber { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
    }
}
