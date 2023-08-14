using StockManagement.Domain.Common;

namespace StockManagement.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public int CategoryID { get; set; }
        public string? Name { get; set; }
    }
}
