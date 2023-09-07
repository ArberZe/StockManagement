using StockManagement.Domain.Common;

namespace StockManagement.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } 
    }
}
