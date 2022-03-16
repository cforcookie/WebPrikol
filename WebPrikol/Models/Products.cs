namespace WebPrikol.Models
{
    public class Products
    {
        public Guid? ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? Price { get; set; }
        public Warehouse? WarehouseId { get; set; }
        public Purchase? Purchases { get; set; }
        public int? PurchaseForigenKey { get; set; }
        public List<Orders>? Orders { get; set; }

    }
}
