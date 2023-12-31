﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.Features.Suppliers.Commands.CreateSupplier;
using StockManagement.Application.Features.Suppliers.Queries.GetSupplierList;

namespace StockManagement.Api.Controllers
{
    [Authorize]
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

        [HttpPost(Name = "AddSupplier")]
        public async Task<ActionResult<CreateSupplierCommandResponse>> Create([FromBody] CreateSupplierCommand createSupplierCommand)
        {
            var response = await _mediator.Send(createSupplierCommand);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response.ValidationErrors);
        }
    }
}
