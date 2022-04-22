namespace WebPrikol.Models
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public string? SupplierName { get; set; }
        public string? SupplierAddress { get; set; }
        public List<Purchase>? Purchase { get; set; }
    }
}
