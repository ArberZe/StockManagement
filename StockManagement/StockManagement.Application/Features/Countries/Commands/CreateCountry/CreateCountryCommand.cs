
using MediatR;

namespace StockManagement.Application.Features.Countries.Commands.CreateCountry
{
    public class CreateCountryCommand: IRequest<CreateCountryCommandResponse>
    {
        public string? Name { get; set; }
    }
}
