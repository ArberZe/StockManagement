using AutoMapper;
using MediatR;
using StockManagement.Application.Contracts.Persistence;
using StockManagement.Domain.Entities;

namespace StockManagement.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CreateCompanyCommandResponse>
    {
        private readonly IAsyncRepository<Company> _companyRepository;
        private readonly IMapper _mapper;

        public CreateCompanyCommandHandler(IAsyncRepository<Company> companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var createCompanyCommandResponse = new CreateCompanyCommandResponse();

            var validator = new CreateCompanyCommandValidator();
            var validationResponse = await validator.ValidateAsync(request);

            if (validationResponse.Errors.Count > 0)
            {
                createCompanyCommandResponse.Success = false;
                createCompanyCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResponse.Errors)
                {
                    createCompanyCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }

                return createCompanyCommandResponse;
            }

            var company = _mapper.Map<Company>(request);

            company = await _companyRepository.AddAsync(company);

            createCompanyCommandResponse.Company = _mapper.Map<CreateCompanyDto>(company);

            return createCompanyCommandResponse;
        }
    }
}
