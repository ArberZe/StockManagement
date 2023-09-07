
using MediatR;

namespace StockManagement.Application.Features.Countries.Queries.GetCountryList
{
    public class GetCountryListQuery: IRequest<List<CountryListVm>>
    {
    }
}
