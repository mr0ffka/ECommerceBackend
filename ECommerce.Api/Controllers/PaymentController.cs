using ECommerce.Application.Features.Payments.Commands.ChangeStatus;
using ECommerce.Application.Features.Payments.Commands.Create;
using ECommerce.Application.Features.Payments.Queries.GetPaymentMethodList;
using ECommerce.Application.Features.Payments.Queries.GetPaymentStatusList;
using ECommerce.Application.Features.Payments.Commands.Delete;
using ECommerce.Application.Features.Payments.Commands.Update;
using ECommerce.Application.Models.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers.Admin
{
    [Route("api/payment/")]
    [ApiController]
    [Authorize(Roles = "Administrator, User")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create([FromBody] CreateCommand command)
        {
            var entityId = await _mediator.Send(command);
            return CreatedAtAction(nameof(Create), new { id = entityId });
        }

        [HttpGet("method/list")]
        public async Task<ActionResult<List<EnumValueDescription>>> Methods()
        {
            var enums = await _mediator.Send(new GetPaymentMethodListQuery());
            return Ok(enums);
        }

        [HttpGet("status/list")]
        public async Task<ActionResult<List<EnumValueDescription>>> Statuses()
        {
            var enums = await _mediator.Send(new GetPaymentStatusListQuery());
            return Ok(enums);
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

        [HttpPatch("{paymentId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> ChangeStatus(long paymentId, [FromBody] ChangeStatusCommand command)
        {
            command.PaymentId = command.PaymentId == 0 ? paymentId : command.PaymentId;
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
    }
}
