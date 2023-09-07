using AutoMapper;
using Blazored.LocalStorage;
using StockManagement.App.Contracts;
using StockManagement.App.Services.Base;
using StockManagement.App.ViewModels;

namespace StockManagement.App.Services
{
    public class CountryDataService: BaseDataService, ICountryDataService
    {
        private readonly IMapper _mapper;
        public CountryDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<CountryListViewModel>> GetAllCountries()
        {
            //await AddBearerToken();

            var allCountries = await _client.GetAllCountriesAsync();
            var mappedCountries = _mapper.Map<ICollection<CountryListViewModel>>(allCountries);
            return mappedCountries.ToList();

        }
        public async Task<ApiResponse<CreateCountryDto>> CreateCountry(CountryViewModel countryViewModel)
        {
            try
            {
                ApiResponse<CreateCountryDto> apiResponse = new();
                CreateCountryCommand createCountryCommand = _mapper.Map<CreateCountryCommand>(countryViewModel);
                var createCountryCommandResponse = await _client.AddCountryAsync(createCountryCommand);
                if (createCountryCommandResponse.Success)
                {
                    //ndoshta nuk ka nevoje qe te behet map rreshti poshte
                    apiResponse.Data = _mapper.Map<CreateCountryDto>(createCountryCommandResponse.Country);
                    apiResponse.Success = true;
                }
                else
                {
                    apiResponse.Data = null;
                    foreach (var error in createCountryCommandResponse.ValidationErrors)
                    {
                        apiResponse.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return apiResponse;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<CreateCountryDto>(ex);
            }
        }
    }
}
