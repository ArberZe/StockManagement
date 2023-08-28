<<<<<<< HEAD
﻿using StockManagement.Api.Utility;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.Features.Products.Commands.CreateProduct;
using StockManagement.Application.Features.Products.Queries.GetProductDetails;
using StockManagement.Application.Features.Products.Queries.GetProductsExport;
using StockManagement.Application.Features.Products.Queries.GetProductsList;

namespace StockManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductListVm>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetProductsListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<ProductDetailsVm>> GetProductById(int id)
        {
            var getProductDetailQuery = new GetProductDetailsQuery() { ProductId = id};
            return Ok(await _mediator.Send(getProductDetailQuery));
        }

        [HttpPost(Name = "AddProduct")]
        public async Task<ActionResult<CreateProductCommandResponse>> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var response = await _mediator.Send(createProductCommand);
            return Ok(response);
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
=======
﻿using GloboTicket.TicketManagement.Api.Utility;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.Features.Categories.Commands.CreateCategory;
using StockManagement.Application.Features.Categories.Queries.GetCategoriesList;
using StockManagement.Application.Features.Products.Commands.CreateProduct;
using StockManagement.Application.Features.Products.Queries.GetProductDetails;
using StockManagement.Application.Features.Products.Queries.GetProductsExport;
using StockManagement.Application.Features.Products.Queries.GetProductsList;

namespace StockManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductListVm>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetProductsListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<ProductDetailsVm>> GetProductById(int id)
        {
            var getProductDetailQuery = new GetProductDetailsQuery() { ProductId = id};
            return Ok(await _mediator.Send(getProductDetailQuery));
        }

        [HttpPost(Name = "AddProduct")]
        public async Task<ActionResult<CreateProductCommandResponse>> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var response = await _mediator.Send(createProductCommand);
            return Ok(response);
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
>>>>>>> facfeb4d50bb811eabacaadcc911ea637ce309ba
