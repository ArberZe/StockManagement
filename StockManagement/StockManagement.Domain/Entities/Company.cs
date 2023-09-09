using StockManagement.Domain.Common;

namespace StockManagement.Domain.Entities
{
    public class Company: AuditableEntity
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
