using StockManagement.Domain.Common;

namespace StockManagement.Domain.Entities
{
    public class Supplier: AuditableEntity
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
