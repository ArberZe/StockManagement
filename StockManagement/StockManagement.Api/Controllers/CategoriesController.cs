using StockManagement.Application.Features.Categories.Commands.CreateCategory;
using StockManagement.Application.Features.Categories.Queries.GetCategoriesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.Features.Categories.Queries.GetCategoriesByCreatedDateDescending;
using Microsoft.AspNetCore.Authorization;

namespace StockManagement.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(dtos);
        }

        [HttpGet("createdDateDescending", Name = "GetAllCategoriesByCreatedDateDescending")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListDescendingOrderedVm>>> GetAllCategoriesByCreatedDateDescendingAsync()
        {
            var dtos = await _mediator.Send(new GetCategoriesByCreatedDateDescendingQuery());
            return Ok(dtos);
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await _mediator.Send(createCategoryCommand);
            return Ok(response);
        }
    }
}