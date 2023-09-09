using MediatR;

namespace StockManagement.Application.Features.Companies.Queries.GetCompanyList
{
    public class GetCompanyListQuery: IRequest<List<CompanyListVm>>
    {
    }
}
