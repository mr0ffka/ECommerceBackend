using ECommerce.Application.Contracts.Identity;
using ECommerce.Application.Exceptions;
using ECommerce.Application.Features.Addresses.Commands.Create;
using ECommerce.Application.Features.Addresses.Commands.Update;
using ECommerce.Application.Features.Addresses.Commands.Delete;
//using ECommerce.Application.Features.Addresses.Queries.GetById;
//using ECommerce.Application.Features.Addresses.Queries.GetList;
using ECommerce.Application.Models.Identity;
using ECommerce.Application.Models.Pager;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Org.BouncyCastle.Asn1.Ocsp;
using ECommerce.Application.Features.Addresses.Queries.GetById;
using ECommerce.Application.Features.Addresses.Queries.GetList;

namespace ECommerce.Api.Controllers
{
    [Route("api/address/")]
    [ApiController]
    [Authorize(Roles = "Administrator, User")]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;

        public AddressController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create([FromBody] CreateCommand command)
        {
            var entityId = await _mediator.Send(command);
            return CreatedAtAction(nameof(Create), new { id = entityId });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
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
        public async Task<ActionResult<AddressDto>> GetById(long id)
        {
            var entity = await _mediator.Send(new GetByIdQuery(id));
            return Ok(entity);
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedResult<AddressListDto>>> GetList([FromQuery] AddressFilterDto filter, [FromQuery] Pager pager)
        {
            if (!_userService.IsCurrUserAdmin)
                filter.UserId = _userService.CurrUserId;

            var entities = await _mediator.Send(new GetListQuery(filter, pager));
            return Ok(entities);
        }
    }
}
