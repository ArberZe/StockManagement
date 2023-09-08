using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.Features.Countries.Queries.GetCountryList;
using StockManagement.Application.Features.Suppliers.Queries.GetSupplierList;

namespace StockManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SuppliersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllSuppliers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<SupplierListVm>>> GetAllSuppliers()
        {
            var dtos = await _mediator.Send(new GetSupplierListQuery());
            return Ok(dtos);
        }
    }
}
