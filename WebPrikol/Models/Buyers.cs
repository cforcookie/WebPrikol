namespace WebPrikol.Models
{
    public class Buyers
    {
        public Guid? BuyerId { get; set; }
        public string? FIO { get; set; }
        public int? PhoneNumber { get; set; }

        public List<Orders>? Orders { get; set; }
    }
}
