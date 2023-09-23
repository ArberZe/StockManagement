using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.Features.Companies.Commands.CreateCompany;
using StockManagement.Application.Features.Companies.Queries.GetCompanyList;

namespace StockManagement.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCompanies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CompanyListVm>>> GetAllCompanies()
        {
            var dtos = await _mediator.Send(new GetCompanyListQuery());
            return Ok(dtos);
        }

        [HttpPost(Name = "AddCompany")]
        public async Task<ActionResult<CreateCompanyCommandResponse>> Create([FromBody] CreateCompanyCommand createCompanyCommand)
        {
            var response = await _mediator.Send(createCompanyCommand);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response.ValidationErrors);
        }
    }
}
