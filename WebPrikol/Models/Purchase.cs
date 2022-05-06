namespace WebPrikol.Models
{
    public class Purchase
    {
        public Guid? Id { get; set; }
        public int? Quanity { get; set; }
        public int? Sum { get; set; }
        public List<Product>? Products { get; set; }
        public List<Warehouse>? Warehouse { get; set; }
        public Supplier? Supplier { get; set; }
        public Guid? SupplierForigenKey { get; set; }
    }
}