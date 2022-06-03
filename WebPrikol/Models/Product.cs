using System.ComponentModel.DataAnnotations;

namespace WebPrikol.Models
{
    public class Product
    {
        [Key]
        public int? Id { get; set; }
        public string? ProductName { get; set; }
        public int? ProductDescription { get; set; }
        public string? ProductPictureURL { get; set; }
        public Warehouse? Warehouses { get; set; }
        public int? WarehouseForeiginKey{ get; set; }
        public List<Product>? ProductList { get; set; }

    }
}
