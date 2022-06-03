using System.ComponentModel.DataAnnotations;

namespace WebPrikol.Models
{
    public class Warehouse
    {
        [Key]
        public int? Id { get; set; }
        public string? ProductName { get; set; }
        public int? ProductPrice { get; set; }
        public int? ProductAmount { get; set; }
        public List<Product>? ProductsList { get; set; }
    }
}
