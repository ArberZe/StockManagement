using AutoMapper;
using Blazored.LocalStorage;
using StockManagement.App.Contracts;
using StockManagement.App.Services.Base;
using StockManagement.App.ViewModels;

namespace StockManagement.App.Services
{
    public class CompanyDataService: BaseDataService, ICompanyDataService
    {
        private readonly IMapper _mapper;
        public CompanyDataService(IClient client, IMapper mapper, ILocalStorageService localstorage):base(client, localstorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<CreateCompanyDto>> CreateCompany(CompanyViewModel companyViewModel)
        {
            try
            {
                ApiResponse<CreateCompanyDto> apiResponse = new();
                CreateCompanyCommand createCompanyCommand = _mapper.Map<CreateCompanyCommand>(companyViewModel);
                var createCompanyCommandResponse = await _client.AddCompanyAsync(createCompanyCommand);
                if(createCompanyCommandResponse.Success ) 
                {
                    apiResponse.Data = _mapper.Map<CreateCompanyDto>(createCompanyCommandResponse.Company);
                    apiResponse.Success = true;
                }
                else
                {
                    apiResponse.Data = null;
                    foreach(var error in createCompanyCommandResponse.ValidationErrors)
                    {
                        apiResponse.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return apiResponse;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<CreateCompanyDto>(ex);
            }
        }

        public async Task<List<CompanyListViewModel>> GetAllCompanies()
        {
            var allCompanies = await _client.GetAllCompaniesAsync();
            var mappedCompanies = _mapper.Map<ICollection<CompanyListViewModel>>(allCompanies);
            return mappedCompanies.ToList();
        }
    }
}
