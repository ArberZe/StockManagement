using AutoMapper;
using MediatR;
using StockManagement.Application.Contracts.Persistence;
using StockManagement.Domain.Entities;

namespace StockManagement.Application.Features.Countries.Commands.CreateCountry
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, CreateCountryCommandResponse>
    {
        private readonly IAsyncRepository<Country> _countryRepository;
        private readonly IMapper _mapper;
        public CreateCountryCommandHandler(IAsyncRepository<Country> countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public async Task<CreateCountryCommandResponse> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var createCountryCommandResponse = new CreateCountryCommandResponse();

            var validator = new CreateCountryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Count > 0)
            {
                createCountryCommandResponse.Success = false;
                createCountryCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createCountryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
                return createCountryCommandResponse;
            }

            var country = _mapper.Map<Country>(request);

            country = await _countryRepository.AddAsync(country);

            createCountryCommandResponse.Country = _mapper.Map<CreateCountryDto>(country);

            return createCountryCommandResponse;
        }
    }
}
