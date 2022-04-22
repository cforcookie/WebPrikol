namespace WebPrikol.Models
{
    public class Warehouse
    {
        public Guid Id { get; set; }
        public string? WarehouseName { get; set; }
        public string? WarehouseAddress { get; set; }
        public Purchase? Purchase { get; set; }
        public Guid? WarehouseForigenKey { get; set; }
}
}
