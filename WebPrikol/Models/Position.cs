namespace WebPrikol.Models
{
    public class Position
    {
        public Guid Id { get; set; }
        public string? PositionName { get; set; }
        public List<Staff>? Staffs { get; set; }
    }
}
