namespace WebPrikol.Models
{
    public class Orders
    {
        public Guid? OrderId { get; set; }
        public Products? Products { get; set; }
        public Buyers? Buyers { get; set; }
        public int? Quanity { get; set; }
        public int? Sum { get; set; }

        public int? BuyersForigenKey { get; set; }
    }
}
