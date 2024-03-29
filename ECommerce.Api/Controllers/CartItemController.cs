﻿using ECommerce.Application.Contracts.Identity;
using ECommerce.Application.Features.CartItems.Commands.Create;
using ECommerce.Application.Features.CartItems.Commands.Delete;
using ECommerce.Application.Features.CartItems.Commands.Update;
using ECommerce.Application.Features.CartItems.Queries.GetById;
using ECommerce.Application.Features.CartItems.Queries.GetList;
using ECommerce.Application.Models.Pager;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/cart-item/")]
    [ApiController]
    [Authorize(Roles = "Administrator, User")]
    public class CartItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;

        public CartItemController(IMediator mediator, IUserService userService)
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
        public async Task<ActionResult<CartItemDto>> GetById(long id)
        {
            var entity = await _mediator.Send(new GetByIdQuery(id));
            return Ok(entity);
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedResult<CartItemListDto>>> GetList([FromQuery] CartItemFilterDto filter, [FromQuery] Pager pager)
        {
            var entities = await _mediator.Send(new GetListQuery(filter, pager));
            return Ok(entities);
        }
    }
}
