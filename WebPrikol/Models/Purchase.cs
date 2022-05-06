namespace WebPrikol.Models
{
    public class Purchase
    {

        public Guid? PurchaseId { get; set; }
        public int? Quanity { get; set; }
        public int? Sum { get; set; }
        public List<Products>? Products { get; set; }
        public List<Warehouse>? Warehouse { get; set; }
        public Supplier? Supplier { get; set; }
        public int? SupplierForigenKey { get; set; }
    }
}
