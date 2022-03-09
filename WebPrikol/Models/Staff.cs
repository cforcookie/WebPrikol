namespace WebPrikol.Models
{
    public class Staff
    {
        public Guid Id { get; set; }
        public string? FIO { get; set; }
        public string? PositionName { get; set; }
        public Position Position { get; set; }
        public int? PositionForigenKey { get; set; }
    }
}
