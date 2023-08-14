using StockManagement.Domain.Common;

namespace StockManagement.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public decimal SellingPrice { get; set; }

    }
}
