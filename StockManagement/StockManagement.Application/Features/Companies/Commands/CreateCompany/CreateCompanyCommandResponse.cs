using StockManagement.Application.Responses;

namespace StockManagement.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandResponse: BaseResponse
    {
        public CreateCompanyCommandResponse() : base()
        {
            
        }

        public CreateCompanyDto Company { get; set; }
    }
}
