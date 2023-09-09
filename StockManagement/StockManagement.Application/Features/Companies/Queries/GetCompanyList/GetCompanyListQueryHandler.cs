using AutoMapper;
using MediatR;
using StockManagement.Application.Contracts.Persistence;
using StockManagement.Domain.Entities;

namespace StockManagement.Application.Features.Companies.Queries.GetCompanyList
{
    public class GetCompanyListQueryHandler : IRequestHandler<GetCompanyListQuery, List<CompanyListVm>>
    {
        private readonly IAsyncRepository<Company> _companyRepository;
        private readonly IMapper _mapper;

        public GetCompanyListQueryHandler(IAsyncRepository<Company> companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public async Task<List<CompanyListVm>> Handle(GetCompanyListQuery request, CancellationToken cancellationToken)
        {
            var allCompanies = (await _companyRepository.ListAllAsync()).OrderByDescending(x => x.CreatedDate);

            return _mapper.Map<List<CompanyListVm>>(allCompanies);
        }
    }
}
