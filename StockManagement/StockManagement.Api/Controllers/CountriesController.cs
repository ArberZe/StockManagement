using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.Features.Categories.Queries.GetCategoriesList;
using StockManagement.Application.Features.Countries.Commands.CreateCountry;
using StockManagement.Application.Features.Countries.Queries.GetCountryList;

namespace StockManagement.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CountriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("all", Name = "GetAllCountries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CountryListVm>>> GetAllCountries()
        {
            var dtos = await _mediator.Send(new GetCountryListQuery());
            return Ok(dtos);
        }

        [HttpPost(Name = "AddCountry")]
        public async Task<ActionResult<CreateCountryCommandResponse>> Create([FromBody] CreateCountryCommand createCountryCommand)
        {
            var response = await _mediator.Send(createCountryCommand);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response.ValidationErrors);
        }
    }
}
