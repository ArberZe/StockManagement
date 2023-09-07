
using StockManagement.Domain.Common;

namespace StockManagement.Domain.Entities
{
    public class Country: AuditableEntity
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}
