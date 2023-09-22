using StockManagement.Api.Utility;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.Features.Products.Commands.CreateProduct;
using StockManagement.Application.Features.Products.Queries.GetProductDetails;
using StockManagement.Application.Features.Products.Queries.GetProductsExport;
using StockManagement.Application.Features.Products.Queries.GetProductsList;
using StockManagement.Application.Features.Products.Commands.UpdateProduct;
using Microsoft.AspNetCore.Authorization;

namespace StockManagement.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("all", Name = "GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductListVm>>> GetAllProducts()
        {
            var dtos = await _mediator.Send(new GetProductsListQuery());
            return Ok(dtos);
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<GetProductDetailsQueryResponse>> GetProductById(int id)
        {
            var response = await _mediator.Send(new GetProductDetailsQuery() { ProductId = id });

            if (response.Success)
            {
                return Ok(response);
            }
            if (response.Success == false)
            {
                return NotFound(response.Message);
            }
            return BadRequest();

            //return Ok(result);
        }

        [HttpPost(Name = "AddProduct")]
        public async Task<ActionResult<CreateProductCommandResponse>> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var response = await _mediator.Send(createProductCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            await _mediator.Send(updateProductCommand);
            return NoContent();
        }

        [HttpGet("export", Name = "ExportProducts")]
        [FileResultContentType("text/csv")]
        public async Task<FileResult> ExportProducts()
        {
            var fileDto = await _mediator.Send(new GetProductsExportQuery());

            return File(fileDto.Data, fileDto.ContentType, fileDto.ProductExportFilename);
        }
    }
}
