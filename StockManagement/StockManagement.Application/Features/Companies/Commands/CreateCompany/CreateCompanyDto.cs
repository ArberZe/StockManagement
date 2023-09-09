using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyDto
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
    }
}
