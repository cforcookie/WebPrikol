namespace WebPrikol.Models
{
    public class Staff
    {
        public Guid Id { get; set; }
        public string? FIO { get; set; }
        public string? PositionName { get; set; }
        public Position? Positions { get; set; }
        public List<Orders>? Orders { get; set; }
        public int? PositionForigenKey { get; set; }
    }
}
