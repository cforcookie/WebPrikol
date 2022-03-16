namespace WebPrikol.Models
{
    public class Purchase
    {
        public Guid? PurchaseId { get; set; }
        public Warehouse? WarehouseName { get; set; }
        public int? Quanity { get; set; }
        public int? Sum { get; set; }
        public Supplier? SupplierName { get; set; }
        public int? ProductsForigenKey { get; set; }
        public List<Products>? Products { get; set; }
        public List<Warehouse>? Warehouse { get; set; }
    }
}
