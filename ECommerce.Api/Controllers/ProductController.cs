using ECommerce.Application.Features.Products.Queries.Get;
using ECommerce.Application.Features.Products.Queries.GetList;
using ECommerce.Application.Models.Pager;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/product/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ProductDetailsDto>> GetById(long id)
        {
            var entity = await _mediator.Send(new GetQuery(id));
            return Ok(entity);
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedResult<ProductDto>>> GetList([FromQuery] ProductFilterDto filter, [FromQuery] Pager pager)
        {
            var entities = await _mediator.Send(new GetListQuery(filter, pager));
            return Ok(entities);
        }
    }
}
