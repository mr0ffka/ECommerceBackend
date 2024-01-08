using ECommerce.Application.Features.Categories.Queries.GetById;
using ECommerce.Application.Features.Categories.Queries.GetList;
using ECommerce.Application.Models.Pager;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/category/")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CategoryDto>> GetById(long id)
        {
            var entity = await _mediator.Send(new GetByIdQuery(id));
            return Ok(entity);
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedResult<CategoryListDto>>> GetList([FromQuery] CategoryFilterDto filter, [FromQuery] Pager pager)
        {
            var entities = await _mediator.Send(new GetListQuery(filter, pager));
            return Ok(entities);
        }
    }
}
