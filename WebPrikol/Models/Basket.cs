using System.ComponentModel.DataAnnotations;

namespace WebPrikol.Models
{
    public class Basket
    {
        [Key]
        public int? Id { get; set; }
        public Product? Product { get; set; }
        public int? ProductsForeiginKey { get; set; }
        public User? User { get; set; }
        public int? UserForeiginKey { get; set; }
        public int? PriceSumming { get; set; }

    }
}
