using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand: IRequest<CreateCompanyCommandResponse>
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
