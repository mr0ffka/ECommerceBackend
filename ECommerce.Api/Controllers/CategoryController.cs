using ECommerce.Application.Features.Categories.Queries.GetById;
using ECommerce.Application.Features.Categories.Queries.GetList;
using ECommerce.Application.Features.Categories.Commands.Create;
using ECommerce.Application.Features.Categories.Commands.Delete;
using ECommerce.Application.Features.Categories.Commands.Update;
using ECommerce.Application.Models.Pager;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Create([FromBody] CreateCommand command)
        {
            var entityId = await _mediator.Send(command);
            return CreatedAtAction(nameof(Create), new { id = entityId });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Update(long id, [FromBody] UpdateCommand command)
        {
            command.Id = command.Id == 0 ? id : command.Id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator")]

        public async Task<ActionResult> Delete(long id)
        {
            var command = new DeleteCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
