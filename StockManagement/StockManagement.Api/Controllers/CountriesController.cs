using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.Features.Categories.Queries.GetCategoriesList;
using StockManagement.Application.Features.Countries.Queries.GetCountryList;

namespace StockManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CountriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCountries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CountryListVm>>> GetAllCountries()
        {
            var dtos = await _mediator.Send(new GetCountryListQuery());
            return Ok(dtos);
        }
    }
}
