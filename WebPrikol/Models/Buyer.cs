namespace WebPrikol.Models
{
    public class Buyer
    {
        public Guid? Id { get; set; }
        public string? FIO { get; set; }

        public int? PhoneNumber { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
