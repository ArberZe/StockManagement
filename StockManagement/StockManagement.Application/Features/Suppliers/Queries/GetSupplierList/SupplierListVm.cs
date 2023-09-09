using StockManagement.Application.Features.Countries.Commands.CreateCountry;

namespace StockManagement.Application.Features.Suppliers.Queries.GetSupplierList
{
    public class SupplierListVm
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
    }
}