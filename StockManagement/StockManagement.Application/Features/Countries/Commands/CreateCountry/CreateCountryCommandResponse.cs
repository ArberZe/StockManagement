using StockManagement.Application.Responses;

namespace StockManagement.Application.Features.Countries.Commands.CreateCountry
{
    public class CreateCountryCommandResponse: BaseResponse
    {
        public CreateCountryCommandResponse(): base() 
        { 
        }

        public CreateCountryDto Country { get; set; }
    }
}