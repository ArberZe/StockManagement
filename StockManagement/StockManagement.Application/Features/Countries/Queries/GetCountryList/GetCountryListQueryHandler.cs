using AutoMapper;
using MediatR;
using StockManagement.Application.Contracts.Persistence;
using StockManagement.Domain.Entities;

namespace StockManagement.Application.Features.Countries.Queries.GetCountryList
{
    public class GetCountryListQueryHandler : IRequestHandler<GetCountryListQuery, List<CountryListVm>>
    {
        private readonly IAsyncRepository<Country> _countryRepository;
        private readonly IMapper _mapper;
        public GetCountryListQueryHandler(IAsyncRepository<Country> countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public async Task<List<CountryListVm>> Handle(GetCountryListQuery request, CancellationToken cancellationToken)
        {
            var allCountries = (await _countryRepository.ListAllAsync()).OrderByDescending(e => e.CreatedDate).ToList();

            return _mapper.Map<List<CountryListVm>>(allCountries);
        }
    }
}
