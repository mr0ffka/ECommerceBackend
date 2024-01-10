using ECommerce.Application.Features.Payments.Commands.Create;
using ECommerce.Application.Features.Payments.Queries.GetPaymentMethodList;
using ECommerce.Application.Features.Payments.Queries.GetPaymentStatusList;
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
    }
}
