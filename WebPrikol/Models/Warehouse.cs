namespace WebPrikol.Models
{
    public class Warehouse
    {
        public Guid WarehouseId { get; set; }
        public string? WarehouseName { get; set; }
        public string? WarehouseAddress { get; set; }
        public Purchase? Purchase { get; set; }
        public int? WarehouseForigenKey { get; set; }
}
}
