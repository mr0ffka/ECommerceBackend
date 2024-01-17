using ECommerce.Application.Features.Coupons.Commands.Create;
using ECommerce.Application.Features.Coupons.Commands.Delete;
using ECommerce.Application.Features.Coupons.Commands.Update;
using ECommerce.Application.Features.Coupons.Queries.GetByCode;
using ECommerce.Application.Features.Coupons.Queries.GetById;
using ECommerce.Application.Features.Coupons.Queries.GetList;
using ECommerce.Application.Models.Pager;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/coupon/")]
    [ApiController]
    [Authorize(Roles = "User, Administrator")]
    public class CouponController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CouponController(IMediator mediator)
        {
            _mediator = mediator;
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
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Update(long id, [FromBody] UpdateCommand command)
        {
            command.Id = command.Id == 0 ? id : command.Id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator")]

        public async Task<ActionResult> Delete(long id)
        {
            var command = new DeleteCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<Application.Features.Coupons.Queries.GetById.CouponDto>> GetById(long id)
        {
            var entity = await _mediator.Send(new GetByIdQuery(id));
            return Ok(entity);
        }

        [HttpGet("check/{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Application.Features.Coupons.Queries.GetByCode.CouponDto>> GetByCode(string code)
        {
            var entity = await _mediator.Send(new GetByCodeQuery(code));
            return Ok(entity);
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<PagedResult<CouponListDto>>> GetList([FromQuery] CouponFilterDto filter, [FromQuery] Pager pager)
        {
            var entities = await _mediator.Send(new GetListQuery(filter, pager));
            return Ok(entities);
        }
    }
}
