namespace WebPrikol.Models
{
    public class Order
    {
        public Guid? Id { get; set; }
        public int? Quanity { get; set; }
        public int? Sum { get; set; }
        public Buyer? Buyers { get; set; }
        public Guid? BuyersForigenKey { get; set; }
        public Staff? Staff { get; set; }
        public Guid? StaffsForigenKey { get; set; }
        public Product? Products { get; set; }
        public Guid? ProductsForigenKey { get; set; }
    }
}
