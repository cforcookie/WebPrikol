namespace WebPrikol.Models
{
    public class Product
    {
        public Guid? Id { get; set; }
        public string? ProductName { get; set; }
        public int? Price { get; set; }
        public Purchase? Purchase { get; set; }
        public Guid? PurchaseForigenKey { get; set; }

    }
}