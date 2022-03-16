namespace WebPrikol.Models
{
    public class Orders
    {
        public Guid? OrderId { get; set; }
        public Products? Products { get; set; }
        public Buyers? Buyers { get; set; }
        public Staff? Staff { get; set; }
        public Orders? Order { get; set; }
        public int? Quanity { get; set; }
        public int? Sum { get; set; }

        public int? BuyersForigenKey { get; set; }
        public int? StaffsForigenKey { get; set; }
        public int? ProductsForigenKey { get; set; }
    }
}
